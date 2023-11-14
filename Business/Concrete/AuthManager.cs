using Business.Abstract;
using Business.Constants;
using Core.Classes.JWT;
using Core.Classes;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Business;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        IUserDal _userDal;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserDal userDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userDal = userDal;
        }
        // [SecuredOperation("admin")]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            //byte[] passwordHash, passwordSalt;
            //HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            string md5Password = Encrypt.MD5Encrypt(password);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Password = md5Password,
                Status = true
                // bu şekilde db ve kodu güncelleyebilirsin
            };
            _userService.Add(user);
            return new SuccesDataResult<User>(user, Messages.UserRegistered);
        }
        public IDataResult<List<User>> GetList()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll().ToList());
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUserName(userForLoginDto.userName);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.password, userToCheck.Password))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccesDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string userName)
        {
            if (_userService.GetByUserName(userName) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccesResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccesDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
        public UserInfoWithToken CreateAccessToken_New(User user, IConfiguration configuration)
        {
            //var claims = _userService.GetClaims(user);
            //var accessToken = _tokenHelper.CreateToken(user, claims);
            string secretSection = configuration.GetSection("AppSettings").GetSection("Secret").Value;
            //
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("userName", user.UserName));
            claims.Add(new Claim("name", user.FirstName));
            claims.Add(new Claim("role", Role.Admin));
            claims.Add(new Claim("surname", user.LastName));

            string token = GenerateToken.Generate(new TokenDescriptor
            {
                Claims = claims.ToArray(),
                ExpiresValue = DateTime.UtcNow.AddDays(1),
                Secret = secretSection
            });

            return new UserInfoWithToken
            {
                Token = token,
                Role = Role.Admin,
                Username =user.UserName,
                //Name = kullaniciDetay.Ad,
                //Surname = kullaniciDetay.Soyad == null ? "" : kullaniciDetay.Soyad,
                KullaniciId = user.Id
            };
        }
        public IResult Update(User user)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _userDal.Update(user);
            return new SuccesResult(Messages.UserRegistered);
        }
        public IResult Delete(User user)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _userDal.Delete(user);
            return new SuccesResult(Messages.UserNotFound);
        }
    }
}
