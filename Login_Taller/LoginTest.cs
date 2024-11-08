using Login_Taller.Genericos;
using Login_Taller.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace Login_Taller
{

    //cerealización convertir un objeto a un tipo plano 
    //deserealizacion es tomar datos de un texto plano json y convertirlos en un objeto para que pueda manitpular
    //dentro de nuestra apllicacion en este caso de los test y pueda seder a las propiedades y metodos de este objeto 
    //convertir o tomar datos rn un formato plano y convertilos a un obj.
    //El json lo deserealizamos porque transformamos lo que esta en archivo plano a un obj funcional
    //para poder acceder a las pruebas de mi test

    public class Tests
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;
        public String baseUrl = "https://the-internet.herokuapp.com/login";

        [SetUp]
        public void IniciarNavegador() {

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

       
       [Test]
        public void IngresoCorrecto()

        {
            var data = json.login_data();
            String user = data.username;
            String password = data.password;

            login.IngresarCredenciales(user, password);

        }
    }
}