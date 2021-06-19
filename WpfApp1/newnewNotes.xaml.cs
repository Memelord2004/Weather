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
using System.IO;
using MahApps.Metro.Controls.Dialogs;

namespace WpfApp1
{
    public partial class newnewNotes
    {
        MainWindow mainWindow;
        public newnewNotes()
        {
           
            InitializeComponent();
        }

        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            if(textbox1.Text.Length > 0 && textbox2.Text.Length > 0)
            {
                if (File.Exists(Environment.CurrentDirectory + "\\Notes\\" + textbox1.Text + ".txt"))
                    File.Create(Environment.CurrentDirectory + "\\Notes\\" + textbox1.Text + ".txt").Close();
                File.WriteAllText(Environment.CurrentDirectory + "\\Notes\\" + textbox1.Text + ".txt", textbox2.Text);
                mainWindow.listBox1.Items.Clear();
                mainWindow.ShowNotes();            
            }
            else
            {
                    await this.ShowMessageAsync("Ошибка!", "Заполните поля.");             
            }
        }
    }
}
