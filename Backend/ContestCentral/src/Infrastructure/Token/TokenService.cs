using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

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

	public (Guid, string) GenerateRefreshToken() {
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
		return (tokenId, tokenHandler.WriteToken(token));
	}

	public Guid? ValidateToken(string refreshtoken, out Guid tokenId) {
		var tokenHandler = new JwtSecurityTokenHandler();

		var tokenValidationParams = new TokenValidationParameters {
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(_tokenSecret),
			ValidateIssuer = true,
			ValidateAudience = true,
			ClockSkew = TimeSpan.Zero,
			ValidAudience = _audience,
			ValidIssuer = _issuer,
		};

		try {
			tokenHandler.ValidateToken(refreshtoken, tokenValidationParams, out SecurityToken token);
			var jwt = (JwtSecurityToken)token;
			var valid = Guid.TryParse(jwt.Id, out var id);
			tokenId = id;
			var accountId = jwt.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
			return Guid.Parse(accountId);
		}
		catch (Exception) {
			tokenId = default;
			return null;
		}
	}

	public string GenerateVerificationToken(User user) {
		var randomVal = user.Id.ToString() + user.Email + user.UserName + user.FirstName + user.LastName;
		var userHash = Convert.ToHexString(Encoding.ASCII.GetBytes(randomVal)) + Guid.NewGuid().ToString() + DateTime.UnixEpoch.ToString();
		var token = SHA256.HashData(Encoding.ASCII.GetBytes(userHash));
		return Convert.ToHexString(token);
	}
}
