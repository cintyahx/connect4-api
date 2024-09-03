namespace Connect4.API.WebAPI.Common;

public abstract class ResponseGeneric<T>
{
    public T? Data { get; set; }

    public bool Succeeded { get; set; }

    public List<string> Errors { get; set; } = new ();

    public string? Message { get; set; }
}