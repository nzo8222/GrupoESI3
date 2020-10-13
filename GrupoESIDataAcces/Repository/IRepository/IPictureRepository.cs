
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IPictureRepository : IRepository<Picture>
    {
        public void Update(Picture obj);
    }
}
