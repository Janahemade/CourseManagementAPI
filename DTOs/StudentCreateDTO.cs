using System.ComponentModel.DataAnnotations;

public class StudentCreateDTO
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}