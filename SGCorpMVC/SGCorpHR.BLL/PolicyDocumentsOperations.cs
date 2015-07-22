using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.BLL
{
    public class PolicyDocumentsOperations
    {
        private IPolicyDocumentRepository _policyDocRepo;

        public PolicyDocumentsOperations(IPolicyDocumentRepository myPolicyDocRepo)
        {
            _policyDocRepo = myPolicyDocRepo;
        }
        
        public Response<List<PolicyDocument>> GetAllPolicyDocuments(string fullPath, int category)
        {
            var repo = new PolicyDocumentRepository();
            Response<List<PolicyDocument>> response = new Response<List<PolicyDocument>>();
            List<PolicyDocument> policyDocs = repo.GetPolicyDocumentsByCategory(fullPath, category);
            try
            {
                if (policyDocs.Count > 0)
                {
                    response.Success = true;
                    response.Data = policyDocs;
                }
                else
                {
                    response.Success = false;
                    response.Message = "There are no files to display.";
                }

            }
            catch (Exception  ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Category>> GetAllCategories(string fullPath)
        {
            var repo = new PolicyDocumentRepository();
            Response<List<Category>> response = new Response<List<Category>>();
            List<Category> categories = repo.GetAllCategories(fullPath);
            
            try
            {
                if (categories.Count > 0)
                {
                    response.Success = true;
                    response.Data = categories;
                }
                else
                {
                    response.Success = false;
                    response.Message = "There are no categories to display.";
                }

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
            
        }

        public void AddPolicyDocument(PolicyDocument document, string filePath)
        {
            var repo = new PolicyDocumentRepository();
            repo.AddPolicyDocument(filePath,document);
        }

        public void DeletePolicyDocument(string filePath, PolicyDocument policyDoc)
        {
            var repo = new PolicyDocumentRepository();
            repo.DeletePolicyDocument(filePath, policyDoc);
        }
    }
}
