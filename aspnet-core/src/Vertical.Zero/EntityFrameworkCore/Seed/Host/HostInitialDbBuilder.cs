namespace Vertical.EntityFrameworkCore.Seed.Host
{
    public class HostInitialDbBuilder
    {
        private readonly VerticalZeroDbContext _context;

        public HostInitialDbBuilder(VerticalZeroDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
