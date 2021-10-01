using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TamoodlApi.Data.Courses;
using TamoodlApi.Data.Students;
using TamoodlApi.Data.Teachers;
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
        private ICoursesService _coursesService;
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

        [HttpPost("create")]
        public async Task<ActionResult<CourseReadDto>> CreateCourse(CourseCreateDto courseCreateDto)
        {
            if(courseCreateDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = _mapper.Map<CourseCreateDto, CourseModel>(courseCreateDto);
            // course.CreationDate = DateTime.Now;
            
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

            // var updatedCourse = await _teachersService.AddStudent(course, addModel);
            var updatedStudent = _teachersService.AddGrade(model);
            
            if(updatedStudent == null)
            {
                return NoContent();
            }

            // _teachersService.SaveChanges();

            return updatedStudent;
        }
    }
}