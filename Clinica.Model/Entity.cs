using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Clinica.Model
{
    public abstract class Entity : IObjectState
    {


        public Entity()
        {
            ObjectState = ObjectState.Unchanged;
        }
      
        [NotMapped]
        public ObjectState ObjectState { get; set; }

    }
}