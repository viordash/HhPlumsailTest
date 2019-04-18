using System;
using System.Collections.Generic;
using System.Web;
using Unity.Lifetime;

namespace HhPlumsailApp {
	public class PerRequestLifetimeManager : LifetimeManager {
		static readonly string objectDictionaryKey = Guid.NewGuid().ToString();
		readonly Guid objectKey = Guid.NewGuid();

		static IDictionary<Guid, object> ObjectDictionary {
			get {
				IDictionary<Guid, object> objectDictionary = (IDictionary<Guid, object>)HttpContext.Current.Items[objectDictionaryKey];
				if(objectDictionary == null) {
					objectDictionary = new Dictionary<Guid, object>();
					HttpContext.Current.Items[objectDictionaryKey] = objectDictionary;
				}
				return objectDictionary;
			}
		}

		public static void FreeObjects() {
			foreach(object instance in ObjectDictionary.Values) {
				IDisposable disposable = instance as IDisposable;
				if(disposable != null) {
					disposable.Dispose();
				}
			}

			ObjectDictionary.Clear();
		}

		public override object GetValue(ILifetimeContainer container = null) {
			object value;
			if(ObjectDictionary.TryGetValue(objectKey, out value)) {
				return value;
			}
			return null;
		}

		public override void RemoveValue(ILifetimeContainer container = null) {
			ObjectDictionary.Remove(objectKey);
		}

		public override void SetValue(object newValue, ILifetimeContainer container = null) {
			ObjectDictionary[objectKey] = newValue;
		}

		protected override LifetimeManager OnCreateLifetimeManager() {
			throw new NotImplementedException();
		}
	}
}