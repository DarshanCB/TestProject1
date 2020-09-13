using System;
using System.Threading;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;


namespace TestProject1
{
    public class UnitTest1
    {
        string Url_pass = "https://codility-frontend-prod.s3.amazonaws.com/media/task_static/qa_csharp_login_page/9a83bda125cd7398f9f482a3d6d45ea4/static/attachments/reference_page.html";
        //Firefox driver is choosed
        IWebDriver driver = new FirefoxDriver();
        
        
        
        
        //Webdriver initialization

        public IWebDriver driver_URl(string Url)
        {
            Thread.Sleep(3000);
            driver.Url = Url;
            driver.Manage().Window.Maximize();

            return driver;
        }
        
        
        [Fact]
        public void testLoginFormPresent()
        
        {
            try
            {


                IWebDriver driver = driver_URl(Url_pass);
                
               
                
                string Email_Check = driver.FindElement(By.Id("email-input")).GetAttribute("id");
                Assert.Equal("email-input", Email_Check);

                string Password_Check = driver.FindElement(By.Id("password-input")).GetAttribute("id");
                Assert.Equal("password-input", Password_Check);

                string Login_Check = driver.FindElement(By.Id("login-button")).GetAttribute("id");
                Assert.Equal("login-button", Login_Check);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                driver.Quit();
            }

        }

     
        
        [Fact]
        public void testcredentials()
        {
            try
            {
               
                IWebDriver driver = driver_URl(Url_pass);
                driver.FindElement(By.Id("email-input")).SendKeys("login@codility.com");
                driver.FindElement(By.Id("password-input")).SendKeys("password");

                driver.FindElement(By.Id("login-button")).Click();

                string welcome_page = this.driver.FindElement(By.XPath(@"//div[@class='message success'][1]")).Text;
                Assert.Equal("Welcome to Codility", welcome_page);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                driver.Quit();
            }
           
            




        }
        
        
        [Fact]
        public void WrongEmailcredentials()
        {
            try
            {

                IWebDriver driver = driver_URl(Url_pass);

                driver.FindElement(By.Id("email-input")).SendKeys("unknown@codility.com");
                driver.FindElement(By.Id("password-input")).SendKeys("password");

                driver.FindElement(By.Id("login-button")).Click();

                string welcome_page = driver.FindElement(By.XPath("//div[@class='message error'][1]")).Text;

                if (welcome_page == "You shall not pass! Arr!")
                {
                    Console.WriteLine("Test_passed");

                }
                else
                {
                    Console.WriteLine("Test_failed");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                driver.Quit();
            }
            
            
           
        }
        
         [Fact]
        public void WrongEmailFormatcredentials()
        {
            try
            {
                IWebDriver driver = driver_URl(Url_pass);
                
                driver.FindElement(By.Id("email-input")).SendKeys("xyz.com");
                driver.FindElement(By.Id("password-input")).SendKeys("password");

                driver.FindElement(By.Id("login-button")).Click();

                string welcome_page = this.driver.FindElement(By.XPath("//div[@class='validation error'][1]")).Text;

                if (welcome_page == "Enter a valid email")
                {
                    Console.WriteLine("Test_Passed");

                }
                else
                {
                    Console.WriteLine("Test Failed");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            finally
            {
                driver.Quit();
            }
            
            
           
        }
        
         [Fact]
        public void Emptycredentials()
        {
            try
            {
                IWebDriver driver = driver_URl(Url_pass);

                driver.FindElement(By.Id("email-input")).SendKeys("");
                driver.FindElement(By.Id("password-input")).SendKeys("");

                driver.FindElement(By.Id("login-button")).Click();

                string email_req = this.driver.FindElement(By.XPath("//div[@class='validation error'][1]")).Text;
                string password_req = this.driver.FindElement(By.XPath("//div[@class='validation error'][2]")).Text;


                if (email_req == "Email is required" && password_req == "Password is required")
                {
                    Console.WriteLine("Test_case_Passed");
                }
                else
                {
                    Console.WriteLine("Test_case_failed");
                }






            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                driver.Quit();
            }
           
           
        }
        
        
        
        
    }
}

       