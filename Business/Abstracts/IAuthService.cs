using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    AccessToken Login(UserForLoginDto userForLoginDto);
    AccessToken Register(UserForRegisterDto userForRegisterDto);
    AccessToken CreateAccessToken(User user);
}
