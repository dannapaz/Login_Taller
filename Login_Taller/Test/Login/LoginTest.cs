using System.Collections;
using System.Reflection.Metadata;
using Login_Taller.Genericos;
using Login_Taller.PageObject.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace Login_Taller.Test.Login
{

    public class Tests : BaseTest
    {
      

        //El tipo de retorno IEnumerable va ser el interfaz que va representar una coleccion de objetos
        //cual es mi coleccion de objetos la que esta en credenciales 
        //long que va hacer unit es que va a tomar este objeto de tipo IEnumerable y lo va a transformar en una lista de datos

        public static IEnumerable TestData
        {
            get
            {
                var json = new LeerJson();
                return json.login_data().Select(data => new TestCaseData(data.username, data.password));
            }
        }


        //nameof evita que utilice magig string 
        //magic string numeros magicos
        // if(userRole == "admin") ¨{//Hacer algo para el administrador}
        //Es un termino que nos referimos a cadenas de texto que s eusan directamente en el codigo pero que no tenemos ningun tipo de explicacion
        //NO ES RECOMENDABLE UTILIZAR MAGIC STRING NO ES UNA BUENA PRACTICA


        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IngresoCorrecto(string user, string pass)

        {
            var data = json.login_data();
            // String user = data.username;
            // String password = data.password;

            login.IngresarCredenciales(user, pass);

            //asser valida escenarios negativos y positivos

            Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/login"));
        }
    }
}