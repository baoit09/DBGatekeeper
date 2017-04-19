using Autofac;
using Autofac.Integration.WebApi;
using DBGatekeeper.BusinessLogicServices;
using DBGatekeeper.DataAccessServices.Repositories;
using DBGatekeeper.Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Reflection;
using System.Web.Http;

namespace DBGatekeeper
{
    public static class AutofacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Configure the DatabaseFactory to read its configuration from the .config file 
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database database = factory.Create("DataBase");
            builder.Register<Database>(c => database).InstancePerLifetimeScope();

            // Configure for Repositories on Data Access Layer(DAL)
            builder.RegisterType<Repository>().As<IRepository>().InstancePerApiRequest();
            builder.RegisterType<PatientRepository>().As<IPatientRepository>().InstancePerApiRequest();
            builder.RegisterType<StudyRepository>().As<IStudyRepository>().InstancePerApiRequest();

            // Configure for Business Services on Business Logic Layer(BLL)
            builder.RegisterType<EntityService>().As<IEntityService>().InstancePerApiRequest();
            builder.RegisterType<PatientService>().As<IPatientService>().InstancePerApiRequest();
            builder.RegisterType<StudyService>().As<IStudyService>().InstancePerApiRequest();
            builder.RegisterType<ChecksumService>().As<IChecksumService>().InstancePerApiRequest();

            EntityConverterHelper entityConverterHelper = new EntityConverterHelper();
            builder.Register<EntityConverterHelper>(c => entityConverterHelper).InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}