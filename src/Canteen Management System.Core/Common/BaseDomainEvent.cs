using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Common
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
