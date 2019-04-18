using System.Data;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace HhPlumsailApp.ErrorsHandling {
	public class ExceptionHandler : IExceptionHandler {
		public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken) {
			if(context.Exception == null) {
				return Task.FromResult<object>(null);
			}
			var response = context.Request.CreateResponse();
			if(context.Exception is SecurityException) {
				response.StatusCode = HttpStatusCode.Forbidden;
				response.Content = new StringContent("Access is denied.");
			} else if(context.Exception is DataException) {
				response.StatusCode = HttpStatusCode.ServiceUnavailable;
				response.Content = new StringContent("Db error");
			} else {
				response.StatusCode = HttpStatusCode.BadRequest;
				response.Content = new StringContent(context.Exception.GetBaseException().Message);
			}

			context.Result = new ResponseMessageResult(response);
			return Task.FromResult<object>(null);
		}
	}
}