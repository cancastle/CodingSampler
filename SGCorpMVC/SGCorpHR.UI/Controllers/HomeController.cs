using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.BLL;
using SGCorpHR.Models;
using System.IO;
using System.Net;
using System.Web.WebPages;
using SGCorpHR.DATA;
using SGCorpHR.UI.Models;


namespace SGCorpHR.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult SaveFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fullPath = Server.MapPath(@"~/Resumes");
                file.SaveAs(String.Format(@"{0}\{1}", fullPath, file.FileName));
            }


            return RedirectToAction("ViewResume");

        }
       
        public ActionResult Save()
        {
           


            return View("Save");

        }

        public ActionResult ViewResume()
        {

            var ops = FileManager.CreateFileOperations();
            var filePath = Server.MapPath(@"~/Resumes"); 
            var response = ops.DisplayFiles(filePath);
            return View(response);

        }

        public ActionResult ViewSuggestions()
        {
            
            var ops = FileManager.CreateSuggestionOperations();
            var fullPath = Server.MapPath(@"~/Suggestions/suggestions.txt");
            var response = ops.DisplaySuggestions(fullPath);
            return View(response);
        }

        public ActionResult DeleteSuggestion(int suggestionID)
        {
            var ops = FileManager.CreateSuggestionOperations(); 
            var fullPath = Server.MapPath(@"~/Suggestions/suggestions.txt");
            ops.DeleteSuggestions(suggestionID, fullPath);
            return RedirectToAction("ViewSuggestions");

        }

        public ActionResult DownloadResume(string filePath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@filePath);
            string fileName = filePath.Substring(filePath.Length-8, 8);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult DeleteResume(string filePath)
        {
           System.IO.File.Delete(@filePath);
           return RedirectToAction("ViewResume");
        }

        
        public ActionResult AddSuggestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSuggestionForm(Suggestion suggestion)
        {
            var ops = FileManager.CreateSuggestionOperations();
            var fullPath = Server.MapPath(@"~/Suggestions/suggestions.txt");
            ops.AddSuggestion(suggestion, fullPath);
            
            return View("ConfirmationPage");
        }
    [HttpPost]
        public ActionResult ViewPolicyDocuments(int SelectedCategory )
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments/");
            var ops = FileManager.CreatePolicyDocumentOperations();
            var response = ops.GetAllPolicyDocuments(fullPath, SelectedCategory);
            
            return View(response) ;
        }

        [HttpGet]
        public ActionResult SelectPolicyCategories()
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments/PolicyDocuments.txt");
            var model = new CategoryVM();
            var ops = FileManager.CreatePolicyDocumentOperations();
            var response = ops.GetAllCategories(fullPath);
            model.CreateCategoryList(response.Data); 

            return View(model);

        }

        public ActionResult DownloadPolicyDoc(string filePath, string name)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@filePath);
            var fileName = name + Path.GetExtension(filePath);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        [HttpGet]
        public ActionResult AddPolicyDocument()
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments/PolicyDocuments.txt");
            var model = new UploadPolicyVM();
            var ops = FileManager.CreatePolicyDocumentOperations();
            var response = ops.GetAllCategories(fullPath);
            model.CreateCategoryList(response.Data); 

            return View(model);
        }


        [HttpPost]
        public ActionResult AddPolicyDocument(UploadPolicyVM model)
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments/PolicyDocuments.txt");
            var ops = FileManager.CreatePolicyDocumentOperations();

            if (ModelState.IsValid)
            {
                var file = model.file;
                if (file.ContentLength > 0)
                {
                    var directoryPath = Server.MapPath(@"~/PolicyDocuments");
                    file.SaveAs(String.Format(@"{0}\{1}", directoryPath, file.FileName));

                    var policyDoc = new PolicyDocument();

                    string extension = Path.GetExtension(file.FileName);
                    //null ref - needs to be updated

                    if (!model.NewCategory.IsEmpty())
                    {
                        policyDoc.Category.CategoryName = model.NewCategory.ToUpper();
                    }

                    else
                    {
                        policyDoc.Category.CategoryID = model.SelectedCategory;
                    }

                    policyDoc.Name = model.DocName;

                    policyDoc.FilePath = file.FileName;


                    ops.AddPolicyDocument(policyDoc, fullPath);
                    return View("ConfirmationPage");
                }
            }

            var response = ops.GetAllCategories(fullPath);
            model.CreateCategoryList(response.Data);

            return View(model);
        }

        public ActionResult ManageViewPolicyDocuments(int category)
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments/");
            var ops = FileManager.CreatePolicyDocumentOperations();
            var response = ops.GetAllPolicyDocuments(fullPath, category);

            return View(response);
        }

        public ActionResult ManageSelectPolicyCategories()
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments/PolicyDocuments.txt");
            var ops = FileManager.CreatePolicyDocumentOperations();
            var response = ops.GetAllCategories(fullPath);

            return View(response);
        }

        [HttpGet]
        public ActionResult ViewTimeSheets()
        {
            var model = new ViewTimeSheetVM();
            var ops = FileManager.CreateTimeSheetOperations();
            var empDD = ops.GetAllEmployees();
            model.CreateEmployeeList(empDD);

            return View(model);
        }

        [HttpPost]
        public ActionResult ViewTimeSheets(int SelectedEmployeeID)
        {
            var model = new ViewTimeSheetVM();
            var ops = FileManager.CreateTimeSheetOperations();
            var timeEntries = ops.GetAllTimeEntriesForOneEmp(SelectedEmployeeID);

            var employee = ops.SelectOneEmployee(SelectedEmployeeID);
            model.TimeEntries = timeEntries.Data;
            model.Message = timeEntries.Message;
            model.employee = employee;
            var empDD = ops.GetAllEmployees();
            model.CreateEmployeeList(empDD);

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteTimeEntry(int SelectedEmployeeID, int TimeEntryID)
        {
            var model = new ViewTimeSheetVM();
            var ops = FileManager.CreateTimeSheetOperations();
            ops.DeleteTimeEntry(TimeEntryID);
            var timeEntries = ops.GetAllTimeEntriesForOneEmp(SelectedEmployeeID);

            var employee = ops.SelectOneEmployee(SelectedEmployeeID);
            model.TimeEntries = timeEntries.Data;
            model.Message = timeEntries.Message;
            model.employee = employee;
            var empDD = ops.GetAllEmployees();
            model.CreateEmployeeList(empDD);

            return View("ViewTimeSheets", model);
        }

        [HttpGet]
        public ActionResult AddTimeSheets()
        {
            var model = new AddTimeSheetVM();
            var ops = FileManager.CreateTimeSheetOperations();
            var empDD = ops.GetAllEmployees();
            model.CreateEmployeeList(empDD);

            return View(model);
        }

        [HttpPost]
        public ActionResult AddTimeSheets(TimeEntry timeEntry, int SelectedEmployeeID)
        {
         
            var ops = FileManager.CreateTimeSheetOperations();
            timeEntry.EmpID = SelectedEmployeeID;
            var empDD = ops.GetAllEmployees();
            ops.AddTimeSheets(timeEntry);

            ViewTimeSheetVM model = new ViewTimeSheetVM();
            var timeEntries = ops.GetAllTimeEntriesForOneEmp(SelectedEmployeeID);

            var employee = ops.SelectOneEmployee(SelectedEmployeeID);
            model.TimeEntries = timeEntries.Data;
            model.Message = timeEntries.Message;
            model.employee = employee;
           
            model.CreateEmployeeList(empDD);
   
            model.employee.EmpID= SelectedEmployeeID;

            return View("ViewTimeSheets", model);
        }
    }
}