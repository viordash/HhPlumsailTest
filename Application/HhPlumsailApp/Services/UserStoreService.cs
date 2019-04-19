using HhPlumsailApp.DataAccess;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HhPlumsailApp.Services {
	public class UserStoreService : UserStore<IdentityUser> {
		public UserStoreService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {
		}

		protected override void Dispose(bool disposing) {
			if(Context != null) {
				Context.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}