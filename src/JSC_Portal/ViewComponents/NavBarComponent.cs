using JSC_Portal.Models;
using JSC_Portal.Resources;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSC_Portal.ViewComponents
{
    public class NavBarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GetMenuItemsAsync());
        }

        private Task<IEnumerable<NavBarModel>> GetMenuItemsAsync()
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
                    Text = ComponentResources.SMainPage,
                    IsActive = true,
                    Url = "home",
                    Priority = 1
                },
                new NavBarModel
                {
                    Text = ComponentResources.SOnlineServices,
                    IsActive = false,
                    Url = "math",
                    Priority = 2
                }
            }.OrderBy(m => m.Priority);
        }
    }
}
