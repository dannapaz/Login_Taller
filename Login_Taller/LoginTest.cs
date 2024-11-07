using Login_Taller.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace Login_Taller
{

    //Driver: Es el que se comunica con el navegador
    //POM sirve para aislar los elementos 
    //Localizadores: Identificación de los elementos. 
    //Para visualizar el test mas lento Thread.Sleep(500);

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