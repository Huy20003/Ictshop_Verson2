using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Facade
{
    public interface IUserAuthentication
    {
        bool Authenticate(string email, string password);
    }
}