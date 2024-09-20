namespace Connect4.API.WebAPI.Common;

public class Response : ResponseGeneric<object>
{
    public Response(object data)
    {
        Succeeded = true;
        Message = string.Empty;
        Data = data;
    }
}