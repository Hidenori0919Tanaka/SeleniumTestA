using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_Sample.WebAPI;
using UnitTest_Sample.WebAPI.Controllers;

namespace UnitTest_Sample.WebAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // 準備
            HomeController controller = new HomeController();

            // 実行
            ViewResult result = controller.Index() as ViewResult;

            // アサート
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
