using System;
using System.IO;
using System.Linq;
using System.Text;
using MediatrExample.Expenses;
using MediatrExample.OrderProcessing;
using MediatR;
using StructureMap;
using StructureMap.Graph;

namespace MediatrExample
{
    class Program
    {
        static void Main()
        {
            var container = new Container(config => config.Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.LookForRegistries();
            }));
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "container.txt"), container.WhatDoIHave());


            var mediator = container.GetInstance<IMediator>();
            
            SubmitExpenseReport(mediator);
            //PlaceOrder(mediator);

            Console.ReadLine();
        }

        private static void PlaceOrder(IMediator mediator)
        {
            var response = mediator.Send(new SubmitOrderRequest
            {
                Payment = new PaymentRequest
                {
                    CreditCardNumber = 545454545454545,
                    VerificationCode = 123,
                    Amount = -100.50M
                },
                ProductIds = new[] { 1,2,3,4}
            });

            if (response.PaymentSuccess)
            {
                var shippedItems = new StringBuilder();
                shippedItems.AppendLine("The following items shipped:");
                response.ProductsShipped.ToList().ForEach(product => shippedItems.AppendFormat("\t{0}", product).AppendLine());
                Console.WriteLine(shippedItems);

                var onBackOrder = new StringBuilder();
                onBackOrder.AppendLine("The following items are out of stock:");
                response.ProductsOnBackOrder.ToList().ForEach(product => onBackOrder.AppendFormat("\t{0}", product).AppendLine());
                onBackOrder.AppendLine("We will ship the items once they are in stock.");
                Console.WriteLine(onBackOrder);
            }
            else
            {
                Console.WriteLine("There was a problem processing your payment. Please try again.");
            }
        }

        private static void SubmitExpenseReport(IMediator mediator)
        {
            var request = new SubmitEmployeeExpenseRequest
            {
                Description = "Meals", 
                Amount = 145.50M
            };

            var response = mediator.Send(request);
            if (response.Approved)
            {
                Console.WriteLine("Expense {0} for {1:C} was approved by {3}? {2}", response.Description, response.Amount,
                    response.Approved, response.ApprovedBy);
            }
        }
    }
}
