using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Model.Common
{ 
    public class TipoCita : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 10)]
        public Int16 Id { get; set; }

        [Column(Order = 20)]
        [StringLength(50)]
        [Required(ErrorMessage = "La descripción del tipo de cita es un campo requerido")]
        public string Descripcion { get; set; }
    }
}