using FirmaSiparis.DATAACCESS.Context;
using FirmaSiparis.DATAACCESS.Repositories.Concrete;
using FirmaSiparis.ENTITIES.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        UrunRepository _urunRepository;
        public UrunController(AppDbContext context)
        {
            _urunRepository= new UrunRepository(context);
        }
        [HttpPost("Add")]
        public IActionResult Add(Urun urun)
        {
            try
            {
                _urunRepository.Add(urun);
                return NoContent();
            }
            catch
            {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }
    }
}
