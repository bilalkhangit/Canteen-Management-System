using Canteen_Management_System.Core.Common;
using System.Collections.Generic;

namespace Canteen_Management_System.Core.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}