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
    /// Логика взаимодействия для GorodOkno.xaml
    /// </summary>
    public partial class GorodOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public GorodOkno()
        {
            InitializeComponent();
            gorodDG.ItemsSource = Laba5Entities.Gorods.ToList();
        }

        public bool isLeter(string input)
        {
            return input.All(c => char.IsLetter(c));
        }

        private void gorodDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gorod = gorodDG.SelectedItem as Gorods ?? new Gorods();
            if (gorod.GorodName != null)
            {
                GorodTbox.Text = gorod.GorodName.ToString();
            }
            OshibkaTBlock.Text = null;
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (GorodTbox.Text.Trim().Length < 30 && GorodTbox.Text.Trim().Length > 3)
            {
                var selected = gorodDG.SelectedItem as Gorods;
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.Gorods)
                {
                    if (item.GorodName == GorodTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(GorodTbox.Text);
                    if (proverka2 == true)
                    {
                        selected.GorodName = GorodTbox.Text.Trim();
                        Laba5Entities.SaveChanges();
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
                gorodDG.ItemsSource = Laba5Entities.Gorods.ToList();
                GorodTbox.Text = null;
                OshibkaTBlock.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (GorodTbox.Text.Trim().Length < 30 && GorodTbox.Text.Trim().Length > 3)
            {
                Gorods gorods = new Gorods();
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.Gorods)
                {
                    if (item.GorodName == GorodTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if(proverka == true)
                {
                    proverka2 = isLeter(GorodTbox.Text);
                    if (proverka2 == true)
                    {
                        gorods.GorodName = GorodTbox.Text.Trim();
                        Laba5Entities.Gorods.Add(gorods);
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
                    OshibkaTBlock.Text = "Такой город уже есть";
                }
                gorodDG.ItemsSource = Laba5Entities.Gorods.ToList();
                GorodTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }


        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if(gorodDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var item in Laba5Entities.AdresaDostavkis)
                {
                    if (item.FK_Gorod == (gorodDG.SelectedItem as Gorods).Gorod_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";

                        proverka = false;
                    }
                }
                if(proverka != false)
                {
                    Laba5Entities.Gorods.Remove(gorodDG.SelectedItem as Gorods);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
                gorodDG.ItemsSource = Laba5Entities.Gorods.ToList();
                GorodTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }

        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        private void VigruzkaBtm_Click(object sender, RoutedEventArgs e)
        {
            Conve conve = new Conve();
            var ListGor = conve.Jsonviser<List<Gorods>>("Goroda.json");
            foreach (var item in ListGor)
            {
                var povtorThing = Laba5Entities.Gorods.FirstOrDefault(x => x.GorodName == item.GorodName);
                if (povtorThing == null)
                {
                    Laba5Entities.Gorods.Add(item);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
            }
            VigruzkaBtm.IsEnabled = false;
            gorodDG.ItemsSource = Laba5Entities.Gorods.ToList();
        }
    }
}
