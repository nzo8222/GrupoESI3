using System;

using GrupoESIDataAccess;
using GrupoESIDataAccess.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GrupoESI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBaseLocal
    {
        private readonly IQueries _queries;
        public PicturesController(ApplicationDbContext applicationDbContext,
                                  IQueries queries) : base(applicationDbContext)
        {
            _queries = queries;
        }
        [HttpGet]
        [Route("ViewPic")]
        public IActionResult GetViewPic( string pictureId)
        {
            if(pictureId == "")
            {
                return NotFound();
            }
            Guid id = Guid.Parse(pictureId);
            var picture = _queries.GetPictureFirstOrDefaultWherePictureIdEquals(id);
              
            
            return Ok(new { imgLocal = picture.PictureBytes });
            
        }
    }
}
