using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAppService.Business.Abstracts;
using SchoolAppService.Filters;
using SchoolAppService.Model;

namespace SchoolAppService.Controllers
{
    [ServiceFilter(typeof(TokenFilter))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase  
    {
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        /// <summary>
        /// Sınıf listesini getirir.
        /// </summary>
        /// <returns></returns>
        // GET api/GetAllClass
        [HttpGet("GetAllClass")]
        public ActionResult<List<Class>> GetAllClass()
        {
            return _schoolService.GetAllClass();
        }

        /// <summary>
        /// Öğrenci listesini getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllStudents")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return _schoolService.GetAllStudents();
        }

        
        [HttpGet("GetClassByID/{id}")]
       
        public Class GetClassByID(int id)
        {
            return _schoolService.GetClassByID(id);
        }

        [HttpGet("GetClassByName/{name}")]
        public Class GetClassByName(string name)
        {
            return _schoolService.GetClassByName(name);
        }

        [HttpGet("GetStudentByClass/{classID}")]
        public List<Student> GetStudentByClass(int classID)
        {
            return _schoolService.GetStudentByClass(classID);
        }

        [HttpGet("GetStudentByID/{id}")]
        public Student GetStudentByID(int id)
        {
            return _schoolService.GetStudentByID(id);
        }

        [HttpGet("GetStudentByName/{id}")]
        public Student GetStudentByName(string name)
        {
            return _schoolService.GetStudentByName(name);
        }


        /// <summary>
        /// Öğrenci ekler.
        /// </summary>
        /// <remarks>
        /// Örnek istek:
        ///
        ///     GET /AddStudent
        ///     {
        ///        "name": "Hakan",
        ///        "no": 423,
        ///        "gender": "Bay",
        ///        "age": 27,
        ///        "classID": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Yeni bir öprenci eklendi.</response>
        /// <response code="400">Eklenemedi</response>            
        /// <returns>Yeni bir öğrenci ekler..</returns>
        [HttpPost("AddStudent")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void AddStudent([FromBody] Student student)
        {
            _schoolService.AddStudent(student);
        }

        [HttpPost("AddClass")]
        public void AddClass([FromBody] Class _class)
        {
            _schoolService.AddClass(_class);
        }
    }
}