using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Models
{
    public class UploadPolicyVM
    {
        public List<SelectListItem> Categories { get; set; }
        public int SelectedCategory { get; set; }
        public string NewCategory { get; set; }
        public HttpPostedFileBase file { get; set; }
        [Display(Name = "DocName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The document name is required.")]
        public string DocName { get; set; }


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