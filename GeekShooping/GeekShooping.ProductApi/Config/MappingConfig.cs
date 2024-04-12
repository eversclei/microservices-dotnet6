using AutoMapper;
using GeekShooping.ProductApi.Data.ValueObjects;
using GeekShooping.ProductApi.Model;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GeekShooping.ProductApi.Config
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
