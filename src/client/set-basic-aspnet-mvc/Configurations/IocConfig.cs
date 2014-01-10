﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using set_basic_aspnet_mvc.Domain.Services;
using set_basic_aspnet_mvc.Domain.Repositories;

namespace set_basic_aspnet_mvc.Configurations
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)_kernel.Resolve(controllerType);
        }
    }

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>()
                .Unless(x => x.Name == "BaseController").LifestyleTransient());
        }
    }

    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbContext>().ImplementedBy<DataContext>().LifestylePerWebRequest(),
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient(),
                Component.For<IFormsAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifestylePerWebRequest(),
                Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest(),
                Component.For<IReportService>().ImplementedBy<ReportService>().LifestylePerWebRequest(),
                Component.For<ITagService>().ImplementedBy<TagService>().LifestylePerWebRequest(),
                Component.For<ISearchService>().ImplementedBy<SearchService>().LifestylePerWebRequest());
        }
    }
}