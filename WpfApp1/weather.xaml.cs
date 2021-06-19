using Newtonsoft.Json.Linq;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для weather.xaml
    /// </summary>
    public partial class weather
    {
        public weather()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string town = textbox2.Text.ToString();
            string url = "http://api.openweathermap.org/data/2.5/find?q=" + town + "&type=like&APPID=4afbcc5d8e8c6c849f9630c9be607818";
            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();

            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            var s = sr.ReadToEnd();
            JObject obj = JObject.Parse(s);
            string temp = obj["list"][0]["main"]["temp"].ToString();
            string wind = obj["list"][0]["wind"]["speed"].ToString();
            float pressure = Convert.ToUInt32(obj["list"][0]["main"]["pressure"]);
            pressure = pressure / 133 * 100;
            float x = Convert.ToInt32(obj["list"][0]["main"]["temp"]);
            x = x - 273;
            textbox1.Text = "Температура: " + x.ToString() + " градусов" + Environment.NewLine
                            + "скорость ветра: " + wind + " м/с" + Environment.NewLine +
                            "" + "Давление: " + pressure.ToString()+" мм.р.с" ;
        }

  
    }
}
