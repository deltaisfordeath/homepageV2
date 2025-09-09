namespace homepageV2.Common;

public class Result<TValue>
{
    public TValue? Value { get; }
    public Error Error { get; }
    public bool IsSuccess { get; }

    private Result(TValue value)
    {
        IsSuccess = true;
        Value = value;
        Error = Error.None;
    }

    private Result(Error error)
    {
        IsSuccess = false;
        Value = default;
        Error = error;
    }

    public static Result<TValue> Success(TValue value) => new(value);
    public static Result<TValue> Failure(Error error) => new(error);
}