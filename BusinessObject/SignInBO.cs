using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SignInBO
    {
        public SignInBO() { }
        public SignInBO(string id, string password)
        {
            this.userId = id;
            this.userPassword = password;
        }


        private string id;

        public string userId
        {
            get { return id; }
            set { id = value; }
        }

        //private string id;

        //public string userId
        //{
        //    get { return userId; }
        //    set { userId = value; }
        //}


        private string password;

        public string userPassword
        {
            get { return password; }
            set { password = value; }
        }

  
        //private string password;

        //public string userPassword
        //{
        //    get { return userPassword; }
        //    set { userPassword = value; }
        //}

        //    private string firstName;

        //    public int userFirstName
        //    {
        //        get { return userFirstName; }
        //        set { userFirstName = value; }
        //    }

        //    private string lastName;

        //    public int userLastName
        //    {
        //        get { return userLastName; }
        //        set { userLastName = value; }
        //    }

        //    private int Id;

        //    public int roleId
        //    {
        //        get { return roleId; }
        //        set { roleId = value; }
        //    }

        //    private string type;

        //    public int roleType
        //    {
        //        get { return roleType; }
        //        set { roleType = value; }
        //    }

        //    private int age;

        //    public int userAge
        //    {
        //        get { return userAge; }
        //        set { userAge = value; }
        //    }

        //    private string gender;

        //    public string userGender
        //    {
        //        get { return userGender; }
        //        set { userGender = value; }
        //    }

        //    private int contact;

        //    public int userContact
        //    {
        //        get { return userContact; }
        //        set { userContact = value; }
        //    }

        //    private byte image;

        //    public byte userImage
        //    {
        //        get { return userImage; }
        //        set { userImage = value; }
        //    }

        //    private int questionId;

        //    public int securityQuestionId
        //    {
        //        get { return securityQuestionId; }
        //        set { securityQuestionId = value; }
        //    }

        //    private string answer;

        //    public string securityAnswer
        //    {
        //        get { return securityAnswer; }
        //        set { securityAnswer = value; }
        //    }
        //}
        //public class SignInBO { }
    }
}