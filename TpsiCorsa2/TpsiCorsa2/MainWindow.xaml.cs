using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;

namespace TpsiCorsa2
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread t1;
        Thread t2;
        Thread t3;
        Random r;
        Thickness razzo1Partenza;
        Thickness razzo2Partenza;
        Thickness razzo3Partenza;

        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
            razzo1Partenza = imgRazzo1.Margin;
            razzo2Partenza = imgRazzo2.Margin;
            razzo3Partenza = imgRazzo3.Margin;
        }
        public void MetodoMovimento(Image img)
        {
            try
            {
                int marginLeft = 0;
                int marginTop = 0;
                int marginBottom = 0;
                int marginRight = 0;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    marginLeft = (int)img.Margin.Left;
                    marginTop = (int)img.Margin.Top;
                    marginBottom = (int)img.Margin.Bottom;
                    marginRight = (int)img.Margin.Right;
                }));
                while (marginLeft < 700)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 751)));
                    marginLeft += 50;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        img.Margin = new Thickness(marginLeft, marginTop, marginBottom, marginRight);
                    }));
                }

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (img.Name.Contains("1"))
                    {
                        lstPodio.Items.Add("razzo 1");
                    }
                    else if (img.Name.Contains("2"))
                    {
                        lstPodio.Items.Add("razzo 2");
                    }
                    else if (img.Name.Contains("3"))
                    {
                        lstPodio.Items.Add("razzo 3");
                    }
                    if (lstPodio.Items.Count == 3)
                    {
                        btnInizia.IsEnabled = true;
                    }
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MuoviRazzo1()
        {
            try
            {
                MetodoMovimento(imgRazzo1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MuoviRazzo2()
        {
            try
            {
                MetodoMovimento(imgRazzo2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MuoviRazzo3()
        {
            try
            {
                MetodoMovimento(imgRazzo3);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnInizia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnInizia.IsEnabled = false;

                lstPodio.Items.Clear();
                imgRazzo1.Margin = razzo1Partenza;
                imgRazzo2.Margin = razzo2Partenza;
                imgRazzo3.Margin = razzo3Partenza;

                t1 = new Thread(new ThreadStart(MuoviRazzo1));
                t2 = new Thread(new ThreadStart(MuoviRazzo2));
                t3 = new Thread(new ThreadStart(MuoviRazzo3));

                t1.Start();
                t2.Start();
                t3.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
