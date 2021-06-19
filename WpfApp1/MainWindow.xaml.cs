using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using xNet;
using Newtonsoft.Json;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow
    {
        string[] allfiles;
        int countF = 0;
        public MainWindow()
        {
            DateTime dateNow;
            InitializeComponent();
            dateNow = DateTime.Now;
            label1.Content = DateTime.Now;
            ShowNotes();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            newnewNotes newnewnotes = new newnewNotes();
            newnewnotes.ShowDialog();

        }

        public void ShowNotes()
        {
            allfiles = Directory.GetFiles(Environment.CurrentDirectory + "\\Notes", "*.txt");
            foreach (string names in allfiles)
            {
                allfiles[countF] = System.IO.Path.GetFileNameWithoutExtension(names);
                listBox1.Items.Insert(countF, allfiles[countF]);
                countF++;
            }
            countF = 0;
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string data = File.ReadAllText(Environment.CurrentDirectory + "\\Notes\\" + listBox1.SelectedItem.ToString() + ".txt");
            textbox1.Text = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            weather weather = new weather();
            weather.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string apikey = "UU4OLgEWtfaIdHebWVCx1VQskKHUhKEoD5VSZQCL";
            string url = "https://api.nasa.gov/planetary/apod?api_key=" + apikey;
            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);

            var s = sr.ReadToEnd();
            JObject obj = JObject.Parse(s);
            string imgUrl = obj["url"].ToString();
            browser.Navigate(imgUrl);
           
        }

        class vkApi
        {
            public string vkAppid = "7867278";
            private const string __VKAPIURL = "https://api.vk.com/method/";
            private string vkToken = "yQPaHEsIlQf1kCWuOlqY";

            public vkApi(string AccessToken)
            {
                vkToken = AccessToken;
            }

            public Dictionary<string, string> GetInformation(string UserId, string[] Fields)  //Получение заданной информации о пользователе с заданным ID 
            {
                HttpRequest GetInformation = new HttpRequest();
                GetInformation.AddUrlParam("user_ids", UserId);
                GetInformation.AddUrlParam("access_token", vkToken);
                GetInformation.AddUrlParam("v", "5.52");
                string Params = "";
                foreach (string i in Fields)
                {
                    Params += i + ",";
                }
                Params = Params.Remove(Params.Length - 1);
                GetInformation.AddUrlParam("fields", Params);
                string Result = GetInformation.Get(__VKAPIURL + "users.get").ToString();
                Result = Result.Substring(13, Result.Length - 15);
                Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(Result);
                return Dict;
            }

        }


    }
}
