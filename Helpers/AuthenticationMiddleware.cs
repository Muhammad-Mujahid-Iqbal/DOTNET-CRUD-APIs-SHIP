namespace WebApi.Helpers;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

public class AuthenticationrMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationrMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
     // get headers from request
        var headers  = context.Request.Headers;
        StringValues token;
        // check if headers contain token
        if (!headers.TryGetValue("token",out token))
        {
            throw new AppException("No Authentication token provided in headers.");
        }
       
        // throw exception if token does not match
        if (token != "mujahid-4565xgfh-tykk45-12")
        {
            throw new AppException("Invalid Authentication Token.");
        }

        await _next(context);       
    }
}
