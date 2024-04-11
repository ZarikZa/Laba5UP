using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для SotrudnickOkno.xaml
    /// </summary>
    public partial class SotrudnickOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public SotrudnickOkno()
        {
            InitializeComponent();
            SotrudDG.ItemsSource = Laba5Entities.Sotrudnicks.ToList();
            var DoznostiList = Laba5Entities.Dolznostis.ToList();
            for (int i = 0; i < DoznostiList.Count; i++)
            {
                if (DoznostiList[i].DolznostName == "Клиент")
                {
                    DoznostiList.Remove(DoznostiList[i]);
                }
            }
            DolznostCBox.ItemsSource = DoznostiList;
            DolznostCBox.DisplayMemberPath = "DolznostName";
        }
        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        private void DolznostOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            DolznostiOkno dolznostiOkno = new DolznostiOkno();
            dolznostiOkno.BackBtm.IsEnabled = false;
            dolznostiOkno.ShowDialog();
        }

        public bool isLeter(string input)
        {
            return input.All(c => char.IsLetter(c));
        }

        private void SotrudDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Sotrud = SotrudDG.SelectedItem as Sotrudnicks ?? new Sotrudnicks();
            if (Sotrud.Dolznostis != null)
            {
                SotrudSurnameTbox.Text = Sotrud.SNM_Sortudnicks.SortudnickSurname.ToString();
                SotrudNameTbox.Text =  Sotrud.SNM_Sortudnicks.SortudnickName.ToString();
                SotrudMiddleNameTbox.Text =  Sotrud.SNM_Sortudnicks.SortudnickMiddleName.ToString();
                var Dolznosti = Laba5Entities.Dolznostis.ToList();
                foreach (var d in Dolznosti)
                {
                    if(d.Dolznosti_ID == Sotrud.FK_Dolznost)
                    {
                        DolznostCBox.SelectedItem = d;
                    }
                }
                LoginTbox.Text = Sotrud.LoginPasses.Loginn.ToString();
                PassTbox.Text = Sotrud.LoginPasses.Pass.ToString();
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (SotrudSurnameTbox.Text.Trim().Length < 50 && SotrudNameTbox.Text.Trim().Length < 50 && SotrudSurnameTbox.Text.Trim().Length > 3 && SotrudNameTbox.Text.Trim().Length >= 2 && LoginTbox.Text.Trim().Length < 30 && PassTbox.Text.Trim().Length < 30 && LoginTbox.Text.Trim().Length > 4 && PassTbox.Text.Trim().Length > 5)
            {
                if (SotrudDG.SelectedItem != null)
                {
                    var selected = SotrudDG.SelectedItem as Sotrudnicks;
                    bool proverka1 = ProverkaSNM();
                    if (proverka1 == true)
                    {
                        selected.SNM_Sortudnicks.SortudnickSurname = SotrudSurnameTbox.Text.Trim();
                        selected.SNM_Sortudnicks.SortudnickName = SotrudNameTbox.Text.Trim();
                        selected.SNM_Sortudnicks.SortudnickMiddleName = SotrudMiddleNameTbox.Text.Trim();
                        foreach (var item in Laba5Entities.LoginPasses)
                        {
                            if(LoginTbox.Text == item.Loginn)
                            {
                                proverka1 = false; 
                                break;
                            }
                        }
                        if (proverka1 == true)
                        {
                            selected.LoginPasses.Loginn = LoginTbox.Text.Trim();
                            selected.LoginPasses.Pass = PassTbox.Text.Trim();
                            foreach (var item in Laba5Entities.Dolznostis)
                            {
                                if (item == DolznostCBox.SelectedItem)
                                {
                                    selected.FK_Dolznost = item.Dolznosti_ID;
                                    selected.LoginPasses.FK_Dolznosti = item.Dolznosti_ID;
                                }
                            }
                            Laba5Entities.SaveChanges();
                            OshibkaTBlock.Text = null;
                            SotrudDG.ItemsSource = Laba5Entities.Sotrudnicks.ToList();
                            SotrudSurnameTbox.Text = null;
                            SotrudNameTbox.Text = null;
                            SotrudMiddleNameTbox.Text = null;
                            LoginTbox.Text = null;
                            PassTbox.Text = null;
                            DolznostCBox.SelectedItem = null;
                            SotrudDG.SelectedItem = null;
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
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (SotrudSurnameTbox.Text.Trim().Length < 50 && SotrudNameTbox.Text.Trim().Length < 50 && SotrudSurnameTbox.Text.Trim().Length > 3 && SotrudNameTbox.Text.Trim().Length >= 2 && LoginTbox.Text.Trim().Length < 30 && PassTbox.Text.Trim().Length < 30 && LoginTbox.Text.Trim().Length > 4 && PassTbox.Text.Trim().Length > 5)
            {
                SNM_Sortudnicks sNM_Sortudnicks = new SNM_Sortudnicks();
                LoginPasses loginPasses = new LoginPasses();
                Sotrudnicks Sotrud = new Sotrudnicks();
                bool proverka = false;
                bool proverka1 = ProverkaSNM();
                if(proverka1 == true)
                {
                    sNM_Sortudnicks.SortudnickSurname = SotrudSurnameTbox.Text.Trim();
                    sNM_Sortudnicks.SortudnickName = SotrudNameTbox.Text.Trim();
                    sNM_Sortudnicks.SortudnickMiddleName = SotrudMiddleNameTbox.Text.Trim();
                    foreach (var item in Laba5Entities.SNM_Sortudnicks)
                    {
                        if(item == sNM_Sortudnicks)
                        {
                            Sotrud.FK_SNM_Sortudnick = item.SNM_Sortudnick_ID;
                            proverka = true;
                        }
                    }
                    if(proverka == false)
                    {
                        Laba5Entities.SNM_Sortudnicks.Add(sNM_Sortudnicks);
                        Laba5Entities.SaveChanges();
                        foreach (var item in Laba5Entities.SNM_Sortudnicks)
                        {
                            if (item == sNM_Sortudnicks)
                            {
                                Sotrud.FK_SNM_Sortudnick = item.SNM_Sortudnick_ID;
                                proverka = true;
                            }
                        }
                    }
                    if(proverka == true)
                    {
                        loginPasses.Loginn = LoginTbox.Text.Trim();
                        loginPasses.Pass = PassTbox.Text.Trim();
                        foreach (var item in Laba5Entities.Dolznostis)
                        {
                            if(item == DolznostCBox.SelectedItem)
                            {
                                Sotrud.FK_Dolznost = item.Dolznosti_ID;
                                loginPasses.FK_Dolznosti = item.Dolznosti_ID;
                            }
                        }
                        Laba5Entities.LoginPasses.Add(loginPasses);
                        Laba5Entities.SaveChanges();
                        foreach (var item in Laba5Entities.LoginPasses)
                        {
                            if (item == loginPasses)
                            {
                                Sotrud.FK_LoginPass = item.LoginPass_ID;
                            }
                        }
                        Laba5Entities.Sotrudnicks.Add(Sotrud);
                        Laba5Entities.SaveChanges();
                        OshibkaTBlock.Text = null;
                        SotrudDG.ItemsSource = Laba5Entities.Sotrudnicks.ToList();
                        SotrudSurnameTbox.Text = null;
                        SotrudNameTbox.Text = null;
                        SotrudMiddleNameTbox.Text = null;
                        LoginTbox.Text = null;
                        PassTbox.Text = null;
                        DolznostCBox.SelectedItem = null;
                        SotrudDG.SelectedItem = null;
                    }
                    else
                    {
                        OshibkaTBlock.Text = "Какая-то ошибка";
                    }
                }
                else
                {
                    OshibkaTBlock.Text = "ФИО заполнено неверно";
                }
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if(SotrudDG.SelectedItem != null)
            {
                Laba5Entities.Sotrudnicks.Remove(SotrudDG.SelectedItem as Sotrudnicks);
                Laba5Entities.SaveChanges();
                OshibkaTBlock.Text = null;
                SotrudDG.ItemsSource = Laba5Entities.Sotrudnicks.ToList();
                SotrudSurnameTbox.Text = null;
                SotrudNameTbox.Text = null;
                SotrudMiddleNameTbox.Text = null;
                LoginTbox.Text = null;
                PassTbox.Text = null;
                DolznostCBox.SelectedItem = null;
                SotrudDG.SelectedItem = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }

        private bool ProverkaSNM()
        {
            var proverka1 = isLeter(SotrudMiddleNameTbox.Text.Trim());
            var proverka2 = isLeter(SotrudNameTbox.Text.Trim());
            var proverka3 = isLeter(SotrudSurnameTbox.Text.Trim());
            if (proverka1 == true && proverka2 == true && proverka3 == true)
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
