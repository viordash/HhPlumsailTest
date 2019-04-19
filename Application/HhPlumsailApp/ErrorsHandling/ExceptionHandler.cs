using System;
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
		public static void BuildResponseData(Exception exception, out HttpStatusCode statusCode, out string errorMessage) {
			if(exception is SecurityException) {
				statusCode = HttpStatusCode.Forbidden;
				errorMessage = exception.GetBaseException().Message;
			} else if(exception is DataException) {
				statusCode = HttpStatusCode.ServiceUnavailable;
				errorMessage = "Db error";
			} else {
				statusCode = HttpStatusCode.BadRequest;
				errorMessage = exception.GetBaseException().Message;
			}
		}

		public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken) {
			if(context.Exception != null) {
				BuildResponseData(context.Exception, out HttpStatusCode statusCode, out string errorMessage);
				context.Result = new ResponseMessageResult(context.Request.CreateResponse(statusCode,
					new {
						Error = errorMessage
					}));
			}
			return Task.FromResult<object>(null);
		}
	}
}