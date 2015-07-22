using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Models
{
    public class CategoryVM
    {
        public List<SelectListItem> Categories { get; set; }
        public int SelectedCategory { get; set; }


        public void CreateCategoryList(List<Category> categories)
        {
            Categories = new List<SelectListItem>();
            foreach (var c in categories)
            {
                Categories.Add(new SelectListItem()
                {
                    Text = c.CategoryName,
                    Value = c.CategoryID.ToString()

                });
            }
        }

    }
}
