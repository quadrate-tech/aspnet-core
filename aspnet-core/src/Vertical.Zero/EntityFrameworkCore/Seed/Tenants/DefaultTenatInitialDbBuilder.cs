using Vertical.EntityFrameworkCore.Seed.Tenants;

namespace Vertical.EntityFrameworkCore.Seed.Host
{
    public class DefaultTenatInitialDbBuilder
    {
        private readonly VerticalZeroDbContext _context;

        public DefaultTenatInitialDbBuilder(VerticalZeroDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultTenantBuilder(_context).Create();
            new DefaultTenantRoleAndUserBuilder(_context, 1).Create();

            _context.SaveChanges();
        }
    }
}
