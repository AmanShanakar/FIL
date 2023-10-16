using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Something
{
    [TestClass]
    public class TestLog4net
    {
        [TestMethod]
        public void TestLog4Net()
        {
            // To create the layout(this will define the formate of the information)
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "[%date{ABSOLUTE}],[%thread],[%level],[%logger],[%message],[%exception]%newline";
            patternLayout.ActivateOptions(); //Active/Initialize the layout object
            // Create Appender and Use this layout in the appender(this will decide where the logs give output and use these layout inside this appender)
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = patternLayout,
                Threshold = Level.Warn
            };

            var fileAppender = new FileAppender()
            {
                Name = "fileappender",
                Layout = patternLayout,
                Threshold = Level.All,
                AppendToFile = true, //if we pass as false then it will truncate the existing log and add the new log
                File = "FileLogger.log"
            };

            var rollingfileAppender = new RollingFileAppender()
            {
                Name = "rollingfileappender",
                Layout = patternLayout,
                Threshold = Level.All,
                AppendToFile = true, //if we pass as false then it will truncate the existing log and add the new log
                File = "RollingFileLogger.log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15 //file1.log,file2.log.......file15.log
            };

            // Activate/Initialize the appender object
            consoleAppender.ActivateOptions();
            fileAppender.ActivateOptions();
            rollingfileAppender.ActivateOptions();

            // Initialize the configuration
            BasicConfigurator.Configure(consoleAppender, fileAppender, rollingfileAppender);
            // Get the instance of the logger(use this instance to generate the logging information)

            ILog Logger = LogManager.GetLogger(typeof(TestLog4net));

            //Log4NetHelper.Layout = "%message%newline";
            //ILog Logger = Log4NetHelper.GetLogger(typeof(TestLog4net));

            Logger.Debug("This is Debug information");
            Logger.Info("This is Info information");
            Logger.Warn("This is Warn information");
            Logger.Error("This is Error information");
            Logger.Fatal("This is Fatal information");
        }
    }
}
