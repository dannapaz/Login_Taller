using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Taller.Genericos;
using Login_Taller.PageObject.Login;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Login_Taller.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;
        public string baseUrl = "https://the-internet.herokuapp.com/login";

        [SetUp]
        public void IniciarNavegador()
        {

            //Maximizar el navegador
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            login = new LoginPage(driver);
            json = new LeerJson();

        }
        [TearDown]
        public void cerrarNavegador()
        {
            //cerrar el navegador
            driver.Close();
            //cerrar el driver
            driver.Quit();
        }

    }
}
