//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using SGCorpHR.BLL;
//using SGCorpHR.Models;

//namespace SGCorpHR.TEST
//{
//    [TestFixture]
//    public class FileOperationsTest
//    {
//        [Test]
//        public void DisplayFiles()
//        {
//            var ops = new FileOperations();
//            string path =
//                "C:\\Users\\Apprentice\\Documents\\Visual Studio 2013\\Examining colleague's code\\SGCorpHR\\SGCorpHR.TEST\\Suggestions\\Suggestions.txt";
//            var response = ops.DisplayFiles(path);
//            Assert.IsTrue(response.Success);
//            Assert.IsNotNull(response.Data);

//            //this can't work, since the repository returns null, so I don't see what this one was supposed to do
//        }
//    }
//}
