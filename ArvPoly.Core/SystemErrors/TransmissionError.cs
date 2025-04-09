namespace ArvPoly.Core.SystemErrors;

public class TransmissionError : SystemError
{
    public override string ErrorMessage()
    {
        return "Transmission Error: Reperation is needed!";
    }
}
