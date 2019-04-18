using System.Web.Http;
using CommonServiceLocator;
using HhPlumsailApp.DataAccess;
using HhPlumsailApp.Providers;
using HhPlumsailApp.Services;
using Microsoft.Owin.Security.OAuth;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace HhPlumsailApp {
	public class Bootstrapper {
		static Bootstrapper() { }

		public static void Initialize(HttpConfiguration config) {
			var container = new UnityContainer();

			container.RegisterType<IDbContextFactory>(
				new ContainerControlledLifetimeManager(),
				new InjectionFactory(c =>
					new DbContextFactory()));

			container.RegisterType<ApplicationDbContext>(
				new PerRequestLifetimeManager(),
				new InjectionFactory(c => c.Resolve<IDbContextFactory>().CreateDbContext()));

			container.RegisterType<IOAuthAuthorizationServerProvider, ApplicationOAuthProvider>(new PerRequestLifetimeManager());
			container.RegisterType<IAuthenticationService, AuthenticationService>(new PerRequestLifetimeManager());


			var serviceLocator = new UnityServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => serviceLocator);
			config.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}