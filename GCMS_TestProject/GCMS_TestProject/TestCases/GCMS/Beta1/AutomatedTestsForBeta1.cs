using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCMS_TestProject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using GCMS_TestProject.Library;
using GCMS_TestProject.Utility;


namespace GCMS_TestProject.TestCases
{
    [TestClass]
    public class AutomatedTestsForBeta1
    {

        GcmsUtitlity obj = new GcmsUtitlity();
        [TestInitialize]
        public void Initialize()
        {

            GCMS_TestProject.Library.TestEnvironment.Init();

        }
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public string Record(string columnName_)
        {
            return TestContext.DataRow[columnName_].ToString();
        }


    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ForHTML_Module.csv", "ForHTML_Module#csv", DataAccessMethod.Sequential), DeploymentItem("GCMS_TestProject\\ForHTML_Module.csv"), DeploymentItem("Eclips\\ForHTML_Module.csv"), TestMethod()]
        public void JustToSignInOnly()
        {
            IWebDriver Driver = GCMS_TestProject.Library.TestEnvironment.Driver;

            string GCMS_admin_url = Record("Url");

            Driver.Navigate().GoToUrl(GCMS_admin_url);
            string username = Record("UserName");
            string pass = Record("Password");
            ClickLoginAndSetSignInValues(username, pass);
            obj.Sleep(5);
        }

        [DeploymentItem("GCMS_TestProject\\AppData\\ContentSpecificUrl_InHTMLModule.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ContentSpecificUrl_InHTMLModule.csv", "ContentSpecificUrl_InHTMLModule#csv", DataAccessMethod.Sequential), TestMethod]
        public void ContentSpecificUrl_InHTMLModule()
        {
            IWebDriver Driver = TestEnvironment.Driver;
            //GCMS_Admin obj = new GCMS_Admin();
            string GCMS_admin_url = Record("Url");

            Driver.Navigate().GoToUrl(GCMS_admin_url);
            string tabid = Record("Tabid");
            string[] getTabid = tabid.Split(",".ToCharArray());

            string getUrl = GCMS_admin_url + "?tabid=" + getTabid[1];
            Driver.Navigate().GoToUrl(getUrl);
            obj.Sleep(5);

            string _findModule = "HTMLModuleImageSource";
            string _deleteModule = "HTMLModuleDelete";
            obj.FindModulePresent(_findModule, _deleteModule);
            string TitleOfHTML = Record("TitleOfHTML");//for text box from csv.            
            obj.CreateNewModuleName(TitleOfHTML);
            obj.Sleep(4);
            Random randomNum = new Random();
            int num = randomNum.Next(5, 100);

            string EditContentMultiLineTextBoxForAllUrlsForPublish = Record("EditContentMultiLineTextBoxForAllUrlsForPublish") + num;
            obj.EditInCreatedNewModulesForPublish(EditContentMultiLineTextBoxForAllUrlsForPublish);
            string EditContentMultiLineTextBoxForAllUrlsForDraft = Record("EditContentMultiLineTextBoxForAllUrlsForDraft") + num;
            obj.EditInCreatedNewModulesForDraft(EditContentMultiLineTextBoxForAllUrlsForDraft);
            //ByLinkTextToClick("LogOut", 5);
            obj.Sleep(4);

            string preview2Url = Record("Preview2Url");
            string preview1Url = Record("Preview1Url");
            string moduleName = "HTMLModule";
            obj.CompareOutputInChromeForPreview1(preview1Url, EditContentMultiLineTextBoxForAllUrlsForDraft, moduleName);
            obj.CompareOutputInChromeForPreview2(preview2Url, EditContentMultiLineTextBoxForAllUrlsForPublish, moduleName);
            obj.Sleep(4);

            Driver.Navigate().GoToUrl(getUrl);
            obj.Sleep(5);
            string EditContentMultiLineTextBoxForPublishForContentSpecific = Record("EditContentMultiLineTextBoxForPublishForContentSpecific") + num;
            obj.EditInContentSpecificModulesForPublish(EditContentMultiLineTextBoxForPublishForContentSpecific);
            obj.Sleep(5);
           
            string EditContentMultiLineTextBoxForDraftForContentSpecific = Record("EditContentMultiLineTextBoxForDraftForContentSpecific") + num;
            obj.EditInContentSpecificModulesForDraft(EditContentMultiLineTextBoxForDraftForContentSpecific);
            obj.Sleep(4);
            string Preview2Url_ForContentSpecificUrl = Record("Preview2Url_ForContentSpecificUrl");
            string Preview1Url_ForContentSpecificUrl = Record("Preview1Url_ForContentSpecificUrl");
            obj.CompareOutputInChromeForPreview1(Preview1Url_ForContentSpecificUrl, EditContentMultiLineTextBoxForDraftForContentSpecific, moduleName);
            obj.CompareOutputInChromeForPreview2(Preview2Url_ForContentSpecificUrl, EditContentMultiLineTextBoxForPublishForContentSpecific, moduleName);

        }

