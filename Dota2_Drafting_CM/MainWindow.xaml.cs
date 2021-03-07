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
using System.Xml.Linq;
using System.Xml;
using System.Net;
using System.IO;

namespace Dota2_Drafting_CM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //XDocument dataHeroes = Heroes
            XmlDocument dataHeroes = new XmlDocument();
            SortedDictionary<int, string> dicoHeroes = new SortedDictionary<int, string>();
            SortedDictionary<int, string> dicoName_ = new SortedDictionary<int, string>();
            SortedDictionary<int, string> dicoImages = new SortedDictionary<int, string>();

            string Url = "https://steamcdn-a.akamaihd.net/apps/dota2/images/heroes/";

            dataHeroes.Load("C:\\Users\\vince\\source\\repos\\Dota2_Drafting_CM\\Dota2_Drafting_CM\\Heroes.Xml");
           // XmlNode noeud = dataHeroes.FirstChild;
            XmlNodeList resources = dataHeroes.SelectNodes("allheroes/heroes");

            foreach (XmlNode node in resources)
            {
                string nameHero = node["localized_name"].InnerText;
                int idHero = Int32.Parse(node["id"].InnerText);
                string nameHero_ = node["name"].InnerText;
                string NewUrl = "";
              //  PictureHeroe.
                //dictionary.Add(node.Attributes["id"].Value, node.InnerText);
                dicoHeroes.Add(idHero, nameHero);
                dicoName_.Add(idHero, nameHero_);

                CbSelectHero.Items.Add(nameHero);
                NewUrl = Url + nameHero_ + "_sb.png";
                if (IsDirectoryEmpty("C:\\Users\\vince\\source\\repos\\Dota2_Drafting_CM\\Dota2_Drafting_CM\\Heroes_Images") = true) {
                    Uri linkpng = new Uri(NewUrl);
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(NewUrl), @"C:\Users\vince\source\repos\Dota2_Drafting_CM\Dota2_Drafting_CM\Heroes_Images\" + nameHero + ".png");
                        // OR 
                        //client.DownloadFileAsync(new Uri(NewUrl), @"c:\temp\image35.png");
                    }
                }
               
            }

        }
        private void CbSelectHero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void BtnPick_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBan_Click(object sender, RoutedEventArgs e)
        {

        }
        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
