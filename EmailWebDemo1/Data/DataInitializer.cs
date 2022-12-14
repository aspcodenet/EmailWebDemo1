using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmailWebDemo1.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public void SeedData()
    {
        _dbContext.Database.Migrate();
        SeedRoles();
        SeedUsers();
    }

    private void SeedRoles()
    {
        var role = _dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
        if (role == null)
        {
            _dbContext.Roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
        }
        role = _dbContext.Roles.FirstOrDefault(r => r.Name == "Customer");
        if (role == null)
        {
            _dbContext.Roles.Add(new IdentityRole { Name = "Customer", NormalizedName = "Customer" });
        }
        _dbContext.SaveChanges();
    }

    private void SeedUsers()
    {
        AddUserIfNotExists("stefan.holmberg@systementor.se", "Hejsan123#", new string[] { "Admin" });
        AddUserIfNotExists("stefan.holmberg@customer.systementor.se", "Hejsan123#", new string[] { "Customer" });
    }

    private void AddUserIfNotExists(string userName, string password, string[] roles)
    {
        if (_userManager.FindByEmailAsync(userName).Result != null) return;

        var user = new IdentityUser
        {
            UserName = userName,
            Email = userName,
            EmailConfirmed = true
        };
        var result = _userManager.CreateAsync(user, password).Result;
        var r = _userManager.AddToRolesAsync(user, roles).Result;
    }





}