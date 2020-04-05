using ContactInfo.BL;
using ContactInfo.BL.BusinessInterfaces;
using ContactInfo.DataAccess.Repositories;
using ContactInfo.DataAccess.RepositoryInterfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ConctactInfoCRUDDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IContactInfoBL, ContactInfoBL>()
                .RegisterType<IAccountBL,AccountBL>()
                .RegisterType<IPatientBL,PatientBL>();
            
            ServiceUnityConfig.RegisterComponents(container);

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
        
    }
    public static class ServiceUnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<IContactInfoRepository, ContactInfoRepository>()
                .RegisterType<IAccountRepository,AccountRepository>()
                .RegisterType<IPatientRepository, PatientRepository>();
        }
    }
}