using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace TestProject
{
    public class Log4NetHelper
    {
        #region Field
        private static ILog _logger;
        private static ConsoleAppender _consoleAppender;
        private static FileAppender _fileAppender;
        //private static RollingFileAppender _rollingFileAppender;
        private static string _layout = "[%date{ABSOLUTE}],[%level][%message]%newline";
        #endregion

        #region Property
        public static string Layout
        {
            set { _layout = value; }
        }
        #endregion

        #region Private

        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleappender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All
            };
            consoleappender.ActivateOptions();
            return consoleappender;
        }

        private static FileAppender GetFileAppender()
        {
            var fileappender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true, //if we pass as false then it will truncate the existing log and add the new log
                File = "FileLogger.log"
            };
            fileappender.ActivateOptions();
            return fileappender;
        }


        /*private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingfileappender = new RollingFileAppender()
            {
                Name = "RollingFileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true, //if we pass as false then it will truncate the existing log and add the new log
                File = "RollingFileLogger.log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15 //file1.log,file2.log.......file15.log
            };
            rollingfileappender.ActivateOptions();
            return rollingfileappender;
        }*/
        #endregion

        #region Public
        public static ILog GetLogger(Type type)
        {
            if (_consoleAppender == null)
            {
                _consoleAppender = GetConsoleAppender();
            }
            if (_fileAppender == null)
            {
                _fileAppender = GetFileAppender();
            }
            /*if(_rollingFileAppender == null)
            {
                _rollingFileAppender = GetRollingFileAppender();
            }*/
            if (_logger != null)
            {
                return _logger;
            }
            BasicConfigurator.Configure(_consoleAppender, _fileAppender); //, _rollingFileAppender

            _logger = LogManager.GetLogger(type);
            return _logger;
        }
        #endregion
    }
}
