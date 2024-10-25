using Microsoft.AspNetCore.Mvc.Rendering;

namespace Storage.Models.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<ProductIndexViewModel> ProductViewModel { get; set; }
        public IEnumerable<SelectListItem> CategoryModel { get; set; }


    }
}
