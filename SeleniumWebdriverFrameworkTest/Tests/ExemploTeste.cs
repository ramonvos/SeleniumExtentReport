
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Diagnostics;

namespace SeleniumWebdriverFrameworkTest
{
    public class ExemploTeste
    {
        

        ExemploPageObjects login = new ExemploPageObjects();

        [Test]
        public void CT1realizarLoginSucesso()
        {

            Log.startTest("CT1realizarLoginSucesso");

            Log.infoLog("Limpando o cache e Acessando a url");
            SeleniumBase.driver.Manage().Cookies.DeleteAllCookies();
            SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);


            Log.infoLog("Preenchendo usuario e senha");
            login.preencherLogin("a@a.com.br","12345678");

            Log.infoLog("Clicando em entrar");
            login.entrar();

            try
            {
                Assert.IsTrue(SeleniumBase.driver.Title.Contains("Onticket"));
                Log.sucessoLog( "Titulo verificado");

            }
            catch (Exception e)
            {
                Log.stackLog(1, e.Message + e.StackTrace);
                Assert.IsFalse(true);
            }

        }
        [Test]
        public void CT2realizarLoginFalha()
        {
            Log.startTest("CT2realizarLoginFalha");

            Log.infoLog("Limpando o cache e Acessando a url");
            SeleniumBase.driver.Manage().Cookies.DeleteAllCookies();
            SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);

            Log.infoLog("Preenchendo usuario e senha");
            login.preencherLogin("a@a.com.br", "12345678");

            Log.infoLog("Clicando em entrar");
            login.entrar();

            try
            {
                Assert.IsTrue(SeleniumBase.driver.Title.Contains("Google"));
                Log.sucessoLog("Titulo verificado");

            }
            catch (Exception e)
            {
                Log.stackLog(1,e.Message+e.StackTrace);
                Assert.IsFalse(true);

            }

        }
    }
}