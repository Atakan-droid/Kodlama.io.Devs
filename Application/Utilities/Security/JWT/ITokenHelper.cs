﻿using Domain.Entities;

namespace Application.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

}