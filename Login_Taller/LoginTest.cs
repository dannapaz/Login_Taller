using Login_Taller.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Login_Taller
{
    public class Tests
    {

        [Test]
        public void IngresoCorrecto()
        {

            //Driver: Es el que se comunica con el navegador
            //POM sirve para aislar los elementos 
            //Localizadores: Identificación de los elementos. 

            IWebDriver driver = new ChromeDriver();
            //Maximizar el navegador
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            LoginPage login= new LoginPage(driver);

            login.IngresarCredenciales();

            //cerrar el navegador
            driver.Close();
            //cerrar el driver
            driver.Quit();
        }

        public void IngresoIncorrecto()
        {
            //Driver: Es el que se comunica con el navegador

            IWebDriver driver = new ChromeDriver();
            //Maximizar el navegador
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            
            //Localizadores
            //Identificación de los elementos. 

            driver.FindElement(By.Id("username")).SendKeys("tomsmith1");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("#login button")).Click();
           //Para visualizar el test mas lento
            Thread.Sleep(500);

            //cerrar el navegador
            driver.Close();
            //cerrar el driver
            driver.Quit();

        }
    }
}