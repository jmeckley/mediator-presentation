using FluentValidation;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MediatrExample.Registries
{
    public class FluentValidationRegistry 
        : Registry
    {
        public FluentValidationRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory();
                scanner.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
            });
        }
    }
}