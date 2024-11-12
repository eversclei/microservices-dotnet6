using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi._2._0.Model.Context
{
    public class SqlServerContext: DbContext
    {
        public SqlServerContext(){}
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }
        public DbSet<ProductModel> Products { get; set; }

    }
}