        [DeploymentItem("GCMS_TestProject\\ForHTML_Module.csv"), DeploymentItem("Eclips\\ForHTML_Module.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ForHTML_Module.csv", "ForHTML_Module#csv", DataAccessMethod.Sequential), TestMethod]
        public void ForHTML_Module()
        {
            IWebDriver Driver = GCMS_TestProject.Library.TestEnvironment.Driver;

            string GCMS_admin_url = Record("Url");

            Driver.Navigate().GoToUrl(GCMS_admin_url);
            //ClickLoginAndSetSignInValues();
            //   Sleep(5);
            string tabid = Record("Tabid");
            string[] getTabid = tabid.Split(",".ToCharArray());

            string getUrl = GCMS_admin_url + "?tabid=" + getTabid[1];
            Driver.Navigate().GoToUrl(getUrl);
            obj.Sleep(5);

            string _findModule = "HTMLModuleImageSource";
            string _deleteModule = "HTMLModuleDelete";
            // string _editContent = "HTMLModuleImageSourceEdit";


            //adding text in HTML module.
            // for New HTML Title.                    
            obj.FindModulePresent(_findModule, _deleteModule);
            string TitleOfHTML = Record("TitleOfHTML");//for text box from csv.            
            obj.CreateNewModuleName(TitleOfHTML);
            obj.Sleep(4);
            Random randomNum = new Random();
            int num = randomNum.Next(5, 100);
            string EditContentMultiLineTextBoxForAllUrlsForPublish = Record("EditContentMultiLineTextBoxForAllUrlsForPublish") + num;
            obj.EditInCreatedNewModulesForPublish(EditContentMultiLineTextBoxForAllUrlsForPublish);
            string EditContentMultiLineTextBoxForAllUrlsForDraft = Record("EditContentMultiLineTextBoxForAllUrlsForDraft") + num;
            obj.EditInCreatedNewModulesForDraft(EditContentMultiLineTextBoxForAllUrlsForDraft);

            obj.Sleep(4);

            string preview2Url = Record("Preview2Url");
            string preview1Url = Record("Preview1Url");
            string moduleName = "HTMLModule";
            obj.CompareOutputInChromeForPreview1(preview1Url, EditContentMultiLineTextBoxForAllUrlsForDraft, moduleName);
            obj.CompareOutputInChromeForPreview2(preview2Url, EditContentMultiLineTextBoxForAllUrlsForPublish, moduleName);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ForRSSFeed.csv", "ForRSSFeed#csv", DataAccessMethod.Sequential), DeploymentItem("Eclips\\ForRSSFeed.csv"), DeploymentItem("GCMS_TestProject\\ForRSSFeed.csv"), TestMethod]
        public void ForRSSFeed()
        {
            IWebDriver Driver = GCMS_TestProject.Library.TestEnvironment.Driver;

            string GCMS_admin_url = Record("Url");
            Driver.Navigate().GoToUrl(GCMS_admin_url);
            obj.Sleep(5);
            string tabid = Record("Tabid");
            string[] getTabid = tabid.Split(",".ToCharArray());
            string getUrl = GCMS_admin_url + "?tabid=" + getTabid[1];
            Driver.Navigate().GoToUrl(getUrl);
            obj.Sleep(5);
            string _findModule = "RSSFeedModuleImageSource";
            string _deletingModule = "RSSFeedModuleDelete";
            obj.FindModulePresent(_findModule, _deletingModule);
            obj.SelectNewRssFeedModule();//for RssFeed Dropdown selection.
            obj.Sleep(3);
            string TitleOfRSS = Record("TitleOfRSS"); // for RssFeed Title.
            obj.CreateNewModuleName(TitleOfRSS);

            string PrimaryURL = Record("PrimaryURL");
            string PrimaryHeaderTemplatePublish = Record("PrimaryHeaderTemplateForPublish");
            string ItemTemplate = Record("ItemTemplate");
            string NoofRecords = Record("NoofRecords");
            string NoofColumns = Record("NoofColumns");
            string FooterTemplate = Record("FooterTemplate");
            obj.setValuesForEditRssFeedmoduleForPublish(PrimaryURL, PrimaryHeaderTemplatePublish, ItemTemplate, NoofRecords, NoofColumns, FooterTemplate); //for RssFeed Edit for publish.
            obj.Sleep(3);
            string PrimaryHeaderTemplateForDraft = Record("PrimaryHeaderTemplateForDraft");
            obj.setValuesForEditRssFeedmoduleForDraft(PrimaryURL, PrimaryHeaderTemplateForDraft, ItemTemplate, NoofRecords, NoofColumns, FooterTemplate); //for RssFeed Edit for draft.
            Random randomNum = new Random();
            int num = randomNum.Next(5, 100);

            string preview2Url = Record("Preview2Url");
            string preview1Url = Record("Preview1Url");
            string moduleName = "SQLModule";
            obj.CompareOutputInChromeForPreview1(preview1Url, Record("PrimaryHeaderTemplateForDraft"), moduleName);
            obj.CompareOutputInChromeForPreview2(preview2Url, Record("PrimaryHeaderTemplateForPublish"), moduleName);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ForSqlModule.csv", "ForSqlModule#csv", DataAccessMethod.Sequential), DeploymentItem("Eclips\\ForSqlModule.csv"), DeploymentItem("GCMS_TestProject\\ForSqlModule.csv"), TestMethod]
        public void ForSqlModule()
        {
            IWebDriver Driver = GCMS_TestProject.Library.TestEnvironment.Driver;

            string GCMS_admin_url = Record("Url");
            Driver.Navigate().GoToUrl(GCMS_admin_url);           
            obj.Sleep(5);
            string tabid = Record("Tabid");
            string[] getTabid = tabid.Split(",".ToCharArray());

            string getUrl = GCMS_admin_url + "?tabid=" + getTabid[1];
            Driver.Navigate().GoToUrl(getUrl);
            obj.Sleep(5);

            string _findModule = "SQLTestTemplateOfNewTestTemplate";
         
            string _deleteModule = "SQLModuleDelete";
            obj.FindModulePresent(_findModule, _deleteModule); //To delete eralier one.
          
            obj.selectNewSQLModuleFromDropDown();
            //To Create new SqlModule.  
            string TitleOfSQL = Record("TitleOfSQL");
            obj.CreateNewModuleName(TitleOfSQL);

            //For CMS-SQL Edit
            string _sqlModule = "SQLTestTemplateOfNewTestTemplate"; //xpath element same as abv.
            string _sqlModuleEdit = "SQLModuleEditOfNewTestTemplate";

            string SQLSelect_DataSource = Record("SQLSelect DataSource");
            string SQLHeaderTemplateForPublish = Record("SQLHeader Template For Publish");
            //string SQLHeaderTemplateForDraft = Record("SQLHeaderTemplateForDraft");
            string SQLItemTemplate = Record("SQLItem Template");
            string SQLfooterTemplate = Record("SQLFooter Template");
            string SQLNumberOfRecords = Record("SQLNumber Of Records");
            string SQLNumberOfColumns = Record("SQLNumber Of Columns");
            obj.setValuesForEditSQLmoduleForPublish(_sqlModule, _sqlModuleEdit, SQLSelect_DataSource, SQLHeaderTemplateForPublish, SQLItemTemplate, SQLfooterTemplate, SQLNumberOfRecords, SQLNumberOfColumns);
            obj.Sleep(4);
          
            string SQLHeaderTemplateForDraft = Record("SQLHeader Template For Draft");
            obj.setValuesForEditSQLmoduleForDraft(_sqlModule, _sqlModuleEdit, SQLSelect_DataSource, SQLHeaderTemplateForDraft, SQLItemTemplate, SQLfooterTemplate, SQLNumberOfRecords, SQLNumberOfColumns);
            obj.Sleep(4);
            Random randomNum = new Random();
            int num = randomNum.Next(5, 100);
            string moduleName = Record("ModuleName");//"SQLModule";              
            string preview2Url = Record("Preview2Url");
            string preview1Url = Record("Preview1Url");

            obj.CompareOutputInChromeForPreview1(preview1Url, "For Draft", moduleName);
            obj.CompareOutputInChromeForPreview2(preview2Url, "For Publish", moduleName);

        }
       
        public void ClickLoginAndSetSignInValues(string userName, string password)
        {
            obj.CsstoClick("LoginLink", 6);
            obj.CssToSetText("UserName", userName, 60);
            obj.CssToSetText("Password", password, 60);
            obj.Sleep(3);
        }

        [DeploymentItem("GCMS_TestProject\\AppData\\ForHTML_Module.csv"), DeploymentItem("GCMS_TestProject\\ExcelUpload.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ExcelUpload.csv", "ExcelUpload#csv", DataAccessMethod.Sequential), TestMethod]
        public void ForExcelUpload()
        {
            IWebDriver Driver = TestEnvironment.Driver;
            string GCMS_admin_url = Record("Url");

            Driver.Navigate().GoToUrl(GCMS_admin_url);
            string tabid = Record("Tabid");
            string[] getTabid = tabid.Split(",".ToCharArray());

            string getUrl = GCMS_admin_url + "?tabid=" + getTabid[1];
            Driver.Navigate().GoToUrl(getUrl);
            obj.Sleep(5);

            string _findExcelModule = "TestExcelUploadModule";
            string _deleteExcelModule = "TestExcelUploaddelete"; 
            obj.FindModulePresent(_findExcelModule, _deleteExcelModule); //To delete eralier one.

            obj.selectNewExcelModuleFromDropDown();
            //To Create new SqlModule.  
            string TitleOfExcel = Record("TitleOfExcel");
            obj.CreateNewModuleName(TitleOfExcel);


            //For CMS-SQL Edit
            string _excelModule = "ExcelTestTemplateOfNewTestTemplate"; //xpath element same as abv.
            string _excelModuleEdit = "ExcelModuleEditOfNewTestTemplate";

            string selectExcelFile = "SelectExcelFile";
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(selectExcelFile))).Click();

            string excelHeaderTemplate = Record("ExcelHeader Template For Publish");
            string excelItemTemplate = Record("ExcelItem Template");
            string excelfooterTemplate = Record("ExcelFooter Template");
            string excelNumberOfRecords = Record("ExcelNumber Of Records");
            string excelNumberOfColumns = Record("ExcelNumber Of Columns");
            obj.setValuesForEditExcelmoduleForPublish(_excelModule, _excelModuleEdit, excelHeaderTemplate, excelItemTemplate, excelfooterTemplate, excelNumberOfRecords, excelNumberOfColumns);
            obj.Sleep(4);

            string SQLHeaderTemplateForDraft = Record("SQLHeader Template For Draft");
            obj.setValuesForEditExcelmoduleForDraft(_excelModule, _excelModuleEdit, SQLHeaderTemplateForDraft, excelItemTemplate, excelfooterTemplate, excelNumberOfRecords, excelNumberOfColumns);
            obj.Sleep(4);

            string moduleName = Record("ModuleName");//"SQLModule";              
            string preview2Url = Record("Preview2Url");
            string preview1Url = Record("Preview1Url");

            obj.CompareOutputInChromeForPreview1(preview1Url, "For Draft", moduleName);
            obj.CompareOutputInChromeForPreview2(preview2Url, "For Publish", moduleName);

        }

