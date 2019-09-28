using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer
{
    public class SuperUserBAL
    {
        SuperUserDAL _superUser = new SuperUserDAL();
        public DataSet ApprovalData()
        {
            return _superUser.ApprovalList();
        }
        public int AdminApproval(UserBO _approve)
        {
            return _superUser.UpdateAdmin(_approve);
        }

        public int AdminReject(UserBO _reject)
        {
            return _superUser.RejectAdmin(_reject);
        }
    }
}
