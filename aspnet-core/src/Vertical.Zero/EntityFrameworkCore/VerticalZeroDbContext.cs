using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vertical.Authorization.Roles;
using Vertical.Authorization.Users;
using Vertical.MultiTenancy;

namespace Vertical.EntityFrameworkCore
{
    public class VerticalZeroDbContext : AbpZeroDbContext<Tenant, Role, User, VerticalZeroDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public VerticalZeroDbContext(DbContextOptions<VerticalZeroDbContext> options)
            : base(options)
        {
        }
    }
}
