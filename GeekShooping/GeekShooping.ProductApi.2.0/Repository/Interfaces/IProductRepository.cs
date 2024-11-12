
using GeekShopping.ProductApi._2._0.Data.ValueObjects;

namespace GeekShooping.ProductApi._2._0.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long Id);
        Task<ProductVO> Create(ProductVO product);
        Task<ProductVO> Update(ProductVO product);
        Task<bool> Delete(long Id);
    }
}
