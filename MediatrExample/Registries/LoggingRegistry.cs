using StructureMap.Configuration.DSL;

namespace MediatrExample.Registries
{
    public class LoggingRegistry
        : Registry
    {
        public LoggingRegistry()
        {
            log4net.Config.BasicConfigurator.Configure();
        }
    }
}