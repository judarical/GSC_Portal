using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSC_Portal.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        // todo: поэкспериментировать с асинхронностью отображения меню и footer-а
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(/*await GetMenuItemsAsync()*/);
        }

        /*private Task<IEnumerable<NavBarModel>> GetMenuItemsAsync()
        {
            return Task.FromResult(GetMenuItems());
        }

        private IEnumerable<NavBarModel> GetMenuItems()
        {
            // todo: все пункты меню читать из базы            
            return new List<NavBarModel>
            {
                new NavBarModel
                {
                    Text = "Главная страница",//ComponentResources.SMainPage,
                    IsActive = true,
                    Url = "home",
                    Priority = 1
                },
                new NavBarModel
                {
                    Text = "Сервисы онлайн", // ComponentResources.SOnlineServices,
                    IsActive = false,
                    Url = "math",
                    Priority = 2
                }
            }.OrderBy(m => m.Priority);
        }*/
    }
}
