using CommonServiceLocator;
using Unity;
using Unity.ServiceLocation;

namespace HhPlumsailApp {
	public class Bootstrapper {
		static Bootstrapper() { }

		public static void Initialize() {
			var container = new UnityContainer();


			var serviceLocator = new UnityServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => serviceLocator);    // Warning: do NOT remove serviceLocator local variable, do not inline "new UnityServiceLocator"!
		}
	}
}