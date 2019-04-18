using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using GuardNet;
using Unity;

namespace HhPlumsailApp {
	public class UnityDependencyResolver : IDependencyResolver {
		readonly IUnityContainer container;

		public UnityDependencyResolver(IUnityContainer container) {
			Guard.NotNull(container, "container");
			this.container = container;
		}

		public object GetService(Type serviceType) {
			if(typeof(IHttpController).IsAssignableFrom(serviceType)) {
				return container.Resolve(serviceType);
			}
			return container.IsRegistered(serviceType) ? container.Resolve(serviceType) : null;
		}

		public IEnumerable<object> GetServices(Type serviceType) {
			return container.IsRegistered(serviceType) ? container.ResolveAll(serviceType) : Enumerable.Empty<object>();
		}

		public IDependencyScope BeginScope() {
			var child = container.CreateChildContainer();
			return new UnityDependencyResolver(child);
		}

		public void Dispose() {
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing) {
			container.Dispose();
		}
	}
}