using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SeleniumWebdriverFrameworkTest
{
    public class SeleniumUteis
    {
        public static String getPathSeleniumDriver()
        {
            String strAppDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            String strAppFolderData = Path.Combine(strAppDir, "\\SeleniumComum\\Drivers");
            return strAppDir + strAppFolderData;
        }

        // Método para capturar tela - Screenshot
        public static void gerarPrintscreen()
        {
            try
            {
                // Verificar se o repositório já existe.
                if (Directory.Exists(SeleniumConstantes.diretorioLogsRaiz))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Criar o repositório.
                DirectoryInfo di1 = Directory.CreateDirectory(SeleniumConstantes.diretorioLogsRaiz);
                DirectoryInfo di2 = Directory.CreateDirectory(SeleniumConstantes.diretorioFolderLog);
                DirectoryInfo di3 = Directory.CreateDirectory(SeleniumConstantes.diretorioFolderPrint);

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                Screenshot ss = ((ITakesScreenshot)SeleniumBase.driver).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                ss.SaveAsFile(SeleniumConstantes.diretorioFolderPrint + "SeleniumPrintscreen" + GetCurrentDate() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                ss.ToString();
            }
        }

            //Obter data corrente
        public static String GetCurrentDate()
        {
            DateTime time = DateTime.Now;
            string format = "_dd-MM-yyyy HH-mm-ss";
            return time.ToString(format);
        }

    }
    
}