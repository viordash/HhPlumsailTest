using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using GuardNet;
using Microsoft.Owin;
using Newtonsoft.Json;
using NLog;

namespace HhPlumsailApp.ErrorsHandling {
	public class OwinExceptionHandlerMiddleware {
		static readonly Logger logger = LogManager.GetCurrentClassLogger();
		private readonly Func<IDictionary<string, object>, Task> next;

		public OwinExceptionHandlerMiddleware(Func<IDictionary<string, object>, Task> next) {
			Guard.NotNull(next, nameof(next));
			this.next = next;
		}

		public async Task Invoke(IDictionary<string, object> environment) {
			try {
				await next(environment);
			} catch(Exception ex) {
				try {
					var owinContext = new OwinContext(environment);
					logger.Error(ex);
					HandleException(ex, owinContext);
				} catch(Exception) { }
			}
		}
		private void HandleException(Exception ex, IOwinContext context) {
			ExceptionHandler.BuildResponseData(ex, out HttpStatusCode statusCode, out object errorMessage);
			context.Response.StatusCode = (int)statusCode;
			context.Response.ContentType = "application/json";
			context.Response.Write(JsonConvert.SerializeObject(new {
				Error = errorMessage
			}, GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings));
		}
	}
}