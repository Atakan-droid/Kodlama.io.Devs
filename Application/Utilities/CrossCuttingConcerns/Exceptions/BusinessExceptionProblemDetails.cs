using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Utilities.CrossCuttingConcerns.Exceptions;

public class BusinessExceptionProblemDetails:ProblemDetails
{
    public override string ToString()=>JsonConvert.SerializeObject(this);

}