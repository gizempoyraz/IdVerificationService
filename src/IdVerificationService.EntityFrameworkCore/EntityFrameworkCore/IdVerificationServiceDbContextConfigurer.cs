using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IdVerificationService.EntityFrameworkCore
{
    public static class IdVerificationServiceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdVerificationServiceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IdVerificationServiceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
