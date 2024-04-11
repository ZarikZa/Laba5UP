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
    /// Логика взаимодействия для DolznostiOkno.xaml
    /// </summary>
    public partial class DolznostiOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public DolznostiOkno()
        {
            InitializeComponent();
            dolznostDG.ItemsSource = Laba5Entities.Dolznostis.ToList();
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

        private void dolznostDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dolznost = dolznostDG.SelectedItem as Dolznostis ?? new Dolznostis();
            if (dolznost.DolznostName != null)
            {
                DolznostTbox.Text = dolznost.DolznostName.ToString();
            }
            OshibkaTBlock.Text = null;
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (DolznostTbox.Text.Trim().Length < 40 && DolznostTbox.Text.Trim().Length > 2)
            {
                if (dolznostDG.SelectedItem != null)
                {
                    var selected = dolznostDG.SelectedItem as Dolznostis;
                    bool proverka = true;
                    bool proverka2 = true;
                    foreach (var item in Laba5Entities.Dolznostis)
                    {
                        if (item.DolznostName == DolznostTbox.Text)
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        proverka2 = isLeter(DolznostTbox.Text);
                        if (proverka2 == true)
                        {
                            selected.DolznostName = DolznostTbox.Text.Trim();
                            Laba5Entities.SaveChanges();
                            OshibkaTBlock.Text = null;
                        }
                        else
                        {
                            OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                        }
                    }
                    else
                    {
                        OshibkaTBlock.Text = "Такая должность уже есть";
                    }
                    dolznostDG.ItemsSource = Laba5Entities.Dolznostis.ToList();
                    DolznostTbox.Text = null;
                }
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (DolznostTbox.Text.Trim().Length < 40 && DolznostTbox.Text.Trim().Length > 2)
            {
                Dolznostis dolznost = new Dolznostis();
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.Dolznostis)
                {
                    if (item.DolznostName == DolznostTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(DolznostTbox.Text);
                    if (proverka2 == true)
                    {
                        dolznost.DolznostName = DolznostTbox.Text.Trim();
                        Laba5Entities.Dolznostis.Add(dolznost);
                        Laba5Entities.SaveChanges();
                        OshibkaTBlock.Text = null;
                    }
                    else
                    {
                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                    } 
                }
                else
                {
                    OshibkaTBlock.Text = "Такая должность уже есть";
                }
                dolznostDG.ItemsSource = Laba5Entities.Dolznostis.ToList();
                DolznostTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if (dolznostDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var login in Laba5Entities.LoginPasses)
                {
                    foreach (var sotrudnicks in Laba5Entities.Sotrudnicks)
                    {
                        if (login.FK_Dolznosti == (dolznostDG.SelectedItem as Dolznostis).Dolznosti_ID 
                        || sotrudnicks.FK_Dolznost == (dolznostDG.SelectedItem as Dolznostis).Dolznosti_ID)
                        {
                            OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                            proverka = false;
                        }
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.Dolznostis.Remove(dolznostDG.SelectedItem as Dolznostis);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
                dolznostDG.ItemsSource = Laba5Entities.Dolznostis.ToList();
                DolznostTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }
    }
}
