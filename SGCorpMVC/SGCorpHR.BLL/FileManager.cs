using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.BLL
{
    public class FileManager
    {
        private static string mode = ConfigurationManager.AppSettings["Mode"];

        public static FileOperations CreateFileOperations()
        {
             if (mode == "Test")
                 return new FileOperations(new FileRepository());
             else
             {
                 throw new Exception("Database not yet implemented");
             }
        }

        public static PolicyDocumentsOperations CreatePolicyDocumentOperations()
        {
            if(mode == "Test")
                return new PolicyDocumentsOperations(new PolicyDocumentRepository());
            else
            {
                throw new Exception("Database not yet implemented");
            }

        }

        public static SuggestionOperations CreateSuggestionOperations()
        {
            if(mode == "Test")
                return new SuggestionOperations(new SuggestionRepository());
            else
            {
                throw new Exception("Database not yet implemented");
            }
        }

        public static TimeSheetOperations CreateTimeSheetOperations()
        {
            
            return new TimeSheetOperations(new TimeSheetRepository());
        }

    }
}
