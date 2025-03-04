using Mapster;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Mapster;

public class ProductConfigs
{
    public static void AddConfigs()
    {
        TypeAdapterConfig<Product, ProductViewModel>
            .NewConfig()
            .Map(dest => dest.CategoryId, src => 1);


    }
}