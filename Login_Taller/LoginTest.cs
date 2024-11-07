using Login_Taller.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace Login_Taller
{
    //Hooks el va a ejecutar ciertos trozos de codigo en cierta partes de mis test
    
    public class Tests
    {
        public IWebDriver driver;
        public LoginPage login;
        public String baseUrl = "https://the-internet.herokuapp.com/login";

        [SetUp]
        public void IniciarNavegador() {

            //Maximizar el navegador
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            login = new LoginPage(driver);

        }
        [TearDown]
        public void cerrarNavegador()
        {
            //cerrar el navegador
            driver.Close();
            //cerrar el driver
            driver.Quit();
        }
        [Test]
        public void IngresoCorrecto()
        {
            login.IngresarCredenciales();
            
        }

    }
}