﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API2.Models;

[Table("tb_m_educations")]
public class Education
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Required, Column("degree"), MaxLength(25)]
    public string Degree { get; set; }

    [Required, Column("gpa"), MaxLength(5)]
    public string GPA { get; set; }

    [Required, Column("university_id")]
    public int UniversityId { get; set; }

    // Relation
    [JsonIgnore]
    [ForeignKey("UniversityId")]
    public University? University { get; set; }
    [JsonIgnore]
    public Profiling? Profiling { get; set; }
}
