using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessObject;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class AdminBAL
    {
      //D   
        AdminDAL _resources = new AdminDAL();
        public int AdminAddResources(AdminBO _addResources)
        {
            return _resources.AddResources(_addResources);
        }

        public int AdminAddSkill(AdminBO _addNewSkill)
        {
            return _resources.AddNewSkills(_addNewSkill);
        }

        public int AdminAddResourceSkill(AdminBO _addResourceSkill)
        {
            return _resources.AddResourceSkill(_addResourceSkill);
        }

        public DataTable AdminSkillList()
        {
            return _resources.SkillList();
        }

        public void AdminDeleteList(AdminBO _deleteList)
        {
            _resources.DeleteList(_deleteList);
        }

        public DataTable AdminResourceTable()
        {
            return _resources.ResourceList();
        }

        public DataTable AdminSkillData(AdminBO _skillData)
        {
            return _resources.SkillData(_skillData);
        }
        public int AdminSkillMapping(AdminBO _mapping)
        {
            return _resources.SkillMapping(_mapping);

        }
        public int AdminAddNewSkill(AdminBO _addNewSkill)
        {
            return _resources.AddNewSkills(_addNewSkill);
        }
        public int AdminDeleteResource(AdminBO _delete)
        {
            return _resources.DeleteResource(_delete);
        }
       

    }
}
