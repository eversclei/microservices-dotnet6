using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductApi.Model.Context
{
    public class SqlServerContext: DbContext
    {
        public SqlServerContext(){}
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }
        public DbSet<ProductModel> Products { get; set; }

    }
}
