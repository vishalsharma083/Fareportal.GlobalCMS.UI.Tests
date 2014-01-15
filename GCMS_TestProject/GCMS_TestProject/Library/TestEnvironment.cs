using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Drawing.Imaging;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;


namespace GCMS_TestProject.Library
{
    public static class TestEnvironment
    {

        public static BrowserType BrowserName
        {
            get
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["Browser"]);
            }
        }


        public static IWebDriver Driver;

        public static void Dispose()
        {

            Driver.Quit();
            Driver = null;

        }
        public enum EngineType
        {
            COA,
            CA,
            OT,
            UK,
            Eclipse,

        }
        public static string LoadXML(string tagNameToFindd_)
        {

            XmlDocument xmlDoc = new XmlDocument();

            if (TestEnvironment.FlightEngine == EngineType.COA)
            { xmlDoc.Load("Ho.xml"); }
           
            if (TestEnvironment.FlightEngine == EngineType.Eclipse)
            { xmlDoc.Load("Beta1.xml"); }


            string Attribute = xmlDoc.GetElementsByTagName(tagNameToFindd_)[0].InnerText;
            return Attribute;
        }

        public static void Init()
        {
            if (TestEnvironment.BrowserName == BrowserType.FireFox & Driver == null)
            {
                Driver = new FirefoxDriver();

                Driver.Manage().Window.Maximize();

                //LoadPage();
            }
            if (TestEnvironment.BrowserName == BrowserType.Chrome & Driver == null)
            {
                //Driver = new ChromeDriver(@"D:\Projects\Solution1\Eclips\Lib\BrowserExe");
                Driver = new ChromeDriver();
                Driver.Manage().Window.Maximize();
                //LoadPage();
            }
            if (TestEnvironment.BrowserName == BrowserType.IE & Driver == null)
            {
                Driver = new InternetExplorerDriver();
                Driver.Manage().Window.Maximize();
                //LoadPage();
            }
            LoadPage();
            //clearBrowserCache();

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        public static EngineType FlightEngine
        {
            get
            {
                return (EngineType)Enum.Parse(typeof(EngineType), ConfigurationManager.AppSettings["site"]);
            }
        }


        public static void LoadPage()
        {
            if (TestEnvironment.FlightEngine == EngineType.COA)
            { Driver.Url = "http://www.cheapoair.com"; }

            if (TestEnvironment.FlightEngine == EngineType.CA)
            { Driver.Url = "http://www.cheapoair.ca"; }

            if (TestEnvironment.FlightEngine == EngineType.OT)
            { Driver.Url = "http://www.onetravel.com"; }

            //if (Environment.FlightEngine == EngineType.Gmail)
            //{ Driver.Url = "http://www.gmail.com"; }

        }
        public static void clearBrowserCache()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Cookies.DeleteAllCookies();

        }



        public static bool IsElementPresent(By by)
        {

            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (InvalidSelectorException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsElementDisplayed(By by)
        {
            try
            {
                return Driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public static bool WaitForElementPresent(string id_)
        {
            string XMLValues = LoadXML(id_);
            return WaitForElementPresent(By.Id(XMLValues), 20);
        }

        public static bool WaitForElementPresent(By by, int waitInSeconds)
        {
            var waitinSecs = waitInSeconds * 1000;
            var timeDifference = (waitinSecs / 250);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (var startvalue = 0; startvalue < timeDifference; startvalue++)
            {
                if (stopwatch.ElapsedMilliseconds > waitinSecs)
                    return false;
                //var elements = Driver.FindElements(by);
                //if (elements != null && elements.Count > 0)
                // return true;
                if (CheckElementPresence(by))
                {
                    return true;
                }
                Thread.Sleep(250);
            }
            return false;
        }

        public static bool CheckElementPresence(By by)
        {
            try
            {
                var elements = Driver.FindElements(by);
                if (elements != null && elements.Count > 0)
                { return true; }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static Dictionary<EngineType, XmlDocument> XmlDocuments = new Dictionary<EngineType, XmlDocument>();
        public static XmlDocument GetXml(EngineType engine_, string fileName_)
        {
            XmlDocument myXml = new XmlDocument();
            if (XmlDocuments.ContainsKey(engine_))
            {
                myXml = XmlDocuments[engine_];
            }
            else
            {
                myXml.Load(fileName_);
                XmlDocuments.Add(engine_, myXml);
            }
            return myXml;
        }



        public static void DoNavigate(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
        }
        public static void TakeScreenshot(IWebDriver driver, string saveLocation)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ImageFormat.Png);
        }

        //public bool TryFindElement(By by, out IWebElement element)
        //{
        //    try
        //    {
        //        element = Driver.FindElement(by);
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public static void SendMail(string filename)
        //{

        //    try
        //    {
        //        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        //        msg.From = new System.Net.Mail.MailAddress("sgulati@fareportal.com");
        //        msg.To.Add("vishal@fareportal.com");
        //        msg.CC.Add("dheerendrakp@fareportal.com");
        //        msg.CC.Add("sgulati@fareportal.com");  
        //        msg.CC.Add("sarnam@fareportal.com");
        //        msg.CC.Add("cahmed@fareportal.coml.com");

        //        msg.Subject = "This is Auto Genetated mail for Xpath's HTML contents.";
        //        msg.Attachments.Add(new Attachment(filename));
        //        msg.IsBodyHtml = true;
        //        msg.Body = "The given attachment is for matching Xpath's HTML formate";

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.EnableSsl = true;
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.Credentials = new System.Net.NetworkCredential("sgulati@fareportal.com", "saurabh@123456");
        //        System.Threading.Thread.Sleep(1000);

        //        smtp.Send(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //}      



        //public static bool SearchElement(By by, int waitInSecond)
        //{
        //    //var wait = waitInSecond * 1000;
        //    //var y = (wait / 250);
        //    //var sw = new Stopwatch();
        //    //sw.start();
        //    //for (var x = 0; x < y; x++)
        //    //{
        //    //    if (sw.ElapsedMilliseconds > wait)
        //    //        return false;
        //    //    var elements = Driver.FindElement(by);
        //    //    if (elements != null && elements.Count > 0)
        //    //        return true;
        //    //    System.Threading.Thread.Sleep(250);
        //    //}
        //    //return false;
        //    //}
        //}

        public static bool IsPresentInArray(string[] firstArray, string[] secondArray)
        {
            foreach (var itemA in firstArray)
            {
                foreach (var itemB in secondArray)
                {
                    if (itemB != itemA)
                    {

                    }

                }
            }
            return true;
        }

        public enum BrowserType
        {
            FireFox,
            IE,
            Chrome,
            Safari
        }

    }

}
