using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GeekShopping.ProductApi.Config
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
