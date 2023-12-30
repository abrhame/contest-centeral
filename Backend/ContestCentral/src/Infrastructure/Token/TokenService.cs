using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Domain.Common.Entity;

namespace ContestCentral.Infrastructure.Tokens;

public class TokenService : ITokenService {
	private readonly byte[] _tokenSecret;
	private readonly string _issuer;
	private readonly string _audience;

	public TokenService(IOptions<TokenSettings> tokenSettings) {
		_tokenSecret = Encoding.ASCII.GetBytes(tokenSettings.Value.Secret);
		_issuer = tokenSettings.Value.Issuer;
		_audience = tokenSettings.Value.Audience;
	}

	public string GenerateAccessToken(User user) {
		var tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new ClaimsIdentity(
				new[] {
					new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(JwtRegisteredClaimNames.Email, user.Email),
					new Claim(JwtRegisteredClaimNames.Iat, DateTime.UnixEpoch.ToString(), ClaimValueTypes.Integer64), 
					new Claim(ClaimTypes.NameIdentifier, user.UserName),
					new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(ClaimTypes.Role, user.Role.ToString()),
				}
			),

			Expires = DateTime.UtcNow.AddMinutes(15),
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(_tokenSecret),
				SecurityAlgorithms.HmacSha256Signature
			),
			Issuer = _issuer,
			Audience = _audience,
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}

	public string GenerateRefreshToken() {
		var tokenId = Guid.NewGuid();
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new ClaimsIdentity(new[] { new Claim(JwtRegisteredClaimNames.Jti, tokenId.ToString()), }),
			Expires = DateTime.UtcNow.AddDays(14),
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(_tokenSecret),
				SecurityAlgorithms.HmacSha256Signature
			),
			Issuer = _issuer,
			Audience = _audience,
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}

	public string GenerateConfirmationToken(User user) {
		var descriptor = DateTime.UnixEpoch + user.Email + user.GetHashCode();
		var hash = new HMACSHA256(Encoding.UTF8.GetBytes(descriptor));

		return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(user.Email)));
	}

	public string ValidateToken(string token) {
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = _tokenSecret;

		tokenHandler.ValidateToken(token, new TokenValidationParameters {
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidIssuer = _issuer,
			ValidAudience = _audience,
			ValidateLifetime = true,
		}, out SecurityToken validatedToken);

		if ( !(validatedToken is JwtSecurityToken jwtToken) || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase) ) {
			throw new SecurityTokenException("Invalid token");
		}

		if ( jwtToken.ValidTo < DateTime.UtcNow ) {
			throw new SecurityTokenException("Token expired");
		}

		return jwtToken.Claims.First(x => x.Type == "jti").Value;
	}
}
