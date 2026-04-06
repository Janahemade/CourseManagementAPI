using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _service;

    // Constructor (Dependency Injection)
    public StudentsController(StudentService service)
    {
        _service = service;
    }

    // GET: api/students
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _service.GetAll();
        return Ok(students);
    }

    // POST: api/students
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentCreateDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = await _service.Create(dto);
        return Ok(student);
    }
}