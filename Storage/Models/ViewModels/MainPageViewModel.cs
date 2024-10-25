namespace Storage.Models.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<ProductIndexViewModel> ProductViewModel { get; set; }
        public IEnumerable<Category> CategoryModel { get; set; }
        public MainPageViewModel(IEnumerable<ProductIndexViewModel> productViewModel, IEnumerable<Category> categoryModel)
        {
            ProductViewModel = productViewModel;
            CategoryModel = categoryModel;
        }

    }
}
