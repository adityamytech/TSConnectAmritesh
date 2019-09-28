using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;

namespace BusinessAccessLayer
{
    public class SignUpBAL
    {
        SignUpDAL _signup = new SignUpDAL();
        public int Register(SignUpBO signup_BO_Object)
        {
            return _signup.SignUp(signup_BO_Object);
        }
    }
}
