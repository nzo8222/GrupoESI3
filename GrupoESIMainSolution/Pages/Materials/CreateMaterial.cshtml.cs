﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;

using Microsoft.EntityFrameworkCore;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIDataAccess;

namespace GrupoESINuevo
{
    public class CreateMaterialModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateMaterialModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public TaskMaterialVM _TaskMaterialVM { get; set; }
        public IActionResult OnGet(Guid taskId)
        {
            if (taskId == null)
            {
                return Page();
            }
            _TaskMaterialVM = new TaskMaterialVM()
            {
                MaterialModel = new Material(),
                TareaModel = _context.Task
                                          .Include(t => t.QuotationModel)
                                               .ThenInclude(q => q.OrderDetailsModel)
                                          .FirstOrDefault(t => t.Id == taskId),
                taskId = taskId
               
            };
            _TaskMaterialVM.orderDetailsId = _TaskMaterialVM.TareaModel.QuotationModel.OrderDetailsModel.Id;
            return Page();
        }



        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()

        {
            if (_TaskMaterialVM.MaterialModel.Name == "")
            {
                return Page();
            }
            if (_TaskMaterialVM.MaterialModel.Description == "")
            {
                return Page();
            }
            var tareaModel = await _context.Task
                                                        .Include(t => t.ListMaterial)
                                                        .Include(t => t.QuotationModel)
                                                             .ThenInclude(q => q.OrderDetailsModel)
                                                        .FirstOrDefaultAsync(t => t.Id == _TaskMaterialVM.taskId);
            if (tareaModel.ListMaterial == null)
            {
                tareaModel.ListMaterial = new List<Material>();
            }
           
            _TaskMaterialVM.MaterialModel.TaskModelId = tareaModel.Id;

            tareaModel.ListMaterial.Add(_TaskMaterialVM.MaterialModel);
            tareaModel.Cost = tareaModel.Cost + _TaskMaterialVM.MaterialModel.Price;
            tareaModel.QuotationModel.OrderDetailsModel.Cost = tareaModel.QuotationModel.OrderDetailsModel.Cost + _TaskMaterialVM.MaterialModel.Price;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
                return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = tareaModel.QuotationModel.OrderDetailsModel.Id });
            }
        }
    }


