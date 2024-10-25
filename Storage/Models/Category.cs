using Microsoft.AspNetCore.Mvc.Rendering;

namespace Storage.Models
{
    public class Category
    {
        public SelectListItem listItem;
        public Category(string name)
        {
            listItem.Text = name;
            listItem.Value = name;
        }
    }
}
