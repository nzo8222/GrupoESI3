using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESINuevo.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoESINuevo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBaseLocal
    {
        public PicturesController(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
        [HttpGet]
        [Route("ViewPic")]
        public IActionResult GetViewPic( string pictureId)
        {
            if(pictureId == "")
            {
                return NotFound();
            }
            var picture = _context.Pictures.FirstOrDefault(p => p.PictureId.ToString() == pictureId);
            
            return Ok(new { imgLocal = picture.PictureBytes });
            
        }
    }
}
