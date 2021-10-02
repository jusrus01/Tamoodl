using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TamoodlApi.Data.Courses;
using TamoodlApi.Data.Students;
using TamoodlApi.Data.Teachers;
using TamoodlApi.Dtos;
using TamoodlApi.Dtos.Courses;
using TamoodlApi.Models;

namespace TamoodlApi.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersService _teachersService;
        private readonly IMapper _mapper;
        private readonly ICoursesService _coursesService;
        private readonly IStudentsService _studentsService;

        public TeachersController(
            ITeachersService teachersService,
            IMapper mapper,
            ICoursesService coursesService,
            IStudentsService studentsService)
        {
            _teachersService = teachersService;
            _mapper = mapper;
            _coursesService = coursesService;
            _studentsService = studentsService;
        }

        [HttpDelete("removeGrade")]
        public async Task<ActionResult<GradeReadDto>> RemoveGrade(RemoveGradeModel model)
        {
            if(model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var student = _studentsService.FindStudent(model.CourseName, model.StudentEmail);

            if(student == null)
            {
                return BadRequest("Could not find student");
            }

            var grade = _teachersService.RemoveGrade(model.Date, student);

            if(grade == null)
            {
                return BadRequest("Could not find given grade");
            }

            _teachersService.SaveChanges();

            return Ok(grade);
        }

        [HttpPost("create")]
        public async Task<ActionResult<CourseReadDto>> CreateCourse(CourseCreateDto courseCreateDto)
        {
            if(courseCreateDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = _mapper.Map<CourseCreateDto, CourseModel>(courseCreateDto);
            course.Date = DateTime.Now.ToString("yyyy-MM-dd");
            
            var result = await _coursesService.AddCourse(course);

            if(result == null)
            {
                return NoContent();
            }

            _teachersService.SaveChanges();

            return Ok(_mapper.Map<CourseModel, CourseReadDto>(course));
        }

        [HttpPost("addStudent")]
        public async Task<ActionResult<StudentModel>> AddStudent(StudentModel addModel)
        {
            if(!ModelState.IsValid || addModel == null)
            {
                return BadRequest();
            }

            var course = _coursesService.FindCourseByName(addModel.CourseName);
            
            if(course == null)
            {
                return BadRequest("Such course does not exist");
            }

            var updatedStudent = await _studentsService.AddStudent(addModel);

            if(updatedStudent == null)
            {
                return NoContent();
            }
            
            _coursesService.SaveChanges();
            
            return Ok(addModel);
        }

        [HttpPost("addGrade")]
        public async Task<ActionResult<StudentModel>> AddGrade(AddGradeModel model)
        {
            if(!ModelState.IsValid || model == null)
            {
                return BadRequest();
            }

            var updatedStudent = await _teachersService.AddGrade(model);
            
            if(updatedStudent == null)
            {
                return NoContent();
            }

            return updatedStudent;
        }
    }
}