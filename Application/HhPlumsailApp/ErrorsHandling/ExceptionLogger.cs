using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace HhPlumsailApp.ErrorsHandling {
	public class ExceptionLogger : IExceptionLogger {
		static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken) {
			if(context.Exception == null) {
				return Task.FromResult<object>(null);
			}

			logger.Error(context.Exception);
			return Task.FromResult<object>(null);
		}

	}
}