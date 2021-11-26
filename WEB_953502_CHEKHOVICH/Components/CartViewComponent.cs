using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_953502_CHEKHOVICH.Extensions;
using WEB_953502_CHEKHOVICH.Models;

namespace WEB_953502_CHEKHOVICH.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;

        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
