using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> register();
        IDataResult<User> login(User user);
        IResult userExist();

        //IDataResult<AccessToken> CreateAccessToken(User user);
        
    }
}
