using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Taller.Genericos;
using Login_Taller.PageObject.Login;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Login_Taller.PageObject;

namespace Login_Taller.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;
        public string baseUrl = "https://the-internet.herokuapp.com/login";
        public WebDriverWait wait;
        public BasePage page;
        public TomarCaptura captura;

        [SetUp]
        public void IniciarNavegador()
        {

            //Maximizar el navegador
            driver = new ChromeDriver();

            wait =new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            /// La implicita se configura una vez y se aplica a 
            /// todos los elementos de la secion de ese navegador si el elemento no se encuentra 
            /// espera un tiempo y se envia un error se tiene esa desventaja porque siempre va a esperar
            // La explicita es hasta que se cumpla esa peticion especifica si no se cumple esa petición no hace nada 
            //aplica al elemento seleccionado es ideal cuando se necesitan ciertas esperas.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            login = new LoginPage(driver, wait);
            json = new LeerJson();
            page = new BasePage(driver, wait);
            captura = new TomarCaptura();


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
