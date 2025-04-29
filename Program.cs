using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AvitoSniffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelegramBot tgBot = new TelegramBot("https://api.telegram.org/bot", Creds.telegramToken, Creds.chatId );

            tgBot.SendMessage("Starting ...");

            ChromeDriver driver = new ChromeDriver("./");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(60));

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Constants.gotoUrl);

            wait.Until((d) => (d as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));

            while (true)
            {
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
