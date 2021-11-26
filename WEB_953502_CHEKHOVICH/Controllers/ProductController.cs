using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHEKHOVICH.Entities;
using WEB_953502_CHEKHOVICH.Models;
using WEB_953502_CHEKHOVICH.Extensions;
using WEB_953502_CHEKHOVICH.Data;
using Microsoft.Extensions.Logging;

namespace WEB_953502_CHEKHOVICH.Controllers
{
    public class ProductController : Controller
    {
        private int _pageSize;
        private ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _pageSize = 3;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var computersFiltered = _context.Computers.Where(d => !group.HasValue || d.ComputerGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.ComputerGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Computer>.GetModel(computersFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
