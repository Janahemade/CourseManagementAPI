using Microsoft.EntityFrameworkCore;

public class StudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudentReadDTO>> GetAll()
    {
        return await _context.Students
            .AsNoTracking()
            .Select(s => new StudentReadDTO
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
    }

    public async Task<Student> Create(StudentCreateDTO dto)
    {
        var student = new Student { Name = dto.Name };
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }
}