namespace ArvPoly.Core.SystemErrors;

public class EngineFailureError : SystemError
{
    public override string ErrorMessage()
    {
        return "Engine Failure: Control the engine status!";
    }
}
