using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using GeekShopping.ProductApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly SqlServerContext _context;
        private IMapper _mapper;
        public ProductRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<ProductModel> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long Id)
        {
            ProductModel product = await _context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync()?? new ProductModel();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO productVo)
        {
            ProductModel product = _mapper.Map<ProductModel>(productVo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO productVo)
        {
            ProductModel product = _mapper.Map<ProductModel>(productVo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long Id)
        {
            try
            {
                ProductModel product = await _context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync() ?? new ProductModel();
                if (product.Id <= 0) {
                    return false;
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
