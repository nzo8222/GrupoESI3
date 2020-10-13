﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIDataAccess;

namespace GrupoESINuevo
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [BindProperty]
        public TaskQuotationVM _TaskQuotationVM { get; set; }
        public IActionResult OnGet(Guid orderDetailsId)
        {

            _TaskQuotationVM = new TaskQuotationVM(orderDetailsId);
            _TaskQuotationVM.TaskInfo = _context.Task.Include(t => t.QuotationModel)
                                                        .ThenInclude(q => q.OrderDetailsModel)
                                                            .ThenInclude(od => od.Order)
                                                      .FirstOrDefault(od => od.QuotationModel.OrderDetailsModel.Id == orderDetailsId);
            //_TaskQuotationVM.orderDetailsId = orderDetailsId;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (_TaskQuotationVM.TaskLocal.Name == null)
            {
                return Page();
            }
            if(_TaskQuotationVM.TaskLocal.Description == null)
            {
                return Page();
            }
            _TaskQuotationVM.TaskLocal.Cost = _TaskQuotationVM.TaskLocal.CostHandLabor;
            var quotation = _context.Quotation
                                            .Include(q => q.Tasks)
                                                .Include(q => q.OrderDetailsModel)
                                            .FirstOrDefault(q => q.OrderDetailsModel.Id == _TaskQuotationVM.orderDetailsId);
            if (quotation == null)
            {
                quotation = new Quotation();
                quotation.OrderDetailsModel = _context.OrderDetails.FirstOrDefault(od => od.Id == _TaskQuotationVM.orderDetailsId);
                quotation.Tasks = new List<TaskModel>();
                quotation.OrderDetailsModel.Cost = quotation.OrderDetailsModel.Cost + _TaskQuotationVM.TaskLocal.CostHandLabor;
                quotation.Tasks.Add(_TaskQuotationVM.TaskLocal);
                _context.Quotation.Add(quotation);
            }
            else
            {
                quotation.OrderDetailsModel.Cost = quotation.OrderDetailsModel.Cost + _TaskQuotationVM.TaskLocal.CostHandLabor;
                quotation.Tasks.Add(_TaskQuotationVM.TaskLocal);
                _context.Quotation.Update(quotation);
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = _TaskQuotationVM.orderDetailsId });
        }
    }
}
