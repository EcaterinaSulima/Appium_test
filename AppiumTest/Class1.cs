using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AppiumTest
{
    
    
    public class Class1
    {
        AndroidDriver<AndroidElement> driver;
        DesiredCapabilities caps;
        WebDriverWait wait;
         


        [SetUp]
        public void InitDriver()
        {
            caps = new DesiredCapabilities();
            caps.SetCapability("deviceName", "emulator-5554");
            caps.SetCapability("platformName", "Android");
            caps.SetCapability("platformVersion", "8.1.0");
            caps.SetCapability("appPackage", "com.pinterest");
            caps.SetCapability("appActivity", "activity.PinterestActivity");

            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), caps);

        }

        [Test]
        public void LogInHome()

        {
          
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            driver.FindElementById("com.pinterest:id/email_address").Click();
            driver.FindElementById("com.google.android.gms:id/cancel").Click();

            var inputEmail = driver.FindElementById("com.pinterest:id/email_address");
            inputEmail.SendKeys("albaaden@gmail.com");

            var continue_email_bt = driver.FindElementById("com.pinterest:id/continue_email_bt");
            continue_email_bt.Click();

            var password  = driver.FindElementById("com.pinterest:id/password");
            password.SendKeys("pinterest1");

            var next_bt = driver.FindElementById("com.pinterest:id/login_bt");
            next_bt.Click();

            var IsElementPresent =  driver.FindElementById("com.pinterest:id/bottom_nav_home_icon").Displayed;

           
            Assert.IsTrue(IsElementPresent);
        
        }






        [TearDown]

        public void closeDriver()
        {

          // driver.Quit();
        }


    }
}
