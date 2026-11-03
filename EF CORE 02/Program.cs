using Microsoft.EntityFrameworkCore;

namespace EF_CORE_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using EventHubContext context = new EventHubContext();

            context.Database.Migrate();

            Console.WriteLine($"Database created: {context.Database.CanConnect()}");
            Console.WriteLine($"Database name   : {context.Database.GetDbConnection().Database}");
            Console.WriteLine();

            foreach (var entityType in context.Model.GetEntityTypes())
            {
                Console.WriteLine($"Table: {entityType.GetTableName()}");

                foreach (var p in entityType.GetProperties())
                    Console.WriteLine($"    {p.GetColumnName()} ({p.ClrType.Name}) {(p.IsPrimaryKey() ? "[PK]" : "")}");

                foreach (var fk in entityType.GetForeignKeys())
                    Console.WriteLine($"   FK: {string.Join(",", fk.Properties.Select(p => p.Name))} -> {fk.PrincipalEntityType.GetTableName()}");

                Console.WriteLine();
            }
        }
    }
}
