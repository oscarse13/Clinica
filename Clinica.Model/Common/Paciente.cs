using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Model.Common
{
    public class Paciente : Entity
    {
        [Key]
        [Column(Order = 10)]
        public long Id { get; set; }

        [Column(Order = 20)]
        [StringLength(100)]
        [Required(ErrorMessage = "El nombre del paciente es un campo requerido")]
        public string Nombre { get; set; }

        [Column(Order = 30)]
        [Required(ErrorMessage = "El documento del paciente es un campo requerido")]
        public int Documento { get; set; }

        [Column(Order = 40)]
        [Required(ErrorMessage = "La edad del paciente es un campo requerido")]
        public Int16 Edad { get; set; }

        [Column(Order = 50)]
        [StringLength(1)]
        [Required(ErrorMessage = "El sexo del paciente es un campo requerido")]
        public string Sexo { get; set; }
        
    }
}