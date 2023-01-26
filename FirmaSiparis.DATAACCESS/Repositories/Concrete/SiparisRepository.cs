using FirmaSiparis.DATAACCESS.Context;
using FirmaSiparis.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.DATAACCESS.Repositories.Concrete
{
    public class SiparisRepository : Repository<Siparis>
    {
        private readonly AppDbContext _context;
        public SiparisRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
