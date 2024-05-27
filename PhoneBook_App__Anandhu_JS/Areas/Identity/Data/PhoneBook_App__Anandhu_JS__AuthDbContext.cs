using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBook_App__Anandhu_JS.Areas.Identity.Data;
using PhoneBook_App__Anandhu_JS.Models;

namespace PhoneBook_App__Anandhu_JS.Data;

public class PhoneBook_App__Anandhu_JS__AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public PhoneBook_App__Anandhu_JS__AuthDbContext(DbContextOptions<PhoneBook_App__Anandhu_JS__AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<PhoneBook_App__Anandhu_JS.Models.PhoneBook> PhoneBook { get; set; } = default!;
}
