using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
   public class UserBAL
    {
        UserDAL _document = new UserDAL();
        public int AddDocuments(DocumentBO _addDocument)
        {
            return _document.AddDocument(_addDocument);
        }
        public DataTable AdvanceSearchTable(string keywordId,string keyword)
        {
            return _document.AdvanceSearch(keywordId,keyword);
        }
        public DataTable ScheduleTable()
        {
            return _document.ScheduleTable();
        }

        public int AddScheduleBAL(DocumentBO docBO,ScheduleBO schBO)
        {
            return _document.AddSchedule(docBO, schBO);
        }
        public DataTable ListSkillsBal()
        {
            return _document.ListSkills();
        }
        public DataTable MapSkillListBAL(string skillName)
        {
            return _document.MapSkillList(skillName);
        }

        public DataTable UserDocument(bool archiveStatus)
        {
            return _document.DocList(archiveStatus);
        }

        public DataTable UserDocumentDisplay(UserBO _display)
        {
            return _document.DocDisplay(_display);
        }

        public DataTable StudentTeacherDetailsDisplay(UserBO _display)
        {
            return _document.Student_Teacher_ListDisplay(_display);
        }

        public DataTable TeacherDetailsDisplay(UserBO _display)
        {
            return _document.Teacher_DataDisplay(_display);
        }

        public DataTable StudentDetailsDisplay(UserBO _display)
        {
            return _document.Student_DataDisplay(_display);
        }

        public DataRow UserProfile(UserBO _display)
        {
            return _document.UserProfile(_display);
        }

        public int EditProfileUser(UserBO _display)
        {
            return _document.EditUser(_display);
        }

        public int ArchiveDocument(int docId,bool archive)
        {
            return _document.ArchiveDocument(docId, archive);
        }

        public int Enroll(UserBO _display)
        {
            return _document.Enroll(_display);
        }

        public DataTable ScheduleTeacher(UserBO _display)
        {
            return _document.ScheduleTeacher(_display);
        }

        public DataTable ScheduleStudent(UserBO _display)
        {
            return _document.ScheduleStudent(_display);
        }
    }
}
