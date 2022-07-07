using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;

namespace Selenium
{
    static class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            

            driver.Navigate().GoToUrl("https://www.hepsiburada.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.ClassName("desktopOldAutosuggestTheme-input")).SendKeys("Bilgisayar");
            Thread.Sleep(5000);
            driver.FindElement(By.ClassName("SearchBoxOld-buttonContainer")).Click();

            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//*[@class='productListContent-innerWrapper']/ul/li[8]/div/a")).Click();
            string product = driver.FindElement(By.XPath("//*[@class='productListContent-innerWrapper']/ul/li[8]/div/a/div[3]/h3")).Text;
            Console.WriteLine(product);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            Thread.Sleep(6000);
            driver.FindElement(By.Id("addToCart")).Click();

            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//*[@class='checkoutui-ProductOnBasketHeader-m4tLG']/button[1]")).Click();

            Thread.Sleep(6000);
            string price = driver.FindElement(By.XPath("//div[@data-test-id='price-current-price']")).Text;
            Console.WriteLine(price);
            
            //Writing price and product name to the text file.
            string path = @"filepath"; //file path
            List<string> infos = new List<string>();
            infos.Add(product + ": " + price + "\nEklenme tarihi:" + DateTime.Now);
            File.WriteAllLines(path, infos);

        }        
    }
}
