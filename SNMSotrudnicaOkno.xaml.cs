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
    /// Логика взаимодействия для SNMSotrudnicaOkno.xaml
    /// </summary>
    public partial class SNMSotrudnicaOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public SNMSotrudnicaOkno()
        {
            InitializeComponent();
            SNMSotrudDG.ItemsSource = Laba5Entities.SNM_Sortudnicks.ToList();
        }

        public bool isLeter(string input)
        {
            return input.All(c => char.IsLetter(c));
        }

        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        private void SNMSotrudDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SNMSotr = SNMSotrudDG.SelectedItem as SNM_Sortudnicks ?? new SNM_Sortudnicks();
            if (SNMSotr.SortudnickSurname != null)
            {
                SotrudSurnameTbox.Text = SNMSotr.SortudnickSurname.ToString();
                SotrudNameTbox.Text = SNMSotr.SortudnickName.ToString();
                SotrudMiddleNameTbox.Text = SNMSotr.SortudnickMiddleName.ToString();
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (SotrudSurnameTbox.Text.Trim().Length < 50 && SotrudNameTbox.Text.Trim().Length < 50 && SotrudSurnameTbox.Text.Trim().Length > 3 && SotrudNameTbox.Text.Trim().Length >= 2)
            {
                if (SNMSotrudDG.SelectedItem != null)
                {
                    var selected = SNMSotrudDG.SelectedItem as SNM_Sortudnicks;
                    bool proverka1 = isLeter(SotrudSurnameTbox.Text);
                    bool proverka2 = isLeter(SotrudNameTbox.Text);
                    bool proverka3 = isLeter(SotrudMiddleNameTbox.Text);
                    if (proverka1 == true && proverka2 == true && proverka3 == true)
                    {
                        selected.SortudnickSurname = SotrudSurnameTbox.Text.Trim();
                        selected.SortudnickName = SotrudNameTbox.Text.Trim();
                        selected.SortudnickMiddleName = SotrudMiddleNameTbox.Text.Trim();
                        Laba5Entities.SaveChanges();
                        OshibkaTBlock.Text = null;
                    }
                    else
                    {
                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                    }
                    SNMSotrudDG.ItemsSource = Laba5Entities.SNM_Sortudnicks.ToList();
                    SotrudSurnameTbox.Text = null;
                    SotrudNameTbox.Text = null;
                    SotrudMiddleNameTbox.Text = null;
                }
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if(SotrudSurnameTbox.Text.Trim().Length < 50 && SotrudNameTbox.Text.Trim().Length < 50 && SotrudSurnameTbox.Text.Trim().Length > 3 && SotrudNameTbox.Text.Trim().Length >= 2)
            {
                SNM_Sortudnicks SNMSotru = new SNM_Sortudnicks();
                bool proverka1 = isLeter(SotrudSurnameTbox.Text);
                bool proverka2 = isLeter(SotrudNameTbox.Text);
                bool proverka3 = isLeter(SotrudMiddleNameTbox.Text);
                if (proverka1 == true && proverka2 == true && proverka3 == true)
                {
                    SNMSotru.SortudnickSurname = SotrudSurnameTbox.Text.Trim();
                    SNMSotru.SortudnickName = SotrudNameTbox.Text.Trim();
                    SNMSotru.SortudnickMiddleName = SotrudMiddleNameTbox.Text.Trim();
                    Laba5Entities.SNM_Sortudnicks.Add(SNMSotru);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                }
                SNMSotrudDG.ItemsSource = Laba5Entities.SNM_Sortudnicks.ToList();
                SotrudSurnameTbox.Text = null;
                SotrudNameTbox.Text = null;
                SotrudMiddleNameTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if (SNMSotrudDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var login in Laba5Entities.Sotrudnicks)
                {
                    if (login.FK_SNM_Sortudnick == (SNMSotrudDG.SelectedItem as SNM_Sortudnicks).SNM_Sortudnick_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.SNM_Sortudnicks.Remove(SNMSotrudDG.SelectedItem as SNM_Sortudnicks);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
                SNMSotrudDG.ItemsSource = Laba5Entities.SNM_Sortudnicks.ToList();
                SotrudSurnameTbox.Text = null;
                SotrudNameTbox.Text = null;
                SotrudMiddleNameTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }
    }
}
