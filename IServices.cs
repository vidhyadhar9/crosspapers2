using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.commonfol;
namespace StudentsManagementservice
{
    public interface IServices
    {
        public Task<List<Students>> GetAllstudents();
        public Task<bool> PostStudents(Students obj);

        public Task<bool>update(string studentId,string studentemail);

        public Task<bool> Delete(string studentId);
       
    }
}
