namespace DriveX.API.Endpoints.Base;

public abstract class ApiEndpoint<TRequest, TResponse> : ApiEndpointBase
{
    public sealed override Delegate RequestHandler => Handle;

    protected abstract TResponse Handle(TRequest request);
}

public abstract class ApiEndpoint<TParam1, TParam2, TResponse> : ApiEndpointBase
{
    public sealed override Delegate RequestHandler => Handle;

    protected abstract TResponse Handle(TParam1 param1, TParam2 param2);
}

public abstract class ApiEndpoint<TParam1, TParam2, TParam3, TResponse> : ApiEndpointBase
{
    public sealed override Delegate RequestHandler => Handle;

    protected abstract TResponse Handle(TParam1 param1, TParam2 param2, TParam3 param3);
}
