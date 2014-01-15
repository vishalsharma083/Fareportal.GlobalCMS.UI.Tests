using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using GCMS_TestProject.Library;

namespace GCMS_TestProject.Utility
{
    public class GcmsUtitlity : GCMS_CodedUi
    {


        public void GetOutputResultInPreview2AndPreview1(string _launchedUrl, string _Contentspecificurls_ForPublishforModule, string _Contentspecificurls_DraftforModule)
        {
            TestEnvironment.Driver.FindElement(By.LinkText(TestEnvironment.LoadXML("LogOut"))).Click();
            System.Threading.Thread.Sleep(6000);

            TestEnvironment.Driver.Navigate().GoToUrl("http://preprod.hotelpricer.com" + _launchedUrl + "?preview=2");

            string OutputResultDiv_WhenPublish = ByXpath("OutputResultDiv", 4);
            Assert.AreEqual(_Contentspecificurls_ForPublishforModule, OutputResultDiv_WhenPublish);
            System.Threading.Thread.Sleep(6000);

            TestEnvironment.Driver.Navigate().GoToUrl("http://preprod.hotelpricer.com" + _launchedUrl + "?preview=1");

            string OutputResultDiv_WhenDraft = ByXpath("OutputResultDiv", 4);
            Assert.AreEqual(_Contentspecificurls_DraftforModule, OutputResultDiv_WhenDraft);
            Sleep(3);
        }

        public void ClickOnSearchButtonInLaunchedGrid(string _searchActionValue, string _conditionalValue, string _valueToSearch)
        {
            ((IJavaScriptExecutor)TestEnvironment.Driver).ExecuteScript("scroll(100,2900)");
            CsstoClick("ClickOnSearchButtonOnLaunchedGrid", 5);
            Sleep(3);
            var SearchAction = TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("SearchedURL")));
            var selectelElementInAction = new SelectElement(SearchAction);
            selectelElementInAction.SelectByText(_searchActionValue);

