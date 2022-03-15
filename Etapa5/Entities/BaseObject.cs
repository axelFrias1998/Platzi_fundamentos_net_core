using System;

namespace Etapa5.Entities
{
    public abstract class BaseObject
    {
        public BaseObject() => Id = Guid.NewGuid().ToString();
        
        public string Id { get; private set; }

        public string Name { get; set; }
    }
}