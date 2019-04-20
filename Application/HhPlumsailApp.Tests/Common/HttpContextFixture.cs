using System.IO;
using System.Web;
using NUnit.Framework;

namespace HhPlumsailApp.Tests.Common {
	public abstract class HttpContextFixture {
		protected HttpContext prevHttpContext { get; private set; }

		[SetUp]
		public virtual void SetUp() {
			prevHttpContext = HttpContext.Current;
			HttpContext.Current = new HttpContext(
				new HttpRequest("", "http://tempuri.org", ""),
				new HttpResponse(new StringWriter())
				);
		}

		[TearDown]
		public virtual void TearDown() {
			HttpContext.Current = prevHttpContext;
		}
	}
}
