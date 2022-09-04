using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Utilities.CrossCuttingConcerns.Exceptions;

public class ValidationExceptionProblemDetails:ProblemDetails
{
    public object Errors { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}