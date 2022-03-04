using System;

namespace Etapa4.Entities
{
    public class Class
    {
        public Class() => ClassId = Guid.NewGuid().ToString();
        
        public string ClassId { get; private set; }

        public string Name { get; set; }
    }
}