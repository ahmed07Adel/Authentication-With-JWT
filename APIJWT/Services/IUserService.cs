﻿using APIJWT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Services
{
   public interface IUserService
    {
        Task<UserManagerResponse> RegisterUser(RegisterViewModel model);
        Task<UserManagerResponse> LoginUser(LoginViewModel model);
        //Task CreateAdmin();
        //Task CreateRole();



    }
}
