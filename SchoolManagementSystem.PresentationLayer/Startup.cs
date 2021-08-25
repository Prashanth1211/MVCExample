using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolManagementSystem.PresentationLayer.Models;

[assembly: OwinStartupAttribute(typeof(SchoolManagementSystem.PresentationLayer.Startup))]
namespace SchoolManagementSystem.PresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();

        }

        public void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var admin = new ApplicationUser();
                admin.UserName = "admin";
                admin.Email = "admin@school.com";
                var password = "Pass@word1";
                var user = userManager.Create(admin, password);

                if (user.Succeeded)
                {
                    var result = userManager.AddToRole(admin.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Teacher"))
            {
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }
        }
    }
}
