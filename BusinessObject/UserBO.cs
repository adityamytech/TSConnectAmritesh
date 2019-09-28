using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserBO
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
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
        public int DocumentId { get; set; }
        public string description { get; set; }
        public string Image { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string BatchId { get; set; }
    }

    public class Session
    {
        public int Session_CategoryId { get; set; }
        public string Session_UserId { get; set; }
        public string Session_FirstName { get; set; }
    }
    public class DocumentBO
    {
        public string ResourceId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
        public int Year { get; set; }
        public string CoverPage { get; set; }
        public string File { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }
        public string Description { get; set; }
    }
    public class ScheduleBO
    {
        public DateTime StartFrom { get; set; }
        public DateTime EndOn { get; set; }
        public string TimeSlot { get; set; }
        public string BatchId { get; set; }
        public string Subject { get; set; }
    }
}
