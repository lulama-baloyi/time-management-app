using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using timeMnagementWebpage.Areas.Identity.Data;

namespace timeMnagementWebpage.Areas.Identity.Data
{
    public class DBContextSample : IdentityDbContext<IdentityUser>
    {
        public DBContextSample(DbContextOptions<DBContextSample> options)
            : base(options)
        {
        }
    }
}


