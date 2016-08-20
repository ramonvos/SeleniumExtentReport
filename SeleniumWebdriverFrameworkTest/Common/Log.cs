using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SeleniumWebdriverFrameworkTest
{
    public class Log
    {
        static ExtentReports report;
        static ExtentTest logger;

        public static void criaRepositorioLog()
        {
            report = new ExtentReports(SeleniumConstantes.diretorioLogsRaiz + "report.html");
        }
        public static void startTest(string nomeTeste)
        {
            logger = report.StartTest(nomeTeste);
        }

        public static void infoLog(string msgInfo)
        {
            logger.Log(LogStatus.Info, msgInfo);

        }
        public static void erroLog(string msgErro)
        {
            logger.Log(LogStatus.Fail, msgErro);
        }
        public static void sucessoLog(string msgSucesso)
        {
            logger.Log(LogStatus.Pass, msgSucesso);
        }
        
        public static void geraLogHtml()
        {
            report.EndTest(logger);
            report.Flush();
        }
        public static void stackLog(int numFrame, string msg)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(numFrame);

            string nomeMetodo = sf.GetMethod().Name.ToString();
            string fullStack = "Erro no método: " + nomeMetodo;
            erroLog (fullStack +" - " + msg);
        }

    }
}