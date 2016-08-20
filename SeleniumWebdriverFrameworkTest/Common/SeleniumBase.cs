using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace SeleniumWebdriverFrameworkTest
{
    public class SeleniumBase
    {
        public static IWebDriver driver { get; set; }
        //public static Stopwatch sw = new Stopwatch();
        public class configuracaoBrowser
        {   
            public void navegadorExecucao(string navegador)
            {
                if (navegador == "chrome")
                {
                    // driver = new ChromeDriver(SeleniumUteis.getPathSeleniumDriver());
                    //driver = new ChromeDriver(@".\Common\Drivers");
                    driver = new ChromeDriver(@"c:\chromedriver\");
                }
                if (navegador == "phantom")
                {
                    //driver = new PhantomJSDriver(SeleniumUteis.getPathSeleniumDriver());
                }
            }

        }
        // Inicializa e fecha o webdriver (Configurações de inicialização)
        [SetUpFixture]
        public class ConfiguracaoExecucao
        {
            public StringBuilder verificationErrors;
            [OneTimeSetUp]
            public void inicializaExecucao()
            {
                try
                {
                    if (driver == null)
                    {
                        Log.criaRepositorioLog();
                        Log.startTest("Inicialização");
                        
                        configuracaoBrowser b = new configuracaoBrowser();
                        //Setar o browser que ira inicializar
                        b.navegadorExecucao(SeleniumConstantes.BrowserExecucao);
                        Log.infoLog("Browser execução: " + SeleniumConstantes.BrowserExecucao);

                    }
                    verificationErrors = new StringBuilder();

                    //Maximizar o browser, executor javascript e navegar para a tela de login

                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);
                    Log.sucessoLog("Acessando URL: " + SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);


                    /* Grava log no cabeçalho do arquivo
                    SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);
                    SeleniumUteis.gravarLogTxt("Sistema: " + SeleniumConstantes.contexto + " - URL: " + SeleniumConstantes.urlBase);
                    sw.Start();
                    SeleniumUteis.gravarLogTxt("Início da execução: " + DateTime.Now);
                    SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);
                    */

                }

                catch (Exception e)
                {
                    Log.erroLog("Ocorreu um erro ao abrir o navegador: " + e.Message);
                    

                }

            }

            [OneTimeTearDown]
            public void finalizaExecucao()
            {   /*
                SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);
                String tmp = "";
                SeleniumUteis.gravarLogTxt("Fim da execução: " + DateTime.Now);
                //sw.Stop();


                TimeSpan timeSpan = sw.Elapsed;
                tmp = string.Format("Tempo total de execução: {0}h {1}m {2}s ", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);


                SeleniumUteis.gravarLogTxt(tmp);
                SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);
                */

                Log.geraLogHtml();
                driver.Close();


            }
        }
    }
}