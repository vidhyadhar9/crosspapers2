using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagementservice;
using common.commonfol;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //constructor
        private readonly IServices _Service;

        public ValuesController(IServices Service)
        {
            _Service = Service;
        }
       
        [HttpGet]
        [Route(" GetStudentsA")]
        public async Task<List<Students>> GetStudentsA()
        {
            //Services serv1 = new Services();
            return await _Service.GetAllstudents();
        }


        [HttpPost]
        [Route("PostStudents")]
        public async Task<bool> PostStudents(Students obj)
        {
            return await _Service.PostStudents(obj);
        }


        [HttpPut]
        [Route("updateStudent")]
       public async Task<bool> updateStudent(string id,string email)
        {
            return await _Service.update(id,email);
        }

        [HttpDelete]
        [Route("Deletestudent")]
        public async Task<bool> DeleteStudent(string id) {

            return await _Service.Delete(id);

        }
       
    }
}