        [DeploymentItem("GCMS_TestProject\\AppData\\ForHTML_Module.csv"), DeploymentItem("GCMS_TestProject\\ExcelUpload.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ExcelUpload.csv", "ExcelUpload#csv", DataAccessMethod.Sequential), TestMethod]
        public void ForFileExplorer() 
        {
            IWebDriver Driver = TestEnvironment.Driver;
            string GCMS_admin_url = Record("Url");

            Driver.Navigate().GoToUrl(GCMS_admin_url);
            string tabid = Record("Tabid");
            string[] getTabid = tabid.Split(",".ToCharArray());

            string getUrl = GCMS_admin_url + "?tabid=" + getTabid[1];
            Driver.Navigate().GoToUrl(getUrl);
            obj.Sleep(5);

            string _findExcelModule = "TestFileExplorerModule";
            string _deleteExcelModule = "TestFileExplorerUploaddelete";
            obj.FindModulePresent(_findExcelModule, _deleteExcelModule); //To delete eralier one.

            obj.selectNewExcelModuleFromDropDown();
            //To Create new SqlModule.  
            string TitleOfExcel = Record("TitleOfFileExplorer");
            obj.CreateNewModuleName(TitleOfExcel);


            //For CMS-SQL Edit
            string _excelModule = "FileExplorerTestTemplateOfNewTestTemplate"; //xpath element same as abv.
            string _excelModuleEdit = "FileExplorerModuleEditOfNewTestTemplate";

            string selectExcelFile = "SelectExcelFile";
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(selectExcelFile))).Click();

