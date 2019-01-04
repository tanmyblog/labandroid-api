using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;
using System.Data.Entity;

namespace Model
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext() : base("ApiConnection")
        {
        }

        static ApiDbContext()
        {
            Database.SetInitializer<ApiDbContext>(new IdentityDbInit());
        }

        public static ApiDbContext Create()
        {
            return new ApiDbContext();
        }


        public DbSet<Restaurants> Restaurants { get; set; }



        public override int SaveChanges()
        {
            //

            return base.SaveChanges();
        }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApiDbContext>
    {
        protected override void Seed(ApiDbContext context)
        {
            base.Seed(context);
        }
    }
}