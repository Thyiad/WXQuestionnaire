using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Tool
{
    public static class LogHelper
    {
        private static log4net.ILog _loginfo;
        private static log4net.ILog _logerror;
        private static bool _config = false;

        public static void Config()
        {
            if (_config) return;

            var tmp = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            codeBase = codeBase.Substring(8, codeBase.LastIndexOf("/") - 8 + 1);
            string file = codeBase + "log4net.config";
            using (var fs = File.Open(file, FileMode.Open))
                log4net.Config.XmlConfigurator.Configure(fs);
            _loginfo = log4net.LogManager.GetLogger("loginfo");
            _logerror = log4net.LogManager.GetLogger("logerror");
            _config = true;
        }

        public static void Debug(object info)
        {
            _loginfo.Debug(info);
        }

        public static void Info(object info)
        {
            _loginfo.Info(info);
        }

        public static void Error(Exception ex)
        {
            _logerror.Error(ex.Message, ex);
        }
    }
}
