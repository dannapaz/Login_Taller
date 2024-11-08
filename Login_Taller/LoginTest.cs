using Login_Taller.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace Login_Taller
{

    //  [TestFixture("tomsmith", "SuperSecretPassword!")]
    //  Test Global  define la clase como un contenedor de pruebas 

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

        //ordenar testcase
        ///[Order(1)]
        //Ignorar un caso de prueba
        //[Ignore("No se prueba")]

        //[TestCase} Me define varios escenarios dentro de un unico metodo permitiendome probar multiples conjuntos de datos

        // [TestCase("tomsmith1", "SuperSecretPassword!")]
       [TestCase("tomsmith","SuperSecretPassword!")]
        public void IngresoCorrecto(String user, String password)
        {
            login.IngresarCredenciales(user,password);


        }
    }
}