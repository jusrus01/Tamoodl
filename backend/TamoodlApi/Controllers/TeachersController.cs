using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public TeachersController(ITeachersService teachersService, IMapper mapper)
        {
            _teachersService = teachersService;
            _mapper = mapper;
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
            
            await _teachersService.CreateCourse(course);
            _teachersService.SaveChanges();

            return Ok(_mapper.Map<CourseModel, CourseReadDto>(course));
        }
    }
}