using JSC_Portal.Models;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSC_Portal.ViewComponents
{ 
    public class TestListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string type)
        {
            var heroes = await GetHeroesAsync(type);
            return View(heroes);
        }

        private Task<IEnumerable<TestModel>> GetHeroesAsync(string type)
        {
            return Task.FromResult(GetHeroes(type));
        }

        private IEnumerable<TestModel> GetHeroes(string type)
        {
            var HM = new TestModelManager();
            return HM.GetHeroesByType(type);
        } 
    }
}
