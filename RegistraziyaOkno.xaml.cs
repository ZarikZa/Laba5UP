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

namespace Laba5
{
    /// <summary>
    /// Логика взаимодействия для RegistraziyaOkno.xaml
    /// </summary>
    public partial class RegistraziyaOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public RegistraziyaOkno()
        {
            InitializeComponent();
        }

        private void ExitBtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void ZaregBtm_Click(object sender, RoutedEventArgs e)
        {
            AdresaDostavkis adresaDostavki = new AdresaDostavkis();
            LoginPasses loginPasses = new LoginPasses();
            Clients Client = new Clients();
            //adresaDostavki.Gorod = GorodTbox.Text.Trim();
            adresaDostavki.Street = StreetTbox.Text.Trim();
            adresaDostavki.Dom = Convert.ToInt32(DomTbox.Text.Trim());
            adresaDostavki.Kvartira = Convert.ToInt32(KvartiraTbox.Text.Trim());
            Laba5Entities.AdresaDostavkis.Add(adresaDostavki);
            loginPasses.Loginn = LoginTbox.Text.Trim();
            loginPasses.Pass = PassTbox.Text.Trim();
            loginPasses.FK_Dolznosti = 5;
            Laba5Entities.LoginPasses.Add(loginPasses);
            Laba5Entities.SaveChanges();
            Client.ClientSurname = SurnameTbox.Text.Trim();
            Client.ClientName = NameTbox.Text.Trim();
            Client.ClientMiddleName = MiddleNameTbox.Text.Trim();
            Client.FK_AdresDostavki = adresaDostavki.AdresaDostavki_ID;
            Laba5Entities.LoginPasses.ToList();
            Client.FK_LoginPass = loginPasses.LoginPass_ID;
            Laba5Entities.Clients.Add(Client);
            Laba5Entities.SaveChanges();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
