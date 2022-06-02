﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dep.App.Security.Entities;

//[Table("Genero")]
public class Genre : EntityBase
{
    [StringLength(50)]
    [Required]
    public string Description { get; set; }
}
