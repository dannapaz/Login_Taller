using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Login_Taller.Genericos
{
    public class TomarCaptura
    {
        public String CapturarPantalla(IWebDriver driver)
        {
            String photo = "";
            try
            {
                ITakesScreenshot screenshotdriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotdriver.GetScreenshot();

                //Toma la imagen y la devuelve
               photo= screenshot.AsBase64EncodedString;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo guardar la imagen: { ex}");
            }
            return photo;
        }

    }
}
