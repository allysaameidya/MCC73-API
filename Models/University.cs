using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API2.Models;

[Table("tb_m_universities")]
public class University
{

    [Key, Column("id")]
    public int Id { get; set; }

    [Required, Column("name"), MaxLength(70)]
    public string Name { get; set; }

    // Relation
    [JsonIgnore]
    public ICollection<Education>? Educations { get; set; }
}
