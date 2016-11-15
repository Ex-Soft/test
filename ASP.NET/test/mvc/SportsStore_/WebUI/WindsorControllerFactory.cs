using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using Castle.Core;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace WebUI
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        WindsorContainer container;

        public WindsorControllerFactory()
        {
            container = new WindsorContainer(
                new XmlInterpreter(new ConfigResource("castle"))
                );

            var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where typeof(IController).IsAssignableFrom(t)
                                  select t;

            foreach (Type t in controllerTypes)
                container.Register(Component.For(t).Named(t.FullName).LifeStyle.Is(LifestyleType.Transient));

            /*
            container.Register(AllTypes
                .FromThisAssembly()
                .BasedOn<IController>()
                .If(Component.IsInSameNamespaceAs<Controllers.ProductsController>())
                .If(t => t.Name.EndsWith("Controller"))
                .Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name)));
             */
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType != null ? (IController)container.Resolve(controllerType) : null;
        }
    }
}