using System;

namespace Etapa8.Entities
{
    public abstract class BaseObject
    {
        public BaseObject() => Id = Guid.NewGuid().ToString();
        
        public string Id { get; private set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Id}";
        }

    }
}