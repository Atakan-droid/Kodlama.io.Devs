using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Utilities.Encryption;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Utilities.Security.JWT;

public class JwtHelper:ITokenHelper
{
    public IConfiguration Configuration { get; }
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }
    
    public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
    {
       _accessTokenExpiration=DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
       SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
       SigningCredentials credentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
       JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, credentials, operationClaims);
       string? token = new JwtSecurityTokenHandler().WriteToken(jwt);

       return new AccessToken()
       {
           Token = token,
           Excepiration = _accessTokenExpiration
       };
    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
        SigningCredentials signingCredentials,
        IList<OperationClaim> operationClaims)
    {
        JwtSecurityToken jwt = new(
            tokenOptions.Issuer,
            tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(user, operationClaims),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user, IList<OperationClaim> operationClaims)
    {
        List<Claim> claims = new();
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.LastName));
        return claims;
    }
}