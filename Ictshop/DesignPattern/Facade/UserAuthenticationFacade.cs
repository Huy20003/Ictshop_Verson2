using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ictshop.Models;

namespace Ictshop.DesignPattern.Facade
{
    public class UserAuthenticationFacade: IUserAuthentication
    {
        private Model1 db;

    public UserAuthenticationFacade(Model1 dbContext)
    {
        db = dbContext;
    }

    public bool Authenticate(string email, string password)
    {
        var islogin = db.Nguoidungs.SingleOrDefault(x => x.Email.Equals(email) && x.Matkhau.Equals(password));
        return islogin != null;
    }
}
}