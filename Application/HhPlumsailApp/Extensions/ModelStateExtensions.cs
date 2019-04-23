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
			var modelErrors = modelState.Where(x => x.Value.Errors != null && x.Value.Errors.Count > 0);
			exception.Data.Add(string.Empty, modelErrors
				.ToDictionary(k => k.Key, v => v.Value.Errors
					.Select(x => !string.IsNullOrEmpty(x.ErrorMessage)
						? x.ErrorMessage
						: x.Exception.GetBaseException().Message)));
			throw exception;
		}
	}
}