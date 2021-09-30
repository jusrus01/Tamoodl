using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TamoodlApi.Data.Courses;
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

        public TeachersController(ITeachersService teachersService, IMapper mapper, ICoursesService coursesService)
        {
            _teachersService = teachersService;
            _mapper = mapper;
            _coursesService = coursesService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CourseReadDto>> CreateCourse(CourseCreateDto courseCreateDto)
        {
            if(courseCreateDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = _mapper.Map<CourseCreateDto, CourseModel>(courseCreateDto);
            course.CreationDate = DateTime.Now;
            
            bool result = await _teachersService.CreateCourse(course);

            if(result)
            {
                _teachersService.SaveChanges();

                return Ok(_mapper.Map<CourseModel, CourseReadDto>(course));
            }

            return NoContent();
        }

        [HttpPost("addStudent")]
        public async Task<ActionResult<StudentModel>> AddStudent(StudentAddModel addModel)
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

            var updatedCourse = await _teachersService.AddStudent(course, addModel);

            if(_coursesService.UpdateCourse(updatedCourse))
            {
                _coursesService.SaveChanges();
                return Ok(addModel);
            }

            return NoContent();
        }

        [HttpPost("addGrade")]
        public async Task<ActionResult<StudentModel>> AddGrade(AddGradeModel model)
        {
            if(!ModelState.IsValid || model == null)
            {
                return BadRequest();
            }

            // var updatedCourse = await _teachersService.AddStudent(course, addModel);
            if(_teachersService.AddGrade(model))
            {
                
            }

            return NoContent();
        }
    }
}