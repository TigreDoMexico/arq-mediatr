using Microsoft.AspNetCore.Routing;

namespace ArqMediatr.Core.IoC;

public interface IEndpoint
{
    static abstract void MapEndpoint(IEndpointRouteBuilder endpoints);
}