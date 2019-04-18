using System.Web.Http;
using HhPlumsailApp.Extensions;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace HhPlumsailApp {
	public partial class Startup {
		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

		public static string PublicClientId { get; private set; }

		public void ConfigureAuth(IAppBuilder app) {
			var config = GlobalConfiguration.Configuration;
			Bootstrapper.Initialize(config);

			var provider = config.DependencyResolver.GetService<IOAuthAuthorizationServerProvider>();
			app.UseWebApi(config);

			//var config = ConfigurationBuilder.Create();
			//var container = DependencyContainer.Initialize(app);
			//config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
			//var provider = container.Resolve<ApplicationOAuthProvider>();
			//OAuthAuthorizationServer = new OAuthAuthorizationServerOptions {
			//	AllowInsecureHttp = true,
			//	TokenEndpointPath = new PathString("/custom-token"),
			//	AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
			//	Provider = provider
			//};
			//app.UseOAuthAuthorizationServer(OAuthAuthorizationServer);
			//app.UseBearerOnCookieAuthentication();
			//app.UseAutofacMiddleware(container);
			//app.UseAutofacWebApi(config);
			//app.UseWebApi(config);
			//app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
			//app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
			//app.UseSpaWebApi();


			//// Configure the db context and user manager to use a single instance per request
			//app.CreatePerOwinContext(ApplicationDbContext.Create);
			//app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

			//// Enable the application to use a cookie to store information for the signed in user
			//// and to use a cookie to temporarily store information about a user logging in with a third party login provider
			//app.UseCookieAuthentication(new CookieAuthenticationOptions());
			//app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

			//// Configure the application for OAuth based flow
			//PublicClientId = "self";
			//OAuthOptions = new OAuthAuthorizationServerOptions {
			//	TokenEndpointPath = new PathString("/Token"),
			//	Provider = new ApplicationOAuthProvider(PublicClientId),
			//	AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
			//	AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
			//	// In production mode set AllowInsecureHttp = false
			//	AllowInsecureHttp = true
			//};

			//// Enable the application to use bearer tokens to authenticate users
			//app.UseOAuthBearerTokens(OAuthOptions);

			//// Uncomment the following lines to enable logging in with third party login providers
			////app.UseMicrosoftAccountAuthentication(
			////    clientId: "",
			////    clientSecret: "");

			////app.UseTwitterAuthentication(
			////    consumerKey: "",
			////    consumerSecret: "");

			////app.UseFacebookAuthentication(
			////    appId: "",
			////    appSecret: "");

			////app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			////{
			////    ClientId = "",
			////    ClientSecret = ""
			////});
		}
	}
}
