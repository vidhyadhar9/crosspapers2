using StudentsqlRepo;
using common.commonfol;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsManagementservice
{
    public class Services : IServices
    {
        private readonly IRepo _Repo;

        public Services(IRepo repo)
        {
            _Repo = repo;
        }

        public async Task<List<Students>> GetAllstudents()
        {
            List<Students> students = await _Repo.GetAll();

            // Ensure students is not null before returning
            return students ?? new List<Students>();
        }

        public async Task<bool> PostStudents(Students student)
        {
            return await _Repo.PostStudents(student);
        }

        public async Task<bool> update(string studentid,string studentemail)
        {
            return await _Repo.update(studentid, studentemail);
        }

        public async Task<bool>Delete(string studentid) {
            return await _Repo.Delete(studentid);
        }
    }
}
