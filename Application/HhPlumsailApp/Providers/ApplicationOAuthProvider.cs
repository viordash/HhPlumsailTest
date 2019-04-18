using System.Threading.Tasks;
using GuardNet;
using HhPlumsailApp.Services;
using Microsoft.Owin.Security.OAuth;

namespace HhPlumsailApp.Providers {
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider {
		readonly IUserManagerService userManagerService;

		public ApplicationOAuthProvider(IUserManagerService userManagerService) {
			Guard.NotNull(userManagerService, nameof(userManagerService));
			this.userManagerService = userManagerService;
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
			var user = await userManagerService.FindUser(context.UserName, context.Password);
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