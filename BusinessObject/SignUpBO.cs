using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SignUpBO
    {        
        public string UserId { get; set; }
        public string Password { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public int SecurityQuestionId { get; set; }
        public string SecurityAnswer { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}

