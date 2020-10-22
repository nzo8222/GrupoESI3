using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GrupoESIModels.Models;
using GrupoESIUtility;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditOrderModel : PageModel
    {
        private readonly IQueries _queries;

        public EditOrderModel(IQueries queries)
        {
            _queries = queries;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }
            Order = _queries.GetOrderIncludeOrderDetailsServiceApplicationUserFirstOrDefault((Guid)orderId);
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            LoadAndSetModel();
            SaveChanges();

            return RedirectToPage("../ManageOrders/OrderIndexAdmin");
        }

        private void SaveChanges()
        {
            try
            {
                _queries.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }

        private void LoadAndSetModel()
        {
            var orderLocal = _queries.GetOrderByOrderId(Order.Id);
            orderLocal.Concepto = Order.Concepto;
            orderLocal.Direccion = Order.Direccion;
            orderLocal.OrderDate = Order.OrderDate;
        }
    }
}
