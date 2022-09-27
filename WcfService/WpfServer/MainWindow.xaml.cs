using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost serviceHost;
        public MainWindow()
        {
            InitializeComponent();
            string nPort = "8000";
            string strAdr = "http://localhost:" + nPort + "/ServiceEndPoint";
            try
            {
                Uri adrbase = new Uri(strAdr);
                serviceHost = new ServiceHost(typeof(SService), adrbase);
                BasicHttpBinding tcpb = new BasicHttpBinding();

                serviceHost.AddServiceEndpoint(typeof(IService), tcpb, strAdr);
                //Enable metadata exchange
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(smb);
                serviceHost.Open();
                Console.WriteLine("\n\nService is Running as >> " + strAdr);
            }
            catch (Exception eX)
            {
                serviceHost = null;
                MessageBox.Show("Service can not be started as >> [" +
                  strAdr + "] \n\nError Message [" + eX.Message + "]");
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            serviceHost.Close();
        }
    }
}
