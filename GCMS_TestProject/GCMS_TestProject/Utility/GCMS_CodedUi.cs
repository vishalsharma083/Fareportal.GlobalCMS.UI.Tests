using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using GCMS_TestProject.Library;

namespace GCMS_TestProject.Utility
{
    public class GCMS_CodedUi
    {
        public ArrayList GetElementsByTagName(string FileName, string ParentTag)
        {
            XmlDocument myXML = TestEnvironment.GetXml(TestEnvironment.FlightEngine, FileName);
            System.Xml.XmlElement root = myXML.DocumentElement;
            System.Xml.XmlNodeList lst = root.GetElementsByTagName(ParentTag)[0].ChildNodes;
            ArrayList arrList = new ArrayList(lst.Count);
            ArrayList items = new ArrayList();
            foreach (System.Xml.XmlNode node in lst)
            {
                arrList.Add(node);
            }
            foreach (XmlElement item in arrList)
            {
                items.Add(item.InnerXml.ToString());
            }
            return items;
        }
        public void CssToSetText(string xmlTagName_, string testCaseValue_, int Time_WaitForElementPresent)
        {
            string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
            try
            {
                TestEnvironment.WaitForElementPresent(By.CssSelector(XMLValue), Time_WaitForElementPresent);


                var element = TestEnvironment.Driver.FindElement(By.CssSelector(XMLValue));
                if (!String.IsNullOrEmpty(testCaseValue_))
                {
                    element.Clear();
                    element.SendKeys(testCaseValue_);
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }


        public void XPathToSetText(string xmlTagName_, string testCaseValue_, int Time_WaitForElementPresent)
        {
            string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
            try
            {
                TestEnvironment.WaitForElementPresent(By.XPath(XMLValue), Time_WaitForElementPresent);


                var element = TestEnvironment.Driver.FindElement(By.XPath(XMLValue));
                if (!String.IsNullOrEmpty(testCaseValue_))
                {
                    element.Clear();
                    element.SendKeys(testCaseValue_);
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }


        public void CsstoClick(string xmlTagName_, int Time_WaitForElementPresent)
        {
            try
            {
                string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
                TestEnvironment.WaitForElementPresent(By.CssSelector(XMLValue), Time_WaitForElementPresent);
                var element = TestEnvironment.Driver.FindElement(By.CssSelector(XMLValue));
                element.Click();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate/click the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }

        public void XPathtoClick(string xmlTagName_, int Time_WaitForElementPresent)
        {
            try
            {
                string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
                TestEnvironment.WaitForElementPresent(By.XPath(XMLValue), Time_WaitForElementPresent);
                var element = TestEnvironment.Driver.FindElement(By.XPath(XMLValue));
                element.Click();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate/click the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }


        public static void XpathtoClear(string xmlTagName_, int Time_WaitForElementPresent)
        {
            try
            {
                string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
                TestEnvironment.WaitForElementPresent(By.CssSelector(XMLValue), Time_WaitForElementPresent);
                var element = TestEnvironment.Driver.FindElement(By.CssSelector(XMLValue));
                element.Clear();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate/click the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }


        public void IDtoClick(string xmlTagName_, int Time_WaitForElementPresent)
        {
            try
            {
                string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
                TestEnvironment.WaitForElementPresent(By.Id(XMLValue), Time_WaitForElementPresent);
                var element = TestEnvironment.Driver.FindElement(By.Id(XMLValue));
                element.Click();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate/click the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }

        public void ByLinkTextToClick(string xmlTagName_, int Time_WaitForElementPresent)
        {
            try
            {
                string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
                TestEnvironment.WaitForElementPresent(By.LinkText(XMLValue), Time_WaitForElementPresent);
                var element = TestEnvironment.Driver.FindElement(By.LinkText(XMLValue));
                element.Click();
            }
            catch (Exception ex)
            {

                throw new NotFoundException("Not able to locate/click the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }

        public bool IsDisplayedUsingXpath(string XMLValue)
        {
            try
            {
                return TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(XMLValue))).Displayed;
            }
            catch { return false; }
        }

        public string ValidationMessageByCss(string xmlTageName_, int Time_WaitForElementPresent)
        {
            string XMLValue = TestEnvironment.LoadXML(xmlTageName_);
            try
            {
                TestEnvironment.WaitForElementPresent(By.CssSelector(XMLValue), Time_WaitForElementPresent);
                return TestEnvironment.Driver.FindElement(By.CssSelector(XMLValue)).Text;
            }
            catch (Exception ex)
            {

                throw new Exception("Not able to Grab the validation for the element<" + xmlTageName_ + "> even after " + Time_WaitForElementPresent + " secs. EXCEPTION: " + ex);
            }
        }

        public string ByXpath(string xmlTagName_, int Time_WaitForElementPresent)
        {
            string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
            try
            {
                TestEnvironment.WaitForElementPresent(By.XPath(XMLValue), Time_WaitForElementPresent);
                return TestEnvironment.Driver.FindElement(By.XPath(XMLValue)).Text;
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate/click the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }

        public string ByCss(string xmlTagName_, int Time_WaitForElementPresent)
        {
            string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
            try
            {
                TestEnvironment.WaitForElementPresent(By.CssSelector(XMLValue), Time_WaitForElementPresent);
                return TestEnvironment.Driver.FindElement(By.CssSelector(XMLValue)).Text;
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Not able to locate/click the element <" + xmlTagName_ + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }

        public string GrabAttributeValueByCss(string xmlTagName_, string attribute_, int Time_WaitForElementPresent)
        {
            string XMLValue = TestEnvironment.LoadXML(xmlTagName_);
            try
            {
                string attribute = attribute_;
                // LoadAndWaitID(xmlTagName_ 20);
                Sleep(1);
                string AttributeValue = TestEnvironment.Driver.FindElement(By.CssSelector(XMLValue)).GetAttribute(attribute);
                return AttributeValue;
            }
            catch (Exception ex)
            {

                throw new NotFoundException(xmlTagName_ + "Element found on the page, attribute not found <" + "> even after " + Time_WaitForElementPresent + " secs. " + "EXCEPTION: " + ex);
            }
        }

        public bool FindModulePresent(string _module, string _deleteModule)
        {
            IWebElement ModuleImageSourceCheckIfPresent = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(_module)));

            new Actions(TestEnvironment.Driver).MoveToElement(ModuleImageSourceCheckIfPresent).Build().Perform();

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(_deleteModule))).Click();


            try
            {
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            { }
            return true;
        }

        public void FindModuleAndEdit(string _module, string _editValues)
        {
            IWebElement ModuleImageSourceCheckIfPresent = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(_module)));

            new Actions(TestEnvironment.Driver).MoveToElement(ModuleImageSourceCheckIfPresent).Build().Perform();

            //Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML(_deleteModule))).Click();


            try
            {
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            { }

        }



        public void CreateNewModuleName(string _moduleName)
        {
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("EnterTitleForModule"))).SendKeys(_moduleName);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnModuleAddBtn"))).Click();
            Sleep(4);
        }

        public void selectNewFileModuleFromDropDown()
        {
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("DropDownTitleModule3"))).Click();
            Sleep(4);
            IWebElement sourceForFileExplorer = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectFileExplorerFromDropDown")));
            System.Threading.Thread.Sleep(3000);
            new Actions(TestEnvironment.Driver).MoveToElement(sourceForFileExplorer).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectFileExplorerFromDropDown"))).Click();
        }

        public void EditInFileExplorerModule()
        {
            IWebElement FileExplorerModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("FileExplorerModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(FileExplorerModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("FileExplorerModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);
            TestEnvironment.Driver.FindElement(By.LinkText(TestEnvironment.LoadXML("whybook"))).Click();
            TestEnvironment.Driver.FindElement(By.LinkText(TestEnvironment.LoadXML("why-choose3.txt"))).Click();
            System.Threading.Thread.Sleep(2000);
            TestEnvironment.Driver.FindElement(By.LinkText(TestEnvironment.LoadXML("whybook"))).Click();

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnPublishBtnWhileAddingFileExplorer"))).Click();
            TestEnvironment.Driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(9000);
            // Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML("ClickOnCancelBtn"))).Click();
        }

        public void SelectNewRssFeedModule()
        {
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("DropDownTitleModule3"))).Click();
            IWebElement sourceForRSS = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectRssFeedModuleFromDropDown")));
            System.Threading.Thread.Sleep(3000);
            new Actions(TestEnvironment.Driver).MoveToElement(sourceForRSS).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectRssFeedModuleFromDropDown"))).Click();
            System.Threading.Thread.Sleep(3000);
        }

        public void EditInRssFeedModuleForPublish(string _primaryURL, string _primaryHeaderTemplate, string _itemTemplate, string _noofRecords, string _noofColumns, string _footerTemplate)
        {
            IWebElement RSSFeedModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("RSSFeedModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(RSSFeedModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("RSSFeedModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("PrimaryURL"))).SendKeys(_primaryURL);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("PrimaryHeaderTemplateForPublish"))).SendKeys(_primaryHeaderTemplate);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ItemTemplate"))).SendKeys(_itemTemplate);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("NoofRecords"))).SendKeys(_noofRecords);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("NoofColumns"))).SendKeys(_noofColumns);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("FooterTemplate"))).SendKeys(_footerTemplate);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnPublishBtnWhileAddingRSSFeed"))).Click();
            TestEnvironment.Driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(9000);

        }

        public void EditInRssFeedModuleForDraft(string _primaryURL, string _primaryHeaderTemplate, string _itemTemplate, string _noofRecords, string _noofColumns, string _footerTemplate)
        {
            IWebElement RSSFeedModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("RSSFeedModuleImageSource")));
            new Actions(TestEnvironment.Driver).MoveToElement(RSSFeedModuleImageSource).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("RSSFeedModuleImageSourceEdit"))).Click();
            System.Threading.Thread.Sleep(4000);
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("PrimaryURL"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("PrimaryURL"))).SendKeys(_primaryURL);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("PrimaryHeaderTemplateForDraft"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("PrimaryHeaderTemplateForDraft"))).SendKeys(_primaryHeaderTemplate);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ItemTemplate"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ItemTemplate"))).SendKeys(_itemTemplate);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("NoofRecords"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("NoofRecords"))).SendKeys(_noofRecords);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("NoofColumns"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("NoofColumns"))).SendKeys(_noofColumns);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("FooterTemplate"))).Clear();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("FooterTemplate"))).SendKeys(_footerTemplate);

            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ClickOnDraftBtnWhileAddingRSSFeed"))).Click();
            // Environment.Driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(9000);

        }

        public void selectNewSQLModuleFromDropDown()
        {
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("DropDownTitleModule3"))).Click();
            IWebElement sourceForCMSSql = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectSQLModuleFromDropDown")));
            System.Threading.Thread.Sleep(3000);
            new Actions(TestEnvironment.Driver).MoveToElement(sourceForCMSSql).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectSQLModuleFromDropDown"))).Click();
            System.Threading.Thread.Sleep(4000);
        }

        public void selectNewExcelModuleFromDropDown() 
        {
            TestEnvironment.Driver.FindElement(By.CssSelector(TestEnvironment.LoadXML("DropDownTitleModule3"))).Click();
            IWebElement sourceForCMSSql = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectExcelModuleFromDropDown")));
            System.Threading.Thread.Sleep(3000);
            new Actions(TestEnvironment.Driver).MoveToElement(sourceForCMSSql).Build().Perform();
            TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("selectExcelModuleFromDropDown"))).Click();
            System.Threading.Thread.Sleep(4000);
        }


        public void EditInSqlModuleForPublish(string SQLModule, string SQLModuleEdit, string _sqlSelect_DataSource, string _sqlHeaderTamplateForPublish, string _sqlItemTemplate, string _sqlfooterTemplate, string _sqlNumberOfRecords, string _sqlNumberOfColumns)
        {

            if (!string.IsNullOrEmpty(SQLModule) && !string.IsNullOrEmpty(SQLModuleEdit))
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(SQLModule)));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(SQLModuleEdit))).Click();
                System.Threading.Thread.Sleep(4000);



                var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLSelect_DataSource")));
                var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                selectelementSelect_DataSource.SelectByText(_sqlSelect_DataSource);


                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLHeaderTamplate"))).SendKeys(_sqlHeaderTamplateForPublish);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLItemTemplate"))).SendKeys(_sqlItemTemplate);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLfooterTemplate"))).SendKeys(_sqlfooterTemplate);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfRecords"))).SendKeys(_sqlNumberOfRecords);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfColumns"))).SendKeys(_sqlNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLPublish"))).Click();
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
            else
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLModuleImageSource")));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLModuleImageSourceEdit"))).Click();
                System.Threading.Thread.Sleep(4000);



                var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLSelect_DataSource")));
                var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                selectelementSelect_DataSource.SelectByText(_sqlSelect_DataSource);


                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLHeaderTamplate"))).SendKeys(_sqlHeaderTamplateForPublish);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLItemTemplate"))).SendKeys(_sqlItemTemplate);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLfooterTemplate"))).SendKeys(_sqlfooterTemplate);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfRecords"))).SendKeys(_sqlNumberOfRecords);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfColumns"))).SendKeys(_sqlNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLPublish"))).Click();
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
        }


        public void EditInSqlModuleForDraft(string SQLModule, string SQLModuleEdit, string _sqlSelect_DataSource, string _sqlHeaderTamplateForDraft, string _sqlItemTemplate, string _sqlfooterTemplate, string _sqlNumberOfRecords, string _sqlNumberOfColumns)
        {

            if (!string.IsNullOrEmpty(SQLModule) && !string.IsNullOrEmpty(SQLModuleEdit))
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(SQLModule)));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(SQLModuleEdit))).Click();
                System.Threading.Thread.Sleep(4000);



                var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLSelect_DataSource")));
                var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                selectelementSelect_DataSource.SelectByText(_sqlSelect_DataSource);


                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLHeaderTamplate"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLHeaderTamplate"))).SendKeys(_sqlHeaderTamplateForDraft);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLItemTemplate"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLItemTemplate"))).SendKeys(_sqlItemTemplate);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLfooterTemplate"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLfooterTemplate"))).SendKeys(_sqlfooterTemplate);
                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfRecords"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfRecords"))).SendKeys(_sqlNumberOfRecords);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfColumns"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfColumns"))).SendKeys(_sqlNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLDraft"))).Click();
                // Environment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
            else
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLModuleImageSource")));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLModuleImageSourceEdit"))).Click();
                System.Threading.Thread.Sleep(4000);



                var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLSelect_DataSource")));
                var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                selectelementSelect_DataSource.SelectByText(_sqlSelect_DataSource);


                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLHeaderTamplate"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLHeaderTamplate"))).SendKeys(_sqlHeaderTamplateForDraft);
                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLItemTemplate"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLItemTemplate"))).SendKeys(_sqlItemTemplate);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLfooterTemplate"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLfooterTemplate"))).SendKeys(_sqlfooterTemplate);
                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfRecords"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfRecords"))).SendKeys(_sqlNumberOfRecords);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfColumns"))).Clear();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLNumberOfColumns"))).SendKeys(_sqlNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLDraft"))).Click();
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
        }


        public void EditInExcelModuleForPublish(string ExcelModule, string ExcelModuleEdit, string _ExcelHeaderTamplateForPublish, string _ExcelItemTemplate, string _ExcelfooterTemplate, string _ExcelNumberOfRecords, string _ExcelNumberOfColumns)
        {

            if (!string.IsNullOrEmpty(ExcelModule) && !string.IsNullOrEmpty(ExcelModuleEdit))
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(ExcelModule)));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(ExcelModuleEdit))).Click();
                System.Threading.Thread.Sleep(4000);


                //TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("_SelectExcelFile"))).Click();
                
                //var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("SQLExcel_File")));
                //var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                //selectelementSelect_DataSource.SelectByText(_SelectExcelFile);


                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelHeaderTamplate"))).SendKeys(_ExcelHeaderTamplateForPublish);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelItemTemplate"))).SendKeys(_ExcelItemTemplate);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelfooterTemplate"))).SendKeys(_ExcelfooterTemplate);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfRecords"))).SendKeys(_ExcelNumberOfRecords);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfColumns"))).SendKeys(_ExcelNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelPublish"))).Click();
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
            else
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelModuleImageSource")));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelModuleImageSourceEdit"))).Click();
                System.Threading.Thread.Sleep(4000);


               // TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("_SelectExcelFile"))).Click();
                //var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelSelect_DataSource")));
                //var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                //selectelementSelect_DataSource.SelectByText(_SelectExcelFile);


                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelHeaderTamplate"))).SendKeys(_ExcelHeaderTamplateForPublish);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelItemTemplate"))).SendKeys(_ExcelItemTemplate);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelfooterTemplate"))).SendKeys(_ExcelfooterTemplate);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfRecords"))).SendKeys(_ExcelNumberOfRecords);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfColumns"))).SendKeys(_ExcelNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelPublish"))).Click();
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
        }


        public void EditInExcelModuleForDraft(string ExcelModule, string ExcelModuleEdit, string _ExcelHeaderTamplateForDraft, string _ExcelItemTemplate, string _ExcelfooterTemplate, string _ExcelNumberOfRecords, string _ExcelNumberOfColumns)
        {

            if (!string.IsNullOrEmpty(ExcelModule) && !string.IsNullOrEmpty(ExcelModuleEdit))
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(ExcelModule)));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML(ExcelModuleEdit))).Click();
                System.Threading.Thread.Sleep(4000);


               // TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("_SelectExcelFile"))).Click();
                //var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelSelect_DataSource")));
                //var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                //selectelementSelect_DataSource.SelectByText(_SelectExcelFile);


                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelHeaderTamplate"))).SendKeys(_ExcelHeaderTamplateForDraft);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelItemTemplate"))).SendKeys(_ExcelItemTemplate);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelfooterTemplate"))).SendKeys(_ExcelfooterTemplate);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfRecords"))).SendKeys(_ExcelNumberOfRecords);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfColumns"))).SendKeys(_ExcelNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelDraft"))).Click();
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
            else
            {
                IWebElement SQLModuleImageSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelModuleImageSource")));
                new Actions(TestEnvironment.Driver).MoveToElement(SQLModuleImageSource).Build().Perform();
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelModuleImageSourceEdit"))).Click();
                System.Threading.Thread.Sleep(4000);


               // TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("_SelectExcelFile"))).Click();
                //var Select_DataSource = TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelSelect_DataSource")));
                //var selectelementSelect_DataSource = new SelectElement(Select_DataSource);
                //selectelementSelect_DataSource.SelectByText(_SelectExcelFile);


                System.Threading.Thread.Sleep(2000);

                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelHeaderTamplate"))).SendKeys(_ExcelHeaderTamplateForDraft);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelItemTemplate"))).SendKeys(_ExcelItemTemplate);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelfooterTemplate"))).SendKeys(_ExcelfooterTemplate);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfRecords"))).SendKeys(_ExcelNumberOfRecords);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelNumberOfColumns"))).SendKeys(_ExcelNumberOfColumns);
                System.Threading.Thread.Sleep(2000);
                TestEnvironment.Driver.FindElement(By.XPath(TestEnvironment.LoadXML("ExcelDraft"))).Click();
                TestEnvironment.Driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(9000);
            }
        }

        //public void TemplateElementClick(string _headersource,string _testTemplate,string _collection,string _templatename)  
        //{

        //    List<IWebElement> sourceLst = Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML(_headersource))).FindElements(By.TagName("td")).ToList();

        //   IWebElement str2 = sourceLst.Where(p => p.Text == _testTemplate).FirstOrDefault();
        //   string str3 = str2.Text;
        //    IWebElement source = Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML(str3)));
        //    new Actions(Environment.Driver).MoveToElement(source).Build().Perform();
        //    List<IWebElement> lst = Environment.Driver.FindElement(By.XPath(Eclips.Lib.Environment.LoadXML(_collection))).FindElements(By.TagName("tr")).ToList();
        //    IWebElement st1 = lst.Where(p => p.Text == _templatename).FirstOrDefault();
        //    st1.Click();
        //}

        //public string Email
        //{
        //    set
        //    {
        //        SetTextByCss("Email", value, 20);
        //        System.Threading.Thread.Sleep(500);
        //    }
        //}

        public void Sleep(int _Seconds)
        {
            int newtime_sleep = _Seconds * 1000;
            Thread.Sleep(newtime_sleep);
        }

        //public static void clearBrowserCache()
        //{

        //    Environment.Driver.Manage().Cookies.DeleteAllCookies();
        //    Process p = new Process();
        //    p.StartInfo.UseShellExecute = false;
        //    p.StartInfo.RedirectStandardOutput = true;
        //    if (Environment.BrowserName == Environment.BrowserType.IE)
        //        p.StartInfo.FileName = @"D:\BatchFile\IE.bat";
        //    else if (Environment.BrowserName == Environment.BrowserType.FireFox)
        //        p.StartInfo.FileName = @"D:\BatchFile\Firefox.bat";
        //    else if (Environment.BrowserName == Environment.BrowserType.Chrome)
        //        p.StartInfo.FileName = @"D:\BatchFile\Chrome.bat";
        //    else if (Environment.BrowserName == Environment.BrowserType.Safari)
        //        p.StartInfo.FileName = @"D:\BatchFile\Safari.bat";
        //    p.Start();
        //    string output = p.StandardOutput.ReadToEnd();
        //    p.WaitForExit();
        //}









        ////public void ClickLoginAndSetSignInValues()
        ////{
        ////    Sleep(3);
        ////    CsstoClick("LoginLink", 6);
        ////    GcmsUtitlity obj = new GcmsUtitlity();
        ////    //GCMS_Utility gcms = new GCMS_Utility();
        ////     gcms.UserNamePassWord(username, pass);
        ////    Sleep(3);
        ////}



        public void setValuesForEditRssFeedmoduleForPublish(string PrimaryURL, string PrimaryHeaderTemplate, string ItemTemplate, string NoofRecords, string NoofColumns, string FooterTemplate)
        {
            EditInRssFeedModuleForPublish(PrimaryURL, PrimaryHeaderTemplate, ItemTemplate, NoofRecords, NoofColumns, FooterTemplate);
        }

        public void setValuesForEditRssFeedmoduleForDraft(string PrimaryURL, string PrimaryHeaderTemplate, string ItemTemplate, string NoofRecords, string NoofColumns, string FooterTemplate)
        {
            EditInRssFeedModuleForDraft(PrimaryURL, PrimaryHeaderTemplate, ItemTemplate, NoofRecords, NoofColumns, FooterTemplate);
        }

        public void setValuesForEditSQLmoduleForPublish(string xpathForSqlModule, string xpathForSqlModuleEdit, string SQLSelect_DataSource, string SQLHeaderTemplateForPublish, string SQLItemTemplate, string SQLfooterTemplate, string SQLNumberOfRecords, string SQLNumberOfColumns)
        {
            EditInSqlModuleForPublish(xpathForSqlModule, xpathForSqlModuleEdit, SQLSelect_DataSource, SQLHeaderTemplateForPublish, SQLItemTemplate, SQLfooterTemplate, SQLNumberOfRecords, SQLNumberOfColumns);
        }

        public void setValuesForEditSQLmoduleForDraft(string xpathForSqlModule, string xpathForSqlModuleEdit, string SQLSelect_DataSource, string SQLHeaderTemplateForDraft, string SQLItemTemplate, string SQLfooterTemplate, string SQLNumberOfRecords, string SQLNumberOfColumns)
        {
            EditInSqlModuleForDraft(xpathForSqlModule, xpathForSqlModuleEdit, SQLSelect_DataSource, SQLHeaderTemplateForDraft, SQLItemTemplate, SQLfooterTemplate, SQLNumberOfRecords, SQLNumberOfColumns);
        }

        public void setValuesForEditExcelmoduleForPublish(string _xpathForExcelModule, string _xpathForExcelModuleEdit, string excelHeaderTemplate, string excelItemTemplate, string excelfooterTemplate, string excelNumberOfRecords, string excelNumberOfColumns)
        {
            EditInExcelModuleForPublish(_xpathForExcelModule, _xpathForExcelModuleEdit, excelHeaderTemplate, excelItemTemplate, excelfooterTemplate, excelNumberOfRecords, excelNumberOfColumns);
        }

        public void setValuesForEditExcelmoduleForDraft(string _xpathForExcelModule, string _xpathForExcelModuleEdit, string excelHeaderTemplate, string excelItemTemplate, string excelfooterTemplate, string excelNumberOfRecords, string excelNumberOfColumns)
        {
            EditInExcelModuleForPublish(_xpathForExcelModule, _xpathForExcelModuleEdit, excelHeaderTemplate, excelItemTemplate, excelfooterTemplate, excelNumberOfRecords, excelNumberOfColumns);
        }
    }
}
