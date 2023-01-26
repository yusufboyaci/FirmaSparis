using FirmaSiparis.CORE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.CORE.Entity
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public BaseEntity()
        {
            Status = Status.None;
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
