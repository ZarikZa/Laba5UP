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
    /// Логика взаимодействия для CountryProizvodstvaOkno.xaml
    /// </summary>
    public partial class CountryProizvodstvaOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public CountryProizvodstvaOkno()
        {
            InitializeComponent();
            countryProizDG.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
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

        private void countryProizDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var country = countryProizDG.SelectedItem as CountryProizvodstvas ?? new CountryProizvodstvas();
            if (country.CountryProizvodstva != null)
            {
                CountryProizTbox.Text = country.CountryProizvodstva.ToString();
            }
            OshibkaTBlock.Text = null;
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (CountryProizTbox.Text.Trim().Length < 30 && CountryProizTbox.Text.Trim().Length > 3)
            {
                if (countryProizDG.SelectedItem != null)
                {
                    var selected = countryProizDG.SelectedItem as CountryProizvodstvas;
                    bool proverka = true;
                    bool proverka2 = true;
                    foreach (var item in Laba5Entities.CountryProizvodstvas)
                    {
                        if (item.CountryProizvodstva == CountryProizTbox.Text)
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        proverka2 = isLeter(CountryProizTbox.Text);
                        if (proverka2 == true)
                        {
                            selected.CountryProizvodstva = CountryProizTbox.Text.Trim();
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
                        OshibkaTBlock.Text = "Такая страна уже есть";
                    }
                    countryProizDG.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
                    CountryProizTbox.Text = null;
                }
            }
            else
            {
                OshibkaTBlock.Text = "Название страны маленькое или большой";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if(CountryProizTbox.Text.Trim().Length < 30 && CountryProizTbox.Text.Trim().Length > 3)
            {
                CountryProizvodstvas country = new CountryProizvodstvas();
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.CountryProizvodstvas)
                {
                    if (item.CountryProizvodstva == CountryProizTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(CountryProizTbox.Text);
                    if (proverka2 == true)
                    {
                        country.CountryProizvodstva = CountryProizTbox.Text.Trim();
                        Laba5Entities.CountryProizvodstvas.Add(country);
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
                    OshibkaTBlock.Text = "Такая страна уже есть";
                }
                countryProizDG.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
                CountryProizTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Название страны маленькое или большой";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if(countryProizDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var item in Laba5Entities.Unitazs)
                {
                    if (item.FK_CountryProizvodstva == (countryProizDG.SelectedItem as CountryProizvodstvas).CountryProizvodstva_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.CountryProizvodstvas.Remove(countryProizDG.SelectedItem as CountryProizvodstvas);
                    Laba5Entities.SaveChanges();
                }
                countryProizDG.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
                CountryProizTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }

        private void VigruzkaBtm_Click(object sender, RoutedEventArgs e)
        {
            Conve conve = new Conve();
            var ListCoun = conve.Jsonviser<List<CountryProizvodstvas>>("CountryProizv.json");
            foreach (var item in ListCoun)
            {
                var povtorThing = Laba5Entities.CountryProizvodstvas.FirstOrDefault(x => x.CountryProizvodstva == item.CountryProizvodstva);
                if (povtorThing == null)
                {
                    Laba5Entities.CountryProizvodstvas.Add(item);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
            }
            VigruzkaBtm.IsEnabled = false;
            countryProizDG.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
        }
    }
}
