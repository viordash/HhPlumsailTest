using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using HhPlumsailApp.DataAccess;
using HhPlumsailApp.Providers;
using HhPlumsailApp.Services;
using Microsoft.Owin.Security.OAuth;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace HhPlumsailApp {
	public static class ServicesConfig {
		public static void Register(HttpConfiguration config) {
			var container = new UnityContainer();

			container.RegisterType<IDbContextFactory>(
				new ContainerControlledLifetimeManager(),
				new InjectionFactory(c =>
					new DbContextFactory()));

			container.RegisterType<ApplicationDbContext>(
				new PerRequestLifetimeManager(),
				new InjectionFactory(c => c.Resolve<IDbContextFactory>().CreateDbContext()));

			container.RegisterType<IOAuthAuthorizationServerProvider, ApplicationOAuthProvider>(new PerRequestLifetimeManager());
			container.RegisterType<IUserManagerService, UserManagerService>(new PerRequestLifetimeManager());
			container.RegisterType<UserStoreService>(new PerRequestLifetimeManager());

			config.DependencyResolver = new UnityDependencyResolver(container);

			config.Services.Replace(typeof(IExceptionLogger), new ErrorsHandling.ExceptionLogger());
			config.Services.Replace(typeof(IExceptionHandler), new ErrorsHandling.ExceptionHandler());
		}
	}
}
