using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Application.Utilities.CrossCuttingConcerns.Exceptions;

public class AuthorizationExceptionProblemDetails:ProblemDetails
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}