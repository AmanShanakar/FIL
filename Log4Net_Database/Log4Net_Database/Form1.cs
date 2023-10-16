using System;
using System.Windows.Forms;
using log4net;

namespace Log4Net_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private static readonly ILog Logger = LogManager.GetLogger(typeof(Form1));
        ILog log;

        private void Form1_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            log = LogManager.GetLogger(typeof(Form1)); //(typeof(Form1))
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("Your data has been successfully saved.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                int y = 1 / x;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message , ex);
            }
        }
    }
}
