using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WEB_953502_CHEKHOVICH.Controllers
{
    public class HomeController : Controller
    {
        private List<ListDemo> _listDemo;

        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo(1, "Предмет 1"),
                new ListDemo(2, "Предмет 2"),
                new ListDemo(3, "Предмет 3")
            };
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Лабораторная работа №2";
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
            return View();
        }
    }

    public class ListDemo
    {
        public int ListItemValue { get; set; }
        public string ListItemText { get; set; }

        public ListDemo(int value, string text)
        {
            ListItemValue = value;
            ListItemText = text;
        }
    }
}
