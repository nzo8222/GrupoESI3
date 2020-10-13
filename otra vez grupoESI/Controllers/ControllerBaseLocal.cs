using GrupoESIDataAccess;
using GrupoESINuevo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
