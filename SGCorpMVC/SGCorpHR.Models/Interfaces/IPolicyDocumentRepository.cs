using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models.Interfaces
{
    public interface IPolicyDocumentRepository
    {
        List<PolicyDocument> GetPolicyDocumentsByCategory(string directoryPath, int category);
        List<PolicyDocument> GetAllPolicyDocuments(string filePath);
        List<Category> GetAllCategories(string filePath);
        void AddPolicyDocument(string filePath, PolicyDocument document);
        void DeletePolicyDocument(string filePath, PolicyDocument document);
        void OverwriteFile(List<PolicyDocument> policyList, string filePath);
    }
}
