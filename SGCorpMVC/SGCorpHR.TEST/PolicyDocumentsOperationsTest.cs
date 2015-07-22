//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using SGCorpHR.BLL;
//using SGCorpHR.DATA;
//using System.IO;

//namespace SGCorpHR.TEST
//{
//    [TestFixture]
//   public class PolicyDocumentsOperationsTest
//    {
//       [Test]
//       public void GetAllFilesTest()
//       {
//           var ops = new PolicyDocumentsOperations();
//           //Server.MapPath is for the Controller to interact with the 
//           var fullPath = Server.MapPath(@"~\SGCorp.TEST\PolicyDocuments\PolicyDocuments.txt");
//           int categoryId = 1;
//           var response = ops.GetAllPolicyDocuments(fullPath, categoryId);
//           Assert.IsTrue(response.Success);
//       }
//    }
//}
