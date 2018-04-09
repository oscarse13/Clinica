using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Model.Common
{
    public class Cita : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 10)]
        public long Id { get; set; }

        [Required]
        [ForeignKey("TipoCita")]
        [Display(Name = "TipoCita", Prompt = "TipoCita", Order = 20)]
        [Column(Order = 20)]
        public Int16 TipoCitaId { get; set; }
        public virtual TipoCita TipoCita { get; set; }

        [Required]
        [ForeignKey("Paciente")]
        [Display(Name = "Paciente", Prompt = "Paciente", Order = 30)]
        [Column(Order = 30)]
        public long PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        [Column(Order = 40)]
        public DateTime Fecha { get; set; }        

    }
}