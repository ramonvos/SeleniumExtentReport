using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeleniumWebdriverFrameworkTest
{
    public class SeleniumMetodosSet 
    {
        /// <summary>
        /// ramon.souza
        /// Classe de iteração com elementos (Sendkeys, clicks, Asserts..)
        /// Todos os testes passam por esta classe, rensável por gravar logs e printscreen
        /// </summary>
        /// 
        ExtentReports report ;
        ExtentTest logger;

        // Método para preencher campos de texto
        public static void preencherTexto(IWebElement elemento, string valor)
        {   
            
            esperarElemento(elemento);
            elemento.Clear();
            elemento.SendKeys(valor);

        }
        // Método para clicar em elementos
        public static void clicarElemento(IWebElement elemento)
        {
            esperarElemento(elemento);
            elemento.Click();
            

        }

        public static void clicarLinkTexto(string valor)
        {

            SeleniumBase.driver.FindElement(By.LinkText(valor)).Click();

        }

        // Método para selecionar elementos (drop down list/combobox)
        public static void selecionarElemento(IWebElement elemento, string valor)
        {
            new SelectElement(elemento).SelectByText(valor);
        }

        

        // Método de validação de mensagens (ASSERTS)
        public static void validaMensagemEsperada(IWebElement elemento, string mensagem)
        {
            esperarTexto(elemento, mensagem);

            try
            {
                Assert.AreEqual(mensagem, elemento.Text);
                
            }
            catch
            {
                Assert.IsTrue(elemento.Text.Contains(mensagem));
            }
            /*Console.WriteLine(elemento.Text);
            // Print Screen de sucesso


            StackTrace stackTrace = new StackTrace(true);
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            string fileName = stackTrace.GetFrame(1).GetFileName();
            int lineNo = stackTrace.GetFrame(0).GetFileLineNumber();

            SeleniumUteis.gerarPrintscreen();
            SeleniumUteis.gravarLogTxt("SUCESSO - Teste '" + methodBase.Name + "' Executado com sucesso!");
            SeleniumUteis.gravarLogTxt("     Mensagem '" + SeleniumMetodosGet.GetLabel(elemento) + "' validada com sucesso.");
            */
        }
        // Método para esperar elemento "Espera explícita"
        public static void esperarElemento(IWebElement elemento)
        {
            WebDriverWait espera = new WebDriverWait(SeleniumBase.driver, TimeSpan.FromSeconds(10));
            try
            {
                espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
            }
            catch (Exception )
            {   /*
                UltimoErro = e.Message;
                // Print Screen de Erro
                SeleniumUteis.gerarPrintscreen();
                SeleniumUteis.gravarLogStacktrace(".");
                SeleniumUteis.gerarPrintscreen();
                Assert.Fail("O elemento: '" + UltimoErro + "' não apareceu");
                */
            }
        }
        // Método para esperar e verificar o texto presente no elemento "Espera explícita"

        public static void esperarTexto(IWebElement elemento, string valor)
        {
            WebDriverWait espera = new WebDriverWait(SeleniumBase.driver, TimeSpan.FromSeconds(10));
            try
            {
                espera.Until(ExpectedConditions.TextToBePresentInElement(elemento, valor));
            }
            catch (Exception )
            {   /*
                UltimoErro = e.Message;
                // Print Screen de Erro
                SeleniumUteis.gerarPrintscreen();
                SeleniumUteis.gravarLogStacktrace(" Mensagem esperada: '" + valor + "'.");
                Assert.Fail("O elemento: '" + UltimoErro + "' -'" + valor + "' não apareceu");
                */
            }

        }
    }
}