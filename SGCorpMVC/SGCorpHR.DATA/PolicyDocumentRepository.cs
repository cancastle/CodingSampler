using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.DATA
{
    public class PolicyDocumentRepository: IPolicyDocumentRepository
    {
        public List<PolicyDocument> GetPolicyDocumentsByCategory(string directoryPath, int category)
        {
            var filePath = directoryPath + "PolicyDocuments.txt";
            
            List<PolicyDocument> policyDocuments = new List<PolicyDocument>();

            var reader = File.ReadAllLines(filePath);            

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var policyDoc = new PolicyDocument();
                var policyDocCat = new Category();
                policyDoc.PolicyDocumentId = int.Parse(columns[0]);
                policyDoc.Name = columns[1];
                policyDocCat.CategoryName = columns[2];
                var filePathEnd = columns[3];
                policyDocCat.CategoryID = int.Parse(columns[4]);
                policyDoc.Category = policyDocCat;

                policyDoc.FilePath = directoryPath + filePathEnd;
                

                if(policyDoc.Category.CategoryID == category)
                {
                policyDocuments.Add(policyDoc);
                }
                
            }

            return policyDocuments;
        }

        public List<PolicyDocument> GetAllPolicyDocuments(string filePath)
        {


            List<PolicyDocument> policyDocuments = new List<PolicyDocument>();

            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var policyDoc = new PolicyDocument();

                policyDoc.PolicyDocumentId = int.Parse(columns[0]);
                policyDoc.Name = columns[1];
                policyDoc.Category.CategoryName = columns[2];
                policyDoc.FilePath = columns[3];
                
                    policyDocuments.Add(policyDoc);
                

            }

            return policyDocuments;
        }

        public List<Category> GetAllCategories(string filePath)
        {
            List<Category> policyCategories = new List<Category>();
            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                Category newCategory = new Category();

                
                newCategory.CategoryName = columns[2];
                newCategory.CategoryID = int.Parse(columns[4]);

                if (policyCategories.All(r => r.CategoryName != columns[2]))
                {
                    policyCategories.Add(newCategory);
                    
                }
            }
            return policyCategories;

        }

        public void AddPolicyDocument(string filePath, PolicyDocument document)
        {
            var policyList = GetAllPolicyDocuments(filePath);
            if (document.Category.CategoryID == 0)
            {
                int categoryID = policyList.Max(m => m.Category.CategoryID) + 1;
                document.Category.CategoryID = categoryID;

            }
            int newPolicyId = policyList.Max(m=> m.PolicyDocumentId)+1;
            document.PolicyDocumentId = newPolicyId;
            
            var existingCategory = GetAllCategories(filePath).FirstOrDefault(s => s.CategoryID == document.Category.CategoryID);
            document.Category.CategoryName = existingCategory.CategoryName;
            policyList.Add(document);
            OverwriteFile(policyList,filePath);

        }

        public void DeletePolicyDocument(string filePath, PolicyDocument document)
        {
            var policyList = GetAllPolicyDocuments(filePath);
            policyList.Remove(document);
            OverwriteFile(policyList, filePath);
        }

        public void OverwriteFile(List<PolicyDocument> policyList, string filePath)
        {

            File.Delete(filePath);

            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine(
                    "PolicyDocumentId,Name,Category,FilePath");

                foreach (var document in policyList)
                {
                    writer.WriteLine("{0},{1},{2},{3}, {4}", document.PolicyDocumentId,document.Name, document.Category.CategoryName, document.FilePath, document.Category.CategoryID);
                }
            }
        }
    }
}
