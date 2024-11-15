using System.Collections;
using System.Reflection.Metadata;
using Login_Taller.Genericos;
using Login_Taller.PageObject.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace Login_Taller.Test.Login
{

    //Se usa herencia el papa va a ser base test y
    //todos los metodos de ese papa los puede utilizar en los hijos
    public class Tests : BaseTest
    {
        public static IEnumerable TestData
        {
            get
            {
                var json = new LeerJson();
                return json.login_data().Select(data => new TestCaseData(data.username, data.password));
            }
        }


        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IngresoCorrecto(string user, string pass)

        {
            var data = json.login_data();
            // String user = data.username;
            // String password = data.password;

            login.IngresarCredenciales(user, pass);

        }
    }
}