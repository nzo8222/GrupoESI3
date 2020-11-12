using GrupoESIDataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GrupoESI.Controllers
{
    public class ControllerBaseLocal : ControllerBase
    {
        protected readonly ApplicationDbContext _context;
        public ControllerBaseLocal(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
