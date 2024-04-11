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
using static System.Net.Mime.MediaTypeNames;

namespace Laba5
{
    /// <summary>
    /// Логика взаимодействия для ClientsOkno.xaml
    /// </summary>
    public partial class ClientsOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public ClientsOkno()
        {
            InitializeComponent();
            clientDG.ItemsSource = Laba5Entities.Clients.ToList();
            AdresCBox.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
            AdresCBox.DisplayMemberPath = "Street";
            GorodCbox.ItemsSource = Laba5Entities.Gorods.ToList();
            GorodCbox.DisplayMemberPath = "GorodName";
        }
        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        private void AddresOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            AdrasaDostavkiOkno adrasaDostavkiOkno = new AdrasaDostavkiOkno();
            adrasaDostavkiOkno.BackBtm.IsEnabled = false;
            adrasaDostavkiOkno.ShowDialog();
        }

        public bool isLeter(string input)
        {
            return input.All(c => char.IsLetter(c));
        }

        private void clientDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Client = clientDG.SelectedItem as Clients ?? new Clients();
            var Adresa = Laba5Entities.AdresaDostavkis.ToList();
            if (Client.ClientName != null)
            {
                ClientSurnameTbox.Text = Client.ClientSurname.ToString();
                ClientNameTbox.Text =  Client.ClientName.ToString();
                if(Client.ClientMiddleName != null)
                {
                    ClientMiddleNameTbox.Text =  Client.ClientMiddleName.ToString();
                }
                foreach (var item in Adresa)
                {
                    if(item.AdresaDostavki_ID == Client.FK_AdresDostavki)
                    {
                        AdresCBox.SelectedItem = item;
                    }
                }
                foreach (var item in Laba5Entities.Gorods)
                {
                    if (item.Gorod_ID == (AdresCBox.SelectedItem as AdresaDostavkis).FK_Gorod)
                    {
                        GorodCbox.SelectedItem = item;
                    }
                }
                StreetTbox.Text = (AdresCBox.SelectedItem as AdresaDostavkis).Street.ToString();
                DomTbox.Text = (AdresCBox.SelectedItem as AdresaDostavkis).Dom.ToString();
                KvartiraTbox.Text = (AdresCBox.SelectedItem as AdresaDostavkis).Kvartira.ToString() ?? "";
                LoginTBox.Text = Client.LoginPasses.Loginn.ToString();
                PasTBox.Text = Client.LoginPasses.Pass.ToString();
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if(clientDG.SelectedItem != null)
            {
                if (ClientNameTbox.Text.Trim().Length < 50 
                    && ClientMiddleNameTbox.Text.Trim().Length < 50 
                    && ClientSurnameTbox.Text.Trim().Length > 3 
                    && ClientNameTbox.Text.Trim().Length >= 2 
                    && LoginTBox.Text.Trim().Length < 30 
                    && PasTBox.Text.Trim().Length < 30 
                    && LoginTBox.Text.Trim().Length > 4 
                    && PasTBox.Text.Trim().Length > 5)
                {
                    if (clientDG.SelectedItem != null)
                    {
                        var selected = clientDG.SelectedItem as Clients;
                        bool proverka = true;
                        bool proverka2 = true;
                        bool proverka3 = true;
                        try
                        {
                            Convert.ToInt32(DomTbox.Text);
                            Convert.ToInt32(KvartiraTbox.Text);
                        }
                        catch (Exception)
                        {
                            proverka3 = false;
                        }
                        if (AdresCBox.SelectedItem == null && proverka3 != false)
                        {
                            foreach (var item in Laba5Entities.AdresaDostavkis)
                            {
                                if (proverka3 == true )
                                {
                                    if (item.FK_Gorod == (GorodCbox.SelectedItem as Gorods).Gorod_ID
                                        && item.Street == StreetTbox.Text
                                        && item.Dom == Convert.ToInt32(DomTbox.Text))
                                    {
                                        if (item.Kvartira != null)
                                        {
                                            if (item.Kvartira == Convert.ToInt32(KvartiraTbox.Text))
                                            {
                                                proverka = true;
                                            }
                                        }
                                        else
                                        {
                                            proverka = false;
                                            OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                                        }
                                    }
                                    else
                                    {
                                        proverka = false;
                                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                                    }
                                }
                                else
                                {
                                    proverka = false;
                                }
                            }
                            if (proverka == false)
                            {
                                foreach (var item in Laba5Entities.Gorods)
                                {
                                    if (item == GorodCbox.SelectedItem)
                                    {
                                        selected.AdresaDostavkis.FK_Gorod = item.Gorod_ID;
                                    }
                                }
                                selected.AdresaDostavkis.Street = StreetTbox.Text.Trim();
                                selected.AdresaDostavkis.Dom = Convert.ToInt32(DomTbox.Text.Trim());
                                selected.AdresaDostavkis.Kvartira = Convert.ToInt32(KvartiraTbox.Text.Trim());
                                proverka = true;
                            }
                        }
                        else
                        {
                            foreach (var item in Laba5Entities.AdresaDostavkis)
                            {
                                if (item.AdresaDostavki_ID == (AdresCBox.SelectedItem as AdresaDostavkis).AdresaDostavki_ID)
                                {
                                    selected.FK_AdresDostavki = item.AdresaDostavki_ID;
                                }
                            }
                        }
                        if (proverka == true)
                        {
                            if (proverka == false)
                            {
                                foreach (var clin in Laba5Entities.Clients)
                                {
                                    foreach (var pas in Laba5Entities.LoginPasses)
                                    {
                                        if (pas.Loginn == LoginTBox.Text)
                                        {
                                            if (clin.FK_LoginPass == pas.LoginPass_ID)
                                            {
                                                proverka = false;
                                            }
                                        }
                                    }
                                }
                            }
                            if (proverka != false)
                            {
                                selected.LoginPasses.Loginn = LoginTBox.Text.Trim();
                                selected.LoginPasses.Pass = PasTBox.Text.Trim();
                                proverka = ProverkaSNM();
                                if (proverka == true)
                                {
                                    selected.ClientSurname = ClientSurnameTbox.Text.Trim();
                                    selected.ClientName = ClientNameTbox.Text.Trim();
                                    selected.ClientMiddleName = ClientMiddleNameTbox.Text.Trim();
                                    Laba5Entities.SaveChanges();
                                    clientDG.ItemsSource = Laba5Entities.Clients.ToList();
                                    AdresCBox.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
                                    ClientMiddleNameTbox.Text = null;
                                    ClientNameTbox.Text = null;
                                    AdresCBox.SelectedItem = null;
                                    ClientSurnameTbox.Text = null;
                                    DomTbox.Text = null;
                                    KvartiraTbox.Text = null;
                                    DomTbox.Text = null;
                                    LoginTBox.Text = null;
                                    StreetTbox.Text = null;
                                    PasTBox.Text = null;
                                    AdresCBox.SelectedItem = null;
                                    clientDG.SelectedItem = null;
                                    AdresCBox.SelectedItem = null;
                                    GorodCbox.SelectedItem = null;
                                    StreetTbox.IsEnabled = true;
                                    DomTbox.IsEnabled = true;
                                    KvartiraTbox.IsEnabled = true;
                                }
                                else
                                {
                                    OshibkaTBlock.Text = "ФИО заполнено неверно";
                                }
                            }
                            else
                            {
                                OshibkaTBlock.Text = "Такой логин уже существует";
                            }
                        }
                        if (proverka == false)
                        {
                            OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                        }
                    }
                }
                else
                {
                    OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                }
            }
            else
            {
                OshibkaTBlock.Text = "Нмчего не выбрано";
            }
        }

        private void AdresCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AdresCBox.SelectedItem != null)
            {
                foreach (var item in Laba5Entities.Gorods)
                {
                    if(item.Gorod_ID == (AdresCBox.SelectedItem as AdresaDostavkis).FK_Gorod)
                    {
                        GorodCbox.SelectedItem = item;
                    }
                }
                StreetTbox.Text = (AdresCBox.SelectedItem as AdresaDostavkis).Street.ToString();
                DomTbox.Text = (AdresCBox.SelectedItem as AdresaDostavkis).Dom.ToString();
                KvartiraTbox.Text = (AdresCBox.SelectedItem as AdresaDostavkis).Kvartira.ToString() ?? "";
                StreetTbox.IsEnabled = false;
                DomTbox.IsEnabled = false;
                KvartiraTbox.IsEnabled = false;
                GorodCbox.IsEnabled = false;
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (ClientNameTbox.Text.Trim().Length < 50
               && ClientSurnameTbox.Text.Trim().Length < 50
               && ClientSurnameTbox.Text.Trim().Length > 3
               && ClientNameTbox.Text.Trim().Length >= 2
               && LoginTBox.Text.Trim().Length < 30
               && PasTBox.Text.Trim().Length < 30
               && LoginTBox.Text.Trim().Length > 4
               && PasTBox.Text.Trim().Length > 5)
            {
                AdresaDostavkis adres = new AdresaDostavkis();
                LoginPasses loginpas = new LoginPasses();
                Clients Client = new Clients();
                bool proverka = true;
                bool proverka2 = true;
                bool proverka3 = true;
                try
                {
                    Convert.ToInt32(DomTbox.Text);
                    Convert.ToInt32(KvartiraTbox.Text);
                }
                catch (Exception)
                {
                    proverka3 = false;
                }
                if (AdresCBox.SelectedItem == null)
                {
                    foreach (var item in Laba5Entities.AdresaDostavkis)
                    {
                        if (proverka3 == true)
                        {
                            if (item.FK_Gorod == (GorodCbox.SelectedItem as Gorods).Gorod_ID
                                && item.Street == StreetTbox.Text
                                && item.Dom == Convert.ToInt32(DomTbox.Text))
                            {
                                if (item.Kvartira != null)
                                {
                                    if (item.Kvartira == Convert.ToInt32(KvartiraTbox.Text))
                                    {
                                        proverka = false;
                                    }
                                }
                                else
                                {
                                    proverka = false;
                                }
                            }
                        }
                        else
                        {
                            proverka = false;
                        }
                    }
                }
                else
                {
                    foreach (var item in Laba5Entities.AdresaDostavkis)
                    {
                        if(item.AdresaDostavki_ID == (AdresCBox.SelectedItem as AdresaDostavkis).AdresaDostavki_ID)
                        {
                            Client.FK_AdresDostavki = item.AdresaDostavki_ID;
                        }
                    }
                    proverka = LoginDobav();
                    if(proverka == false)
                    {
                        foreach (var clin in Laba5Entities.Clients)
                        {
                            foreach (var pas in Laba5Entities.LoginPasses)
                            {
                                if (pas.Loginn == LoginTBox.Text)
                                {
                                    if(clin.FK_LoginPass == pas.LoginPass_ID)
                                    {
                                        proverka = false;
                                    }
                                }
                            }
                        }
                    }
                    if (proverka == true)
                    {
                        foreach (var item in Laba5Entities.LoginPasses)
                        {
                            if (item.Loginn == LoginTBox.Text)
                            {
                                Client.FK_LoginPass = item.LoginPass_ID;
                            }
                        }
                        proverka = ProverkaSNM();
                        if(proverka == true)
                        {
                            Client.ClientSurname = ClientSurnameTbox.Text.Trim();
                            Client.ClientName = ClientNameTbox.Text.Trim();
                            Client.ClientMiddleName = ClientMiddleNameTbox.Text.Trim();
                            Laba5Entities.Clients.Add(Client);
                            Laba5Entities.SaveChanges();
                            clientDG.ItemsSource = Laba5Entities.Clients.ToList();
                            AdresCBox.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
                            ClientMiddleNameTbox.Text = null;
                            ClientNameTbox.Text = null;
                            ClientSurnameTbox.Text = null;
                            DomTbox.Text = null;
                            KvartiraTbox.Text = null;
                            DomTbox.Text = null;
                            LoginTBox.Text = null;
                            StreetTbox.Text = null;
                            PasTBox.Text = null;
                            clientDG.SelectedItem = null;
                            GorodCbox.SelectedItem = null;
                            StreetTbox.IsEnabled = true;
                            DomTbox.IsEnabled = true;
                            KvartiraTbox.IsEnabled = true;
                        }
                        else
                        {
                            OshibkaTBlock.Text = "Имя фамилия или отчество ошибка";
                        }
                    }
                }
                if (AdresCBox.SelectedItem == null)
                {
                    if (proverka == true)
                    {
                        proverka2 = isLeter(StreetTbox.Text);
                        if (proverka2 == true && proverka3 == true)
                        {
                            foreach (var item in Laba5Entities.Gorods)
                            {
                                if (item == GorodCbox.SelectedItem)
                                {
                                    adres.FK_Gorod = item.Gorod_ID;
                                }
                            }
                            adres.Street = StreetTbox.Text.Trim();
                            adres.Dom = Convert.ToInt32(DomTbox.Text.Trim());
                            if (KvartiraTbox.Text.Trim() == "")
                            {
                                adres.Kvartira = 0;
                            }
                            Laba5Entities.AdresaDostavkis.Add(adres);
                            Laba5Entities.SaveChanges();
                            foreach (var item in Laba5Entities.AdresaDostavkis)
                            {
                                if(item == adres)
                                {
                                    Client.FK_AdresDostavki = item.AdresaDostavki_ID;
                                }
                            }
                            proverka = LoginDobav();
                            if(proverka == true)
                            {
                                foreach (var item in Laba5Entities.LoginPasses)
                                {
                                    if(item.Loginn == LoginTBox.Text)
                                    {
                                        Client.FK_LoginPass = item.LoginPass_ID;
                                    }
                                }
                                proverka = ProverkaSNM();
                                if(proverka == true)
                                {
                                    Client.ClientSurname = ClientSurnameTbox.Text.Trim();
                                    Client.ClientName = ClientNameTbox.Text.Trim();
                                    Client.ClientMiddleName = ClientMiddleNameTbox.Text.Trim();
                                    Laba5Entities.Clients.Add(Client);
                                    Laba5Entities.SaveChanges();
                                    clientDG.ItemsSource = Laba5Entities.Clients.ToList();
                                    AdresCBox.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
                                    ClientMiddleNameTbox.Text = null;
                                    ClientNameTbox.Text = null;
                                    AdresCBox.SelectedItem = null;
                                    ClientSurnameTbox.Text = null;
                                    DomTbox.Text = null;
                                    KvartiraTbox.Text = null;
                                    DomTbox.Text = null;
                                    LoginTBox.Text = null;
                                    StreetTbox.Text = null;
                                    PasTBox.Text = null;
                                    AdresCBox.SelectedItem = null;
                                    clientDG.SelectedItem = null;
                                    AdresCBox.SelectedItem = null;
                                    GorodCbox.SelectedItem = null;
                                    StreetTbox.IsEnabled = true;
                                    DomTbox.IsEnabled = true;
                                    KvartiraTbox.IsEnabled = true;
                                }
                                else
                                {
                                    OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                                }
                            }
                            else
                            {
                                OshibkaTBlock.Text = "Такой логин уже существует";
                            }
                        }
                        else
                        {
                            OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                        }
                    }
                }
                else if (proverka == false)
                {
                    OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                }
            }
            else
            {
                OshibkaTBlock.Text = "Логин или пароль или ещё что-то маленькие";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if(clientDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var item in Laba5Entities.Bills)
                {
                    if (item.FK_Client == (clientDG.SelectedItem as Clients).Client_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.Clients.Remove(clientDG.SelectedItem as Clients);
                    Laba5Entities.SaveChanges();
                }
                clientDG.ItemsSource = Laba5Entities.Clients.ToList();
                AdresCBox.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
                ClientMiddleNameTbox.Text = null;
                ClientNameTbox.Text = null;
                AdresCBox.SelectedItem = null;
                ClientSurnameTbox.Text = null;
                DomTbox.Text = null;
                KvartiraTbox.Text = null;
                DomTbox.Text = null;
                LoginTBox.Text = null;
                StreetTbox.Text = null;
                PasTBox.Text = null;
                AdresCBox.SelectedItem = null;
                clientDG.SelectedItem = null;
                AdresCBox.SelectedItem = null;
                GorodCbox.SelectedItem = null;
                StreetTbox.IsEnabled = true;
                DomTbox.IsEnabled = true;
                KvartiraTbox.IsEnabled = true;
            }
            else
            {
                OshibkaTBlock.Text = "Ничего не выбрано";
            }
        }

        private void SbrosAdresBtm_Click(object sender, RoutedEventArgs e)
        {
            AdresCBox.SelectedItem = null;
            GorodCbox.SelectedItem = null;
            DomTbox.Text = null;
            KvartiraTbox.Text = null;
            StreetTbox.Text = null;
            StreetTbox.IsEnabled = true;
            DomTbox.IsEnabled = true;
            KvartiraTbox.IsEnabled = true;
            GorodCbox.IsEnabled = true;
        }

        private bool LoginDobav()
        {
            LoginPasses loginpas = new LoginPasses();
            bool proverka = true;
            foreach (var item in Laba5Entities.LoginPasses)
            {
                if (item.Loginn == LoginTBox.Text)
                {
                    proverka = false;
                }
            }
            if (proverka == true)
            {
                loginpas.Loginn = LoginTBox.Text.Trim();
                loginpas.Pass = PasTBox.Text.Trim();
                var Dolznosti = Laba5Entities.Dolznostis.ToList();
                foreach (var item in Dolznosti)
                {
                    if (item.DolznostName == "Клиент")
                    {
                        loginpas.FK_Dolznosti = item.Dolznosti_ID;
                    }
                }
                Laba5Entities.LoginPasses.Add(loginpas);
                Laba5Entities.SaveChanges();
                return proverka;
            }
            if (proverka == false)
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                return proverka;
            }
            return proverka;
        }

        private bool ProverkaSNM()
        {
            var proverka1 = isLeter(ClientSurnameTbox.Text.Trim());
            var proverka2 = isLeter(ClientMiddleNameTbox.Text.Trim());
            var proverka3 = isLeter(ClientNameTbox.Text.Trim());
            if(proverka1 == true && proverka2 == true && proverka3 == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}