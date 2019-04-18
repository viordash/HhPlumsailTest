namespace HhPlumsailApp.DataAccess {
	public class DbContextFactory : IDbContextFactory {

		public ApplicationDbContext CreateDbContext() {
			return new ApplicationDbContext();
		}
	}
}