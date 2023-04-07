namespace QueryHub.Application.Features;

public class HandlerResponse<TEntity>
{
    public HandlerResponse(bool isSucceed, bool isInvalidData, string message, TEntity entity)
    {
        _isSucceed = isSucceed;
        _isInvalidData = isInvalidData;
        _message = message;
        _entity = entity;
    }

    private bool _isSucceed;
    private bool _isInvalidData;
    private string _message;
    private TEntity _entity;
}