using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;
using System.Data;

namespace BusinessAccessLayer
{
    public class SignInBAL
    {
        SignInDAL _signIn = new SignInDAL();
        public DataRow LogIn(SignInBO signIn_BO_Object)
        {
            return _signIn.SignIn(signIn_BO_Object);
        }

        public DataRow Image(SignInBO signIn_BO_Object)
        {
            return _signIn.ImageDisplay(signIn_BO_Object);
        }

    }



}
