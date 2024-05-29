using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repository.Interfaces
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
