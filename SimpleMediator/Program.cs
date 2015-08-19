using System;

namespace SimpleMediator
{
    class Program
    {
        static void Main()
        {
            var chatRoom = new ChatRoom(Console.Out);
            var jason = new User(chatRoom) { Name = "Jason" };
            var rajeev = new User(chatRoom) { Name = "Rajeev" };
            var jesica = new User(chatRoom) { Name = "Jesica" };
            var dave = new User(chatRoom) { Name = "Dave" };
            
            chatRoom.Add(jason);
            chatRoom.Add(rajeev);
            chatRoom.Add(jesica);
            chatRoom.Add(dave);

            jason.Send("Hi All");

            Console.ReadLine();
        }
    }
}
