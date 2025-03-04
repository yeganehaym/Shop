using DNTPersianUtils.Core;
using Mapster;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Mapster;

public class UserConfigs
{
    public static void AddConfigs()
    {
        TypeAdapterConfig<User, UserViewModel>
            .NewConfig()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");

        TypeAdapterConfig<UserViewModel, User>
            .NewConfig()
            .Map(dest => dest.BirthDate, src => src.BirthDate.ToGregorianDateTime(true, 1400))
            .Map(dest => dest.Password, src =>src.Password.Hash());
    }
}