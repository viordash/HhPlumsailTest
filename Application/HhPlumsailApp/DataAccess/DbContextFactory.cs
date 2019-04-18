namespace HhPlumsailApp.DataAccess {
	public class DbContextFactory : IDbContextFactory {
		ApplicationDbContext applicationDbContext;

		public ApplicationDbContext CreateDbContext() {
			applicationDbContext = new ApplicationDbContext();
			return applicationDbContext;
		}

		public void Dispose() {
			if(applicationDbContext != null) {
				applicationDbContext.Dispose();
			}
		}
	}
}