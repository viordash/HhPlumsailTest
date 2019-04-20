using System.Linq;
using System.Web.Http;
using HhPlumsailApp.DataAccess;
using HhPlumsailApp.Extensions;
using HhPlumsailApp.Tests.Common;
using Moq;
using NUnit.Framework;
using Unity;
using Unity.Lifetime;

namespace HhPlumsailApp.Tests {
	[TestFixture]
	public class ServicesConfigTest : HttpContextFixture {
		interface IFoo { }
		class Foo : IFoo { }

		[Test]
		public void Container_ResolveAll() {
			using(var container = ServicesConfig.InitializeContainer()) {
				var mockDbContext = new Mock<ApplicationDbContext>();
				var mockDbContextFactory = new Mock<IDbContextFactory>();
				mockDbContextFactory
					.Setup(x => x.CreateDbContext())
					.Returns(() => {
						return mockDbContext.Object;
					});

				container.RegisterInstance(mockDbContextFactory.Object);

				foreach(var type in container.Registrations.Select(x => x.RegisteredType)) {
					var instance = container.Resolve(type);
					Assert.That(instance, Is.Not.Null);
				}
			}
		}

		[Test]
		public void Container_ReturnsTheSameInstanceOfTypeRegisteredAsSingletonOnEachCall() {
			var configuration = new HttpConfiguration();
			ServicesConfig.Register(configuration);

			IUnityContainer container = configuration.DependencyResolver.GetService<IUnityContainer>();
			container.RegisterType<IFoo, Foo>(new ContainerControlledLifetimeManager());

			var a = configuration.DependencyResolver.GetService<IFoo>();
			var b = configuration.DependencyResolver.GetService<IFoo>();
			Assert.AreSame(a, b);
		}

		[Test]
		public void HttpConfiguration_ReplaceServices() {
			var configuration = new HttpConfiguration();
			ServicesConfig.Register(configuration);
			Assert.That(configuration.Services.GetExceptionLoggers(), Has.Some.TypeOf<ErrorsHandling.ExceptionLogger>());
			Assert.That(configuration.Services.GetExceptionHandler(), Is.TypeOf<ErrorsHandling.ExceptionHandler>());
		}

	}
}
