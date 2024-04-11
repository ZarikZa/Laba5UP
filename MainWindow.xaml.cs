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

namespace Laba5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void RegistraziyaBtm_Click(object sender, RoutedEventArgs e)
        //{
        //    RegistraziyaOkno registraziyaOkno = new RegistraziyaOkno();
        //    registraziyaOkno.Show();
        //    Close();
        //}

        private void AutorizaBtm_Click(object sender, RoutedEventArgs e)
        {
            var loginPas = Laba5Entities.LoginPasses.ToList();
            bool proverka = false;
            foreach (var pass in loginPas)
            {
                if(pass.Loginn == LoginTbox.Text && pass.Pass == Passbox.Password && pass.FK_Dolznosti == 1)
                {
                    proverka = true;
                    AdminOkno adminOkno = new AdminOkno();
                    adminOkno.Show();
                    Close();
                }
                else if(pass.Loginn == LoginTbox.Text && pass.Pass == Passbox.Password && pass.FK_Dolznosti == 5)
                {
                    proverka= true; 
                    PokupkaOkno pokupkaOkno = new PokupkaOkno(pass.LoginPass_ID);
                    pokupkaOkno.Show();
                    Close();
                }
            }
            if(proverka == false) 
            {
                MessageBox.Show("Пароль или логин введены неверно");
            }
        }
    }
}