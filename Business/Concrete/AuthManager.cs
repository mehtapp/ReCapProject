using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        IIndividualCustomerService _individualCustomerService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IIndividualCustomerService individualCustomerService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _individualCustomerService = individualCustomerService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetClaims(user);   
            var token = _tokenHelper.CreateToken(user , operationClaims.Data);
            return new SuccessDataResult<AccessToken>(token, Messages.TokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotExist);
            }
            byte[] passwordHash;
            var verifyPassword = HashingHelper.VerifyPasswordHash(userForLoginDto.Password,  userToCheck.Data.PasswordHash , userToCheck.Data.PasswordSalt );
            if (!verifyPassword)
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data , Messages.SuccesfulLogin);
        }



        //tranasaction aspect'i şart
        public IDataResult<IndividualCustomerWithUserInfoDto> Register(UserRegisterForIndividualCustomerDto userRegisterForIndividualCustomer)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterForIndividualCustomer.Password, out passwordHash, out passwordSalt);
            //Kullanıcıyı kaydet user ve indivudual tablosuna
            User user = new User
            {
                UserName = userRegisterForIndividualCustomer.UserName,
                Email = userRegisterForIndividualCustomer.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true  //içerde atıyoruz.
            };
            IDataResult<User> userResult = _userService.AddUser(user);
            IndividualCustomer individualCustomer = new IndividualCustomer
            {
                UserId = userResult.Data.UserId,
                FirstName = userRegisterForIndividualCustomer.FirstName,
                LastName = userRegisterForIndividualCustomer.LastName
            };
            IDataResult<IndividualCustomer> customerResult = _individualCustomerService.AddIndividualCustomer(individualCustomer);

            if (!userResult.Success && customerResult.Success)
            {
                return new ErrorDataResult<IndividualCustomerWithUserInfoDto>(default, Messages.DefaultError);
            }
            IndividualCustomerWithUserInfoDto individualCustomerWithUserInfo =
                new IndividualCustomerWithUserInfoDto
                {
                    UserId = userResult.Data.UserId,
                    FirstName = customerResult.Data.FirstName,
                    LastName = customerResult.Data.LastName,
                    UserName = userResult.Data.UserName,
                    IndividualCustomerId = customerResult.Data.IndividualCustomerId,
                    Email = userResult.Data.Email,
                    Status = userResult.Data.Status
                };
            return new SuccessDataResult<IndividualCustomerWithUserInfoDto>(individualCustomerWithUserInfo, Messages.RegisterSuccessForIndividualCustomer);
        }


        public IResult UserExist(string email)
        {
            var result = _userService.GetByMail(email);
            if (!result.Success)
            {
                return new ErrorResult(Messages.UserNotExist);
            }
            return new SuccessResult(Messages.UserAlreadyExist);
        }
    }
}
