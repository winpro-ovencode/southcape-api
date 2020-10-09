using Microsoft.Extensions.Configuration;
using ServiceStack;
using ServiceStack.OrmLite;
using System;

namespace SouthCapeAPI
{
    public static class DataContextOptionsBuilderExtensions
    {
        public static DatabaseService UseOrmLite(this IServiceProvider optionsBuilder, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            DataContext.Setup(connectionString);
            return new DatabaseService();
        }
    }

    public class DataContext
    {
        static OrmLiteConnectionFactory factory;
        public static System.Data.IDbConnection Open()
        {
            var con = factory.CreateDbConnection();
            con.Open();
            return con;
        }

        internal static void Setup(string connectionString)
        {
            Licensing.RegisterLicense(
                    @"8271-e1JlZjo4MjcxLE5hbWU6d2lucHJvLFR5cGU6T3JtTGl0ZUluZGllLE1ldGE6
                    MCxIYXNoOkJRamJBV0J1bS95RGdKelcwcnZoelJod2NjRkFteEhEd2YxeGFxZEFkW
                    EtXZFJqekZMeHNybzlETEZpMFZqcWpxVkdTb1Y5THgwOWlFM0pzVHBRZjVtR1dRaH
                    FFUmpZWkJYWm5KelhUUGZqMS94cWN2QkdHVDBtbDY1NTZNS1JLcndQRHN3WTAzeHB
                    0ekdtVHFxRW1tS1NaTUtGV3lHNUNPeWw5amhZZU9jdz0sRXhwaXJ5OjIwMjEtMDYt
                    MDd9
                    ");

            factory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider); // ConnectionString
        }
    }

    public class DatabaseService
    {
    }
}
