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

          IWebDriver driver= new ChromeDriver();
            //Maximizar el navegador
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            //Localizadores
            //Identificación de los elementos. 

            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("#login button")).Click();

            //cerrar el navegador
            driver.Close();
            //cerrar el driver
            driver.Quit();



        }
    }
}