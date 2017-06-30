using System;
using System.Text;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]   
namespace Wfs.Core
{
    public class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LogHelper()
        {
        }
 
        /// <summary>
        /// Logs the Information messages
        /// </summary>
        /// <param name="message"></param>
        public static void LogInformation(string message)
        {
            log.Debug(message);
        }
 
        /// <summary>
        /// Logs the warning messages
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning(string message)
        {
            log.Warn(message);
        }
 
        /// <summary>
        /// Logs the error message
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            log.Error(message);
        }
 
        /// <summary>
        /// Logs the exception messages
        /// </summary>
        /// <param name="exc"></param>
        /// <param name="message"></param>
        public static void LogException(Exception exc, string message)
        {
            StringBuilder builder = new StringBuilder();
            Exception ex = exc;
            builder.Append("Message:" + message);
            while (null != ex)
            {
                builder.Append("Message:" + ex.Message + "\n");
                builder.Append("StackTrace:" + ex.StackTrace + "\n");
                ex = ex.InnerException;
            }
            log.Fatal(builder.ToString());
        }
    }
}
