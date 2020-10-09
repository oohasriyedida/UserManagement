using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace UserManagementDAL
{
   public class UserManagementDBContextFactory : IDesignTimeDbContextFactory<UserManagementDbContext>
    {

        public UserManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserManagementDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserManagementDb;");

            return new UserManagementDbContext(optionsBuilder.Options);
        }
    }
}
