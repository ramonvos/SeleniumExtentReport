using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWebdriverFrameworkTest.Common;

namespace SeleniumWebdriverFrameworkTest
{
    public class ExemploPageObjects : SeleniumBase
    {
        public ExemploPageObjects()
        {
            PageFactory.InitElements(SeleniumBase.driver, this);

        }

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement txtUsuario { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement txtSenha { get; set; }

        [FindsBy(How = How.Id, Using = "btn-login")]
        public IWebElement btnLogin { get; set; }



        public void preencherLogin(string usu, string senha)
        {
            SeleniumMetodosSet.preencherTexto(txtUsuario, usu);
            SeleniumMetodosSet.preencherTexto(txtSenha, senha);
        }
        public void entrar()
        {
            SeleniumMetodosSet.clicarElemento(btnLogin);
        }
        

        
    }
}