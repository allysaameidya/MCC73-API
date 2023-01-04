using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

namespace API2.Models;

[Table("tb_m_employees")]
public class Employee
{
    [Key, Column("nik", TypeName = "nchar(5)")]
    public string NIK { get; set; }

    [Required, Column("first_name"), MaxLength(50)]
    public string FirstName { get; set; }

    [Column("last_name"), MaxLength(50)]
    public string LastName { get; set; }

    [Required, Column("phone"), MaxLength(13)]
    public string Phone { get; set; }

    [Required, Column("birth_date")]
    public DateTime BirthDate { get; set; }

    [Required, Column("salary")]
    public int Salary { get; set; }

    [Required, Column("email"), MaxLength(50)]
    public string Email { get; set; }

    [Required, Column("gender")]
    public Jk Gender { get; set; }

    // Relation
    [JsonIgnore]
    public Account? Account { get; set; }
}
public enum Jk
{
    Male,
    Female
}
