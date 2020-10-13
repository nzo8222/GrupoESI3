using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IQuotationRepository : IRepository<Quotation>
    {
        public void Update(Quotation obj);
    }
}
