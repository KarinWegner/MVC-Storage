using Microsoft.AspNetCore.Mvc.Rendering;

namespace Storage.Models.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<ProductIndexViewModel> ProductViewModel { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string? SelectedCategory { get; set; }


    }
}
