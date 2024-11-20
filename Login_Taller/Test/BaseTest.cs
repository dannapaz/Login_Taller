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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Login_Taller.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;
        public string baseURL = "https://the-internet.herokuapp.com/login";
        public WebDriverWait wait;
        public BasePage page;
        public TomarCaptura captura;

        //Reportes
        public static ExtentTest test;
        public static ExtentReports reports;


        [SetUp]
        public void IniciarNavegador()
        {

        
            /// La implicita se configura una vez y se aplica a 
            /// todos los elementos de la secion de ese navegador si el elemento no se encuentra 
            /// espera un tiempo y se envia un error se tiene esa desventaja porque siempre va a esperar
            // La explicita es hasta que se cumpla esa peticion especifica si no se cumple esa petición no hace nada 
            //aplica al elemento seleccionado es ideal cuando se necesitan ciertas esperas.
        
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            login = new LoginPage(driver, wait);
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
        //Solo se llama antes de mi bloque de pruebas 
        [OneTimeSetUp]
        public void IniciarReporte()
        {
            reports = new ExtentReports();
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(@"..\..\Reportes\index.html");
            reports.AttachReporter(htmlreporter);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        }
        //Se va a ejecutar hasta que termine todas las pruebas 
        //flush me permite generar el html
        [OneTimeTearDown]
        public void generarReporte()
        {
            reports.Flush();
        }


    }
}
