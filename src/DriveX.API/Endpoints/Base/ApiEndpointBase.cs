namespace DriveX.API.Endpoints.Base;

/// <summary>
/// Base class for other endpoint types that contains common members
/// </summary>
public abstract class ApiEndpointBase
{
    public abstract string RequestPath { get; }

    public abstract HttpMethod MapMethod { get; }

    public abstract RouteHandlerBuilder Configure(RouteHandlerBuilder routeBuilder);

    public abstract Delegate RequestHandler { get; }
}