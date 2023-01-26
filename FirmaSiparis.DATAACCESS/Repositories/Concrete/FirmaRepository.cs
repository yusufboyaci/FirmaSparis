using FirmaSiparis.DATAACCESS.Context;
using FirmaSiparis.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.DATAACCESS.Repositories.Concrete
{
    public class FirmaRepository : Repository<Firma>
    {
        private readonly AppDbContext _context;
        public FirmaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
