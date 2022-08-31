namespace BunnyNet;

public class Result
{
    internal Result()
    {
    }
    
    internal ResultStatus Status { get; private set; }

    internal string ErrorDetail { get; private set; }

    public static Result Ok()
    {
        return new Result
        {
            Status = ResultStatus.Ok
        };
    }

    public static Result Error(string errorDetail)
    {
        return new Result
        {
            Status = ResultStatus.Error,
            ErrorDetail = errorDetail
        };
    }

    public static Result Retry(object todo)
    {
        return new Result
        {
            Status = ResultStatus.Retry
        };
    }
}