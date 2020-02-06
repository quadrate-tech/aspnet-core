namespace Vertical.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly VerticalZeroDbContext _context;

        public InitialHostDbBuilder(VerticalZeroDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
