using System.Security.Claims;

namespace Shop2;

public static class UserExtensions
{
    public static string GetName(this ClaimsPrincipal user)
    {
        var name = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

        if (name == null)
            return "";
        return name;
    }
    
    public static int? GetUserId(this ClaimsPrincipal user)
    {
        var name = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (name == null)
            return null;
        return int.Parse(name);
    }
}