namespace Connect4.API.WebAPI.Common;

public class Response : ResponseGeneric<object>
{
    public Response()
    {
    }

    public Response(object data)
    {
        Succeeded = true;
        Message = string.Empty;
        Data = data;
    }

    public Response(object data, string message)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
}