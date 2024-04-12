using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductApi.Model.Context
{
    public class SqlServeContext: DbContext
    {
        public SqlServeContext(){}
        public SqlServeContext(DbContextOptions<SqlServeContext> options) : base(options) { }
        public DbSet<ProductModel> Products { get; set; }
    }
}
