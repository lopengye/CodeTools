using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace CodeTools
{
    public class LogHelper
    {
        /// <summary>
        /// 输出异常到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }

        /// <summary>
        /// 输出自定义信息到日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainWindow));
            log.Error(msg);
        }

        /// <summary>
        /// 输出异常信息到日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteLog(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainWindow));
            log.Error("Error", ex);
        }

        #endregion
    }
}
