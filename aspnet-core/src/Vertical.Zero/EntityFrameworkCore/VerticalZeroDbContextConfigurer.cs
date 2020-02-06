using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Vertical.EntityFrameworkCore
{
    internal static class VerticalZeroDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<VerticalZeroDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<VerticalZeroDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
