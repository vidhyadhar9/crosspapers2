using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.commonfol;

namespace StudentsqlRepo
{
    public interface IRepo
    {

        public Task<List<Students>> GetAll();
        public Task<bool> PostStudents(Students students);

        public Task<bool> update(string studentid, string studentemail);

        public Task<bool> Delete(string studentid);
    }
}