            var CommandForSearch = TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("ConditionToSearch")));
            var selectelCommandType = new SelectElement(CommandForSearch);
            selectelCommandType.SelectByText(_conditionalValue);

            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("ValueToBeSearch"))).SendKeys(_valueToSearch);

            System.Threading.Thread.Sleep(3000);

            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("ClickOnFindButtonInLaunchedGrid1"))).FindElement(By.CssSelector(TestEnvironment.LoadXML("ClickOnFindButtonInLaunchedGrid2"))).Click();

            //Driver.FindElement(By.CssSelector(Eclips.Lib.Environment.LoadXML("CloseSearchCommandClose"))).Click();

        }

        public void ClickOnSearchBtnInMetaTextGrid(string _conditionalValue, string _valueToSearch)
        {
            var CommandForSearch = TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("ConditionToSearch")));
            var selectelCommandType = new SelectElement(CommandForSearch);
            selectelCommandType.SelectByText(_conditionalValue);

            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("ValueToBeSearch"))).SendKeys(_valueToSearch);

            System.Threading.Thread.Sleep(3000);

            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("ClickOnFindButtonInLaunchedGrid1"))).FindElement(By.CssSelector(TestEnvironment.LoadXML("ClickOnFindButtonInLaunchedGrid2"))).Click();

        }

        public string ChangeMetaTextContent(string _pageName, string _pageTitle, string _description, string _keywords, string _pageHeaderTags)
        {
            Random randomNum = new Random();
            int num = randomNum.Next(5, 100);
            string newPageName = _pageName + num;
            string newPageTitle = _pageTitle + num;
            string newDescription = _description + num;
            string newKeywords = _keywords + num;
            string newPageHeaderTags = _pageHeaderTags + num;

            DataForMetaText(newPageName, newPageTitle, newDescription, newKeywords, newPageHeaderTags);

            return newPageName;
        }

        public void DataForMetaText(string pageName, string pageTitle, string description, string keywords, string pageHeaderTags)
        {

            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("PageName"))).Clear();
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("PageName"))).SendKeys(pageName);
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("PageTitle"))).Clear();
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("PageTitle"))).SendKeys(pageTitle);
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("Description"))).Clear();
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("Description"))).SendKeys(description);
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("Keywords"))).Clear();
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("Keywords"))).SendKeys(keywords);
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("PageHeaderTags"))).Clear();
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("PageHeaderTags"))).SendKeys(pageHeaderTags);

        }

        public void selectTestTemplate(string _templateToSelect)
        {
            IWebElement source = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("source")));
            new Actions(TestEnvironment.Driver).MoveToElement(source).Build().Perform();
            List<IWebElement> lst = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("Collection"))).FindElements(By.TagName("tr")).ToList();
            IWebElement st1 = lst.Where(p => p.Text == _templateToSelect).FirstOrDefault();
            st1.Click();
        }

        //public void selectChildTemplate(string _childtemplateToSelect)
        //{
        //    IWebElement source = Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML("source")));
        //    new Actions(Environment.Driver).MoveToElement(source).Build().Perform();
        //    IWebElement TestTemPlate11source2 = Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML("Child")));
        //    List<IWebElement> lst = Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML("Collection"))).FindElements(By.TagName("tr")).ToList();
        //    IWebElement st1 = lst.Where(p => p.Text == _childtemplateToSelect).FirstOrDefault();
        //    st1.Click();
        //    Sleep(5);
        //}

        public void CompareOutputInChrome(string Preview2Url, string Preview1Url, string ecpectedPublishValue, string expectedDraftvalue)
        {
            IWebDriver driverCRM = new ChromeDriver();
            System.Threading.Thread.Sleep(5000);


            TestEnvironment.DoNavigate(driverCRM, Preview2Url);
            string actualContentPad = ByXpath("ContentPadAtHomePage", 4);
            System.Threading.Thread.Sleep(5000);
            // Eclips.Lib.Environment.TakeScreenshot(driverCRM, @"D:\NEW\screenshotForFAQ.png");
            Assert.AreEqual(ecpectedPublishValue, actualContentPad);


            TestEnvironment.DoNavigate(driverCRM, Preview1Url);
            System.Threading.Thread.Sleep(5000);
            //Eclips.Lib.Environment.TakeScreenshot(driverCRM, @"D:\NEW\screenshotForGeneral.png");
            var isNotMatched = expectedDraftvalue != actualContentPad ? true : false;
            Assert.IsTrue(isNotMatched, "The value is updated for Draft.");

        }


        public void CompareOutputInChromeForPreview1(string Preview1Url, string expectedDraftvalue, string moduleName)
        {
            IWebDriver driverCRM = new ChromeDriver();
            System.Threading.Thread.Sleep(5000);
            
            driverCRM.Navigate().GoToUrl(Preview1Url);

            if (moduleName == "HTMLModule")
            {
                string OutputResultDiv_WhenDraft = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDiv"))).Text;
                Assert.AreEqual(expectedDraftvalue, OutputResultDiv_WhenDraft);
                System.Threading.Thread.Sleep(6000);
            }
            else if (moduleName == "SQLModule")
            {
                string OutputResultDiv_WhenDraft = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDivSQL"))).Text;
                Assert.AreEqual(expectedDraftvalue, OutputResultDiv_WhenDraft);
                System.Threading.Thread.Sleep(6000);
            }
            else if (moduleName == "RSSFeed")
            {
                string OutputResultDiv_WhenDraft = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDivRss"))).Text;
                Assert.AreEqual(expectedDraftvalue, OutputResultDiv_WhenDraft);
                System.Threading.Thread.Sleep(6000);
            }
            else if (moduleName == "ExcelModule")
            {
                string OutputResultDiv_WhenDraft = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDivExcelModule"))).Text;
                Assert.AreEqual(expectedDraftvalue, OutputResultDiv_WhenDraft);
                System.Threading.Thread.Sleep(6000);
            }
            
            driverCRM.Manage().Cookies.DeleteAllCookies();
            driverCRM.Dispose();

        }

        public void CompareOutputInChromeForPreview2(string Preview2Url, string ecpectedPublishValue, string moduleName)
        {
            IWebDriver driverCRM = new ChromeDriver();
            System.Threading.Thread.Sleep(5000);
            driverCRM.Navigate().GoToUrl(Preview2Url);

            if (moduleName == "HTMLModule")
            {
                string OutputResultDiv_WhenPublish = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDiv"))).Text;
                Assert.AreEqual(ecpectedPublishValue, OutputResultDiv_WhenPublish);
                System.Threading.Thread.Sleep(6000);
            }
            else if (moduleName == "SQLModule")
            {
                string OutputResultDiv_WhenPublish = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDivForSQL"))).Text;
                Assert.AreEqual(ecpectedPublishValue, OutputResultDiv_WhenPublish);
                System.Threading.Thread.Sleep(6000);
            }
            else if (moduleName == "RSSFeed")
            {
                string OutputResultDiv_WhenPublish = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDivForRss"))).Text;
                Assert.AreEqual(ecpectedPublishValue, OutputResultDiv_WhenPublish);
                System.Threading.Thread.Sleep(6000);
            }
            else if (moduleName == "ExcelModule")
            {
                string OutputResultDiv_WhenPublish = driverCRM.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDivExcelModule"))).Text;
                Assert.AreEqual(ecpectedPublishValue, OutputResultDiv_WhenPublish);
                System.Threading.Thread.Sleep(6000);
            }
            driverCRM.Manage().Cookies.DeleteAllCookies();
            driverCRM.Dispose();

        }



        public void CompareOutputInfirefox(string _incommingUrlValue, string _editContentMultiLineTextBoxForAllUrlsForPublish, string _editContentMultiLineTextBoxForAllUrlsForDraft)
        {


            TestEnvironment.Driver.Navigate().GoToUrl("http://preprod.hotelpricer.com" + _incommingUrlValue + "?preview=2");

            string OutputResultDiv_WhenPublish = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDiv"))).Text;
            Assert.AreEqual(_editContentMultiLineTextBoxForAllUrlsForPublish, OutputResultDiv_WhenPublish);
            System.Threading.Thread.Sleep(6000);

            TestEnvironment.Driver.Navigate().GoToUrl("http://preprod.hotelpricer.com" + _incommingUrlValue + "?preview=1");

            string OutputResultDiv_WhenDraft = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDiv"))).Text;
            Assert.AreEqual(_editContentMultiLineTextBoxForAllUrlsForDraft, OutputResultDiv_WhenDraft);
            System.Threading.Thread.Sleep(2000);




            //IWebDriver driverCRM = new ChromeDriver();
            //System.Threading.Thread.Sleep(5000); 


            //Eclips.Lib.Environment.DoNavigate(driverCRM, Preview2Url);
            //string actualContentPad = ByXpath("ContentPadAtHomePage", 4);
            //System.Threading.Thread.Sleep(5000);
            //// Eclips.Lib.Environment.TakeScreenshot(driverCRM, @"D:\NEW\screenshotForFAQ.png");
            //Assert.AreEqual(ecpectedPublishValue, actualContentPad);


            //Eclips.Lib.Environment.DoNavigate(driverCRM, Preview1Url);
            //System.Threading.Thread.Sleep(5000);
            ////Eclips.Lib.Environment.TakeScreenshot(driverCRM, @"D:\NEW\screenshotForGeneral.png");
            //var isNotMatched = expectedDraftvalue != actualContentPad ? true : false;
            //Assert.IsTrue(isNotMatched, "The value is updated for Draft.");


        }


        public void CompareOutputInfirefoxForBeta1Preview1(string _editContentMultiLineTextBoxForAllUrlsForDraft)
        {


            //Environment.Driver.Navigate().GoToUrl("http://beta1.cheapoair.com" + _incommingUrlValue + "?preview=1");       

            string OutputResultDiv_WhenDraft = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDiv"))).Text;
            Assert.AreEqual(_editContentMultiLineTextBoxForAllUrlsForDraft, OutputResultDiv_WhenDraft);
            System.Threading.Thread.Sleep(2000);

        }


        public void CompareOutputInfirefoxForBeta1Preview2(string _editContentMultiLineTextBoxForAllUrlsForPublish)
        {


            //Environment.Driver.Navigate().GoToUrl("http://beta1.cheapoair.com" + _incommingUrlValue + "?preview=2");

            string OutputResultDiv_WhenPublish = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("OutputResultDiv"))).Text;
            Assert.AreEqual(_editContentMultiLineTextBoxForAllUrlsForPublish, OutputResultDiv_WhenPublish);
            System.Threading.Thread.Sleep(6000);

        }

        public string GetPreviousValueInMultiLineHtmlModule()
        {
            IWebElement imgsourceForSQLTestModuleIfPresent = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(imgsourceForSQLTestModuleIfPresent).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSourceEdit"))).Click();
            Sleep(4);
            string _previousValueInHtmlModule = TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlModuleEdit"))).GetAttribute("value");

            return _previousValueInHtmlModule;
        }

        public string SetNewValueToMultiLineHtmlModule(string _newContentInMultiLineTextBox)
        {
            Random randomNum = new Random();
            int num = randomNum.Next(5, 100);
            string newContent = _newContentInMultiLineTextBox + num;

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxForBoth"))).Clear();


            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxForBoth"))).SendKeys(newContent);
            string newStringEditableContentInMultiLineTextBox = TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlModuleEdit"))).GetAttribute("value");
            System.Threading.Thread.Sleep(4000);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnPublishBtn"))).Click();
            TestEnvironment.Driver.SwitchTo().Alert().Accept();
            return newStringEditableContentInMultiLineTextBox;
        }

        public void CompareExistingWithPreviousValuesInHtmlModule(string alreadyContentInMultiLineTextBox, string newStringEditableContentInMultiLineTextBox)
        {
            IWebElement imgsourceForSQLTestModuleIfPresentagainToCheck = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSource")));

            new Actions(TestEnvironment.Driver).MoveToElement(imgsourceForSQLTestModuleIfPresentagainToCheck).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSourceEdit"))).Click();

            var isNotMatched = alreadyContentInMultiLineTextBox != newStringEditableContentInMultiLineTextBox ? true : false;

            Assert.IsTrue(isNotMatched, "The value is updated");
        }

        public void CreateByExcelFile()
        {
            ((IJavaScriptExecutor)TestEnvironment.Driver).ExecuteScript("scroll(100,2900)");
            CsstoClick("ClickOnSearchButtonOnLaunchedGrid", 5);
            Sleep(3);

            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("CreateByExcelFile"))).Click();
            System.Threading.Thread.Sleep(6000);

            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("BrowseURLsFromExcel"))).Click();
        }


        public void EditInCreatedNewModulesForPublish(string _textAreaAfterClickOnHtmlModuleEdit)
        {

            IWebElement HTMLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(HTMLModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlModuleEdit"))).Clear();
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlModuleEdit"))).SendKeys(_textAreaAfterClickOnHtmlModuleEdit);
            System.Threading.Thread.Sleep(3000);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnPublishBtnWhileAddingHtmlModule"))).Click();
            TestEnvironment.Driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(3000);

        }

        public void EditInCreatedNewModulesForDraft(string _textAreaAfterClickOnHtmlModuleEdit)
        {
            IWebElement HTMLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(HTMLModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlModuleEdit"))).Clear();
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlModuleEdit"))).SendKeys(_textAreaAfterClickOnHtmlModuleEdit);
            System.Threading.Thread.Sleep(3000);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnDraftBtnWhileAddingHtmlModule"))).Click();
            Sleep(3);
        }


        public void EditInContentSpecificModulesForPublish(string _textAreaAfterClickOnHtmlModuleEdit)
        {

            IWebElement HTMLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(HTMLModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("unchecked_CommonContent"))).Click();
            Sleep(5);
            
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnFirstUrlInContentSpecificUrlsAfterEditContent"))).Click();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlContentSpecific"))).SendKeys(_textAreaAfterClickOnHtmlModuleEdit);
            System.Threading.Thread.Sleep(3000);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnPublishBtnAfterUnCheckedTheContentSpecific"))).Click();
            TestEnvironment.Driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(3000);

        }

        public void EditInContentSpecificModulesForDraft(string _textAreaAfterClickOnHtmlModuleEdit)
        {

            IWebElement HTMLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(HTMLModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("unchecked_CommonContent"))).Click();
            Sleep(5);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnFirstUrlInContentSpecificUrlsAfterEditContent"))).Click();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlContentSpecific"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("TextAreaAfterClickOnHtmlContentSpecific"))).SendKeys(_textAreaAfterClickOnHtmlModuleEdit);
            System.Threading.Thread.Sleep(3000);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnDraftBtnAfterUnCheckedTheContentSpecific"))).Click();
           // TestEnvironment.Driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(3000);

        }



        public void SelectUrlsInCreatedNewContectSpecificModulesForPublish(string baseUrl)
        {
            string basicUrl = baseUrl;
            IWebElement HTMLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(HTMLModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("HTMLModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);
            XPathtoClick("unchecked_CommonContent", 4);

            //Get last url of content specific url for module only.
            List<IWebElement> UrlsInCSUforModules = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("UrlsInCSUforModules"))).FindElements(By.TagName("tr")).ToList();
            var actualNoOfRecords = UrlsInCSUforModules.Count().ToString();
            string ValueInlst = ByXpath("UrlsInCSUforModules", 5); //Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML("LaunchedGridDetails"))).Text;
            string arraylst = ValueInlst.Replace("Preview Publish ", "");
            string[] incomingurlValue = arraylst.Replace("\r\n", "_").Split("_".ToCharArray());

            string firstContentSpecificurl = baseUrl + incomingurlValue[0];
            string secondContentSpecificurl = baseUrl + incomingurlValue[1];
            string thirdContentSpecificurl = baseUrl + incomingurlValue[2];
            string fourthContentSpecificurl = baseUrl + incomingurlValue[3];

            TestEnvironment.Driver.FindElement(By.LinkText(TestEnvironment.LoadXML("LogOut"))).Click();
            IWebElement bodyForFirstUrl = TestEnvironment.Driver.FindElement(By.TagName("body"));
            bodyForFirstUrl.SendKeys(Keys.Control + 't');
            TestEnvironment.Driver.Navigate().GoToUrl(thirdContentSpecificurl);
            Sleep(3);

            IWebElement bodyForSecondUrl = TestEnvironment.Driver.FindElement(By.TagName("body"));
            bodyForSecondUrl.SendKeys(Keys.Control + 't');
            TestEnvironment.Driver.Navigate().GoToUrl(fourthContentSpecificurl);
            Sleep(3);

            IWebElement bodyForThirdUrl = TestEnvironment.Driver.FindElement(By.TagName("body"));
            bodyForThirdUrl.SendKeys(Keys.Control + 't');
            TestEnvironment.Driver.Navigate().GoToUrl(secondContentSpecificurl);
            Sleep(3);

            IWebElement bodyForFourthUrl = TestEnvironment.Driver.FindElement(By.TagName("body"));
            bodyForFourthUrl.SendKeys(Keys.Control + 't');
            TestEnvironment.Driver.Navigate().GoToUrl(firstContentSpecificurl);
            Sleep(3);

        }


        public void AddingNewHtmlModule(string _titleModule2, string _editContentMultiLineTextBoxForPublish, string _editContentMultiLineTextBoxForDraft)
        {
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EnterTitleForModule"))).SendKeys(_titleModule2);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnModuleAddBtn"))).Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement imgsourceForEditContent2 = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("imgSource2")));
            //IWebElement imgtargetForEditContent = Driver.FindElement(By.CssSelector("target"));

            new Actions(TestEnvironment.Driver).MoveToElement(imgsourceForEditContent2).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath("html/body/form/div[2]/div/div/div[6]/div/div/div/div/table/tbody/tr/td[2]/div[2]/div[1]/div[1]/span/span/table[1]/tbody/tr[1]/td[2]/span")).Click();

            System.Threading.Thread.Sleep(2000);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxForBoth"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxForBoth"))).SendKeys(_editContentMultiLineTextBoxForPublish);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxPublish"))).Click();
            TestEnvironment.Driver.SwitchTo().Alert().Accept();



            //string EditContentMultiLineTextBoxForPublish = Record("EditContentMultiLineTextBoxForPublish");
            IWebElement imgsourceForEditContent2again = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("imgSource2")));
            new Actions(TestEnvironment.Driver).MoveToElement(imgsourceForEditContent2again).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath("html/body/form/div[2]/div/div/div[6]/div/div/div/div/table/tbody/tr/td[2]/div[2]/div[1]/div[1]/span/span/table[1]/tbody/tr[1]/td[2]/span")).Click();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxForBoth"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxForBoth"))).SendKeys(_editContentMultiLineTextBoxForDraft);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EditContentMultiLineTextBoxDraft"))).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void EditingExistingHtmlModule(string _module, string _clickOnEditContent)
        {
            IWebElement ModuleImageSourceCheckIfPresent = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(_module)));

            new Actions(TestEnvironment.Driver).MoveToElement(ModuleImageSourceCheckIfPresent).Build().Perform();

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(_clickOnEditContent))).Click();

            try
            {
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            { }

        }


        
    }
}

