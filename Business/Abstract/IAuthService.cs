using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<IndividualCustomerWithUserInfoDto> Register(UserRegisterForIndividualCustomerDto userRegisterForIndividualCustomer);
        IDataResult<User> Login(User user);
        IResult UserExist(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
        
    }
}
