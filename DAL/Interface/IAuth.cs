﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAuth<RET,CLASS>
    {
         RET Authenticate(CLASS obj);
        bool isAuthenticate(string obj);

        bool Logout(string obj);
    }
}
