using GrupoESIDataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GrupoESINuevo.Controllers
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
