using AutoMapper;
using GeekShopping.ProductApi._2._0.Data.ValueObjects;
using GeekShopping.ProductApi._2._0.Model;

namespace GeekShooping.ProductApi._2._0.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration ResgisterMaps() {         
            var mappingConfig =  new MapperConfiguration(config => {
                config.CreateMap<ProductVO, ProductModel>();
                config.CreateMap<ProductModel, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
