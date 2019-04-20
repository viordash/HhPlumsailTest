using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace HhPlumsailApp.Extensions {
	public static class ModelStateExtensions {
		public static void Validate(this ModelStateDictionary modelState) {
			if(modelState.IsValid) {
				return;
			}
			var exception = new ValidationException();
			exception.Data.Add(string.Empty, modelState.ToDictionary(k => k.Key, v => v.Value.Errors.Select(x => x.ErrorMessage)));
			throw exception;
		}
	}
}