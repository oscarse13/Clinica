using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Model.Common
{
    public class Usuario : Entity
    {
        [Key]
        [Column(Order = 10)]
        public long Id { get; set; }

        [Column(Order = 20)]
        [StringLength(100)]
        [Required(ErrorMessage = "El nombre del usuario es un campo requerido")]
        public string Nombre { get; set; }

        [Column(Order = 30)]
        [StringLength(100)]
        [Required(ErrorMessage = "El nombre de usuario del usuario es un campo requerido")]
        public string NombreUsuario { get; set; }

        [Column(Order = 40)]
        [StringLength(100)]
        [Required(ErrorMessage = "El Correo del paciente es un campo requerido")]
        public string Correo { get; set; }

        [Column(Order = 50)]
        [StringLength(100)]
        [Required(ErrorMessage = "La contraseña del paciente es un campo requerido")]
        public string Contrasena { get; set; }

        [Column(Order = 60)]
        [StringLength(100)]
        [Required(ErrorMessage = "El rol del paciente es un campo requerido")]
        public string Rol { get; set; }

    }
}
