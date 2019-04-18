using System.Web.Http.Dependencies;

namespace HhPlumsailApp.Extensions {
	public static class DependencyResolverExtensions {
		public static TService GetService<TService>(this IDependencyResolver dependencyResolver) {
			return (TService)dependencyResolver.GetService(typeof(TService));
		}
	}
}