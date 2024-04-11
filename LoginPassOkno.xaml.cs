using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laba5
{
    /// <summary>
    /// Логика взаимодействия для LoginPassOkno.xaml
    /// </summary>
    public partial class LoginPassOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public LoginPassOkno()
        {
            InitializeComponent();
            loginpassDG.ItemsSource = Laba5Entities.LoginPasses.ToList();
            dolznostiCbox.ItemsSource = Laba5Entities.Dolznostis.ToList();
            dolznostiCbox.DisplayMemberPath = "DolznostName";
        }

        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        private void loginpassDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var loginpass = loginpassDG.SelectedItem as LoginPasses ?? new LoginPasses();
            if (loginpass.Loginn != null)
            {
                LoginTbox.Text = loginpass.Loginn.ToString();
                PassTbox.Text = loginpass.Pass.ToString();
                var Dolznosti = Laba5Entities.Dolznostis.ToList();
                foreach (var d in Dolznosti)
                {
                    if (d.Dolznosti_ID == loginpass.FK_Dolznosti)
                    {
                        dolznostiCbox.SelectedItem = d;
                    }
                }
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTbox.Text.Trim().Length < 30 && PassTbox.Text.Trim().Length < 30 && LoginTbox.Text.Trim().Length > 4 && PassTbox.Text.Trim().Length > 5)
            {
                if (dolznostiCbox.SelectedItem != null)
                {
                    var selected = loginpassDG.SelectedItem as LoginPasses;
                    bool proverka = true;
                    foreach (var item in Laba5Entities.LoginPasses)
                    {
                        if (item.Loginn == LoginTbox.Text)
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        selected.Loginn = LoginTbox.Text.Trim();
                        selected.Pass = PassTbox.Text.Trim();
                        var Dolznosti = Laba5Entities.Dolznostis.ToList();
                        foreach (var item in Dolznosti)
                        {
                            if (item == dolznostiCbox.SelectedItem)
                            {
                                selected.FK_Dolznosti = item.Dolznosti_ID;
                            }
                        }
                        Laba5Entities.SaveChanges();
                        OshibkaTBlock.Text = null;
                    }
                    if (proverka == false)
                    {
                        OshibkaTBlock.Text = "Такой логин уже есть";
                    }
                    loginpassDG.ItemsSource = Laba5Entities.LoginPasses.ToList();
                    LoginTbox.Text = null;
                    PassTbox.Text = null;
                    dolznostiCbox.SelectedItem = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Должность не выбрана";
                }
            }
            else
            {
                OshibkaTBlock.Text = "Логин и пароль должен быть больше 4 символов";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTbox.Text.Trim().Length < 30 && PassTbox.Text.Trim().Length < 30 && LoginTbox.Text.Trim().Length > 4 && PassTbox.Text.Trim().Length > 5)
            {
                if(dolznostiCbox.SelectedItem != null)
                {
                    LoginPasses loginpas = new LoginPasses();
                    bool proverka = true;
                    foreach (var item in Laba5Entities.LoginPasses)
                    {
                        if (item.Loginn == LoginTbox.Text)
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        loginpas.Loginn = LoginTbox.Text.Trim();
                        loginpas.Pass = PassTbox.Text.Trim();
                        var Dolznosti = Laba5Entities.Dolznostis.ToList();
                        foreach (var item in Dolznosti)
                        {
                            if (item == dolznostiCbox.SelectedItem)
                            {
                                loginpas.FK_Dolznosti = item.Dolznosti_ID;
                            }
                        }
                        Laba5Entities.LoginPasses.Add(loginpas);
                        Laba5Entities.SaveChanges();
                        OshibkaTBlock.Text = null;
                    }
                    else
                    {
                        OshibkaTBlock.Text = "Такой логин уже есть";
                    }
                    loginpassDG.ItemsSource = Laba5Entities.LoginPasses.ToList();
                    LoginTbox.Text = null;
                    PassTbox.Text = null;
                    dolznostiCbox.SelectedItem = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Должность не выбрана";
                }
            }
            else
            {
                OshibkaTBlock.Text = "Логин и пароль должен быть больше 4 символов";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if (loginpassDG.SelectedItem != null)
            {
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.Sotrudnicks)
                {
                    foreach (var item1 in Laba5Entities.Clients)
                    {
                        if (item.FK_LoginPass == (loginpassDG.SelectedItem as LoginPasses).LoginPass_ID 
                        || item1.FK_LoginPass == (loginpassDG.SelectedItem as LoginPasses).LoginPass_ID)
                        {
                            OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                            proverka = false;
                        }
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.LoginPasses.Remove(loginpassDG.SelectedItem as LoginPasses);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
                loginpassDG.ItemsSource = Laba5Entities.LoginPasses.ToList();
                LoginTbox.Text = null;
                PassTbox.Text = null;
                dolznostiCbox.SelectedItem = null;
                loginpassDG.SelectedItem = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }

        private void dolzOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            DolznostiOkno dolznostiOkno = new DolznostiOkno();
            dolznostiOkno.ShowDialog();
            Close();
        }
    }
}
