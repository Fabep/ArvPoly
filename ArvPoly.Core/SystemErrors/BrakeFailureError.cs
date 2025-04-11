namespace ArvPoly.Core.SystemErrors;

public class BrakeFailureError : SystemError
{
    public override string ErrorMessage()
    {
        return "Brake Failure: The vehicle is dangerous to drive!";
    }
}
