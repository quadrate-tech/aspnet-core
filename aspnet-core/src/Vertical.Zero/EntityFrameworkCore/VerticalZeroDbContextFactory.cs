using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Vertical.Configuration;
using Vertical.Web;

namespace Vertical.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class VerticalZeroDbContextFactory : IDesignTimeDbContextFactory<VerticalZeroDbContext>
    {
        public VerticalZeroDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VerticalZeroDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            VerticalZeroDbContextConfigurer.Configure(builder, configuration.GetConnectionString(VerticalConsts.ConnectionStringName));

            return new VerticalZeroDbContext(builder.Options);
        }
    }
}
