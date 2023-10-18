
using System.ComponentModel.DataAnnotations;

namespace EmployeeLibrary.Models;

public class EmployeeModel
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Title { get; set; }
    public bool? Active { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public ShiftModel? ShiftModel { get; set; }
}
