using AutoMapper;
using Class_API.Model.Contracts;
using Class_API.Model.Entity;
using Class_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Class_API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class StudentController : ControllerBase
    {
        private readonly IBaseRepository<Student> _studentRepository;
        private readonly IMapper _mapper;


        public StudentController(IBaseRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetAll(a => a.Section);
            var allStudentDto = _mapper.Map<List<StudentDTO>>(students);
            return Ok(allStudentDto);
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetOneStudent(int id)
        {
            var student = await _studentRepository.Get(id, a => a.Section);
            if (student == null)
            {
                return NotFound();
            }
            var oneStudentDto = _mapper.Map<StudentDTO>(student);
            return Ok(oneStudentDto);
        }
        [HttpPost("student")]
        public async Task<IActionResult> CreateAStudent([FromBody] CreateStudent createStd)
        {
            var student = _mapper.Map<Student>(createStd);
            var createdStd = await _studentRepository.Add(student);
            var studentDto_created = _mapper.Map<StudentDTO>(createdStd);
            return CreatedAtAction(nameof(GetOneStudent), new { Id = studentDto_created.Id }, studentDto_created);
        }

        [HttpPut("student/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudent updateStd)
        {
            var student = await _studentRepository.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            _mapper.Map(updateStd, student);
            var updatedStudent = await _studentRepository.Update(student);
            var studentDto_updated = _mapper.Map<StudentDTO>(updatedStudent);
            return Ok(studentDto_updated);
        }

        [HttpDelete("student/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentRepository.Get(id);
            if (student == null)
            {
               return NotFound();   

            }

            var deletedStudent = await _studentRepository.Delete(id);
            var studentDto_deleted = _mapper.Map<StudentDTO>(deletedStudent);
            return Ok(studentDto_deleted);
        }
    }
}

