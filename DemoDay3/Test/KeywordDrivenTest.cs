using DemoDay3.Helper;
using DemoDay3.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFrameworkCore.Helper;

namespace DemoDay3.Test
{
  
    public class KeywordDrivenTest
    {
        [TestMethod("TC04: Verify login by using Keyword driven")]
        public void VerifyLogin() {

            // Read keywords
            var excelHelper = new ExcelHelper(Path.Combine("Resource", "KeywordDriven2.xlsx"));

            // Get List keyword 
            var keywords = excelHelper.GetKeywordDatas();

            //Execute keywords
            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeyword();

        }
    }
}
