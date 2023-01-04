using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API2.Models;

[Table("tb_m_profilings")]
public class Profiling
{
    [Key, Column("nik", TypeName = "nchar(5)")]
    public string NIK { get; set; }

    [Required, Column("education_id")]
    public int EducationId { get; set; }

    // Relation

    [JsonIgnore]
    [ForeignKey("EducationId")]
    public Education? Education { get; set; }
    [JsonIgnore]
    public Account? Account { get; set; }
}
