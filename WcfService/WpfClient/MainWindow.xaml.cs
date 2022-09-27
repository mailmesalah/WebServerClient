using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WpfServer;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string nPort = "8000";
            BasicHttpBinding tcpb = new BasicHttpBinding();
            ChannelFactory<IService> channelFactory = new ChannelFactory<IService>(tcpb);

            string strServer = "169.254.223.181";
            string strEPAdr = "http://" + strServer + ":" +nPort + "/ServiceEndPoint";

            EndpointAddress ep  = new EndpointAddress(strEPAdr);
            IService Obj = channelFactory.CreateChannel(ep);
            for (int i = 0; i < 25; ++i)
            {
                //Obj.Call();
                //MessageBox.Show(Obj.DoWork().Data);
                Console.WriteLine("Return Value "+ Obj.DoWork().Data + " : \n\n");
            }
        }
    }
}
