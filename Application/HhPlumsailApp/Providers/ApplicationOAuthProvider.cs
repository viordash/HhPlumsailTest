using System.Threading.Tasks;
using GuardNet;
using HhPlumsailApp.Services;
using Microsoft.Owin.Security.OAuth;

namespace HhPlumsailApp.Providers {
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider {
		readonly IAuthenticationService authenticationService;

		public ApplicationOAuthProvider(IAuthenticationService authenticationService) {
			Guard.NotNull(authenticationService, nameof(authenticationService));
			this.authenticationService = authenticationService;
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
			var user = await authenticationService.FindUser(context.UserName, context.Password);
			if(user == null) {
				context.SetError("invalid_grant", "The user name or password is incorrect.");
				return;
			}

			//ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
			//   OAuthDefaults.AuthenticationType);
			//ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
			//	CookieAuthenticationDefaults.AuthenticationType);

			//AuthenticationProperties properties = CreateProperties(user.UserName);
			//AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
			//context.Validated(ticket);
			//context.Request.Context.Authentication.SignIn(cookiesIdentity);
		}
	}
}