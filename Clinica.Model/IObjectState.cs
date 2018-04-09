
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Model
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}