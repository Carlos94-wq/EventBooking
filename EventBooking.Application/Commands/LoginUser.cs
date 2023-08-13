using EventBooking.Domain.CustomEntities;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventBooking.Application.Commands
{
    public class LoginUser
    {
        public record Command(string UserName, string Password): IRequest<(Users User, string token)>;

        public class Handler : IRequestHandler<Command, (Users User, string token)>
        {
            private readonly IUserRepository _repository;
            private readonly TokenConfigure _configure;

            public Handler(IUserRepository repository, IOptions<TokenConfigure> configure)
            {
                _repository = repository;
                _configure = configure.Value;
            }

            public async Task<(Users User, string token)> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _repository.AuthenticateUser(request.UserName, request.Password);
                var token = string.Empty;
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.PrimarySid,user.UserID.ToString()),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configure.secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(
                    _configure.issuer,
                    _configure.audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(_configure.accessExpiration),
                    signingCredentials: credentials);

                token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                return (user, token);
            }
        }
    }
}
