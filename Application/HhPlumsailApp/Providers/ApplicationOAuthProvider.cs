using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GuardNet;
using HhPlumsailApp.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Unity;

namespace HhPlumsailApp.Providers {
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider {
		readonly IUnityContainer container;

		public ApplicationOAuthProvider(IUnityContainer container) {
			Guard.NotNull(container, nameof(container));
			this.container = container;
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
			if(context.ClientId == null) {
				context.Validated();
			}

			return Task.FromResult<object>(null);
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			using(var _repo = container.Resolve<IUserManagerService>()) {
				var user = await _repo.FindUser(context.UserName, context.Password);

				if(user == null) {
					//throw new SecurityException("The user name or password is incorrect.");
					context.SetError("invalid_grant", "The user name or password is incorrect.");
					return;
				}
			}
			var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
			identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
			identity.AddClaim(new Claim("sub", context.UserName));

			var props = new AuthenticationProperties(new Dictionary<string, string>
				{
					{
						"as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId
					},
					{
						"userName", context.UserName
					}
				});

			var ticket = new AuthenticationTicket(identity, props);
			context.Validated(ticket);
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context) {
			foreach(KeyValuePair<string, string> property in context.Properties.Dictionary) {
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);
		}
	}
}