            string excelHeaderTemplate = Record("ExcelHeader Template For Publish");
            string excelItemTemplate = Record("ExcelItem Template");
            string excelfooterTemplate = Record("ExcelFooter Template");
            string excelNumberOfRecords = Record("ExcelNumber Of Records");
            string excelNumberOfColumns = Record("ExcelNumber Of Columns");
            obj.setValuesForEditExcelmoduleForPublish(_excelModule, _excelModuleEdit, excelHeaderTemplate, excelItemTemplate, excelfooterTemplate, excelNumberOfRecords, excelNumberOfColumns);
            obj.Sleep(4);

            string SQLHeaderTemplateForDraft = Record("SQLHeader Template For Draft");
            obj.setValuesForEditExcelmoduleForDraft(_excelModule, _excelModuleEdit, SQLHeaderTemplateForDraft, excelItemTemplate, excelfooterTemplate, excelNumberOfRecords, excelNumberOfColumns);
            obj.Sleep(4);

            string moduleName = Record("ModuleName");//"SQLModule";              
            string preview2Url = Record("Preview2Url");
            string preview1Url = Record("Preview1Url");

            obj.CompareOutputInChromeForPreview1(preview1Url, "For Draft", moduleName);
            obj.CompareOutputInChromeForPreview2(preview2Url, "For Publish", moduleName);

        }

    }
}
