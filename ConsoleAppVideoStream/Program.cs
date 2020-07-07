using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAppVideoStream
{
    class Program
    {
        static void Main(string[] args)
        {
            int browsersCount = 5;
            string arg = args.FirstOrDefault();
            try
            {
                browsersCount = int.Parse(arg);
            }
            catch (Exception e)
            {
                // ignored 
            }

            for (int i = 0; i < browsersCount; i++)
            {
                Thread t = new Thread(() =>
                    {
                        ChromeDriver driver = new ChromeDriver("driver/");
                        driver.Url = "http://192.168.1.99:5013/video/info/0";
                        
                        IWebElement element = driver.FindElement(By.LinkText("Просмотр"));
                        //driver.findElement(By.linkText("Просмотр"));
                        element.Click();
                        //Крепкий орешек
                        Thread.Sleep(30000);
                    }
                );

                t.Start();
            }

            Console.Read();

        }
    }

 
}