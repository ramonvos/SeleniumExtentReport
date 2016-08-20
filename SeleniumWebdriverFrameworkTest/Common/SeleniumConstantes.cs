using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeleniumWebdriverFrameworkTest
{
    public class SeleniumConstantes
    {
        /// <summary>
        /// ramon.souza
        /// Classe de constantes para parametrizar URL, dados de login, diretórios...
        /// </summary>
        /// 
        //Setar a string do browser que será executado ( chrome ou phantom)

        public const string BrowserExecucao = "chrome";

        // Urls do sistema
        public const string contexto = "Onticket";
        public const string urlBase = "https://ancient-shelf-8143.herokuapp.com";
        public const string urlLogin = "/users/sign_in";
        public const string urlHomePage = "";

        // Dados de login
        public const string usuario = "a@a.com.br";
        public const string senha = "12345678";

        // Especificar o diretorio do windows para salvar logs.
        public static string diretorioLogsRaiz = @"c:\LogsSeleniumB2\";
        public static string diretorioFolderLog = @"c:\LogsSeleniumB2\Log\";
        public static string diretorioFolderPrint = @"c:\LogsSeleniumB2\Printscreen\";

        // cabeçalho e rodapé do arquivo de logs
       
    }
}
