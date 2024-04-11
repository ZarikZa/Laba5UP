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
    /// Логика взаимодействия для UnitaziOkno.xaml
    /// </summary>
    public partial class UnitaziOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public UnitaziOkno()
        {
            InitializeComponent();
            unitaziDG.ItemsSource = Laba5Entities.Unitazs.ToList();
            CountryCBox.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
            CountryCBox.DisplayMemberPath = "CountryProizvodstva";
            UnitazTypeCBox.ItemsSource = Laba5Entities.UnitazTypes.ToList();
            UnitazTypeCBox.DisplayMemberPath = "UnitazType";
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

        private void CountryOkno_Click(object sender, RoutedEventArgs e)
        {
            CountryProizvodstvaOkno country = new CountryProizvodstvaOkno();
            country.BackBtm.IsEnabled = false;
            country.ShowDialog();
        }

        private void TypeUnitazOkno_Click(object sender, RoutedEventArgs e)
        {
            UnitazTypeOkno unitazTypeOkno = new UnitazTypeOkno();
            unitazTypeOkno.BackBtm.IsEnabled = false;
            unitazTypeOkno.ShowDialog();
        }

        private void unitaziDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Unitaz = unitaziDG.SelectedItem as Unitazs ?? new Unitazs();
            var TypeUnitaz = Laba5Entities.UnitazTypes.ToList();
            var Country = Laba5Entities.CountryProizvodstvas.ToList();
            if (Unitaz.UnitazName != null)
            {
                UnitazNameTbox.Text = Unitaz.UnitazName.ToString();
                UnitazPriceTbox.Text =  Unitaz.UnitazPrice.ToString();
                foreach (var item in TypeUnitaz)
                {
                    if (item.UnitazType_ID == Unitaz.FK_UnitazType)
                    {
                        UnitazTypeCBox.SelectedItem = item;
                    }
                }
                foreach (var item in Country)
                {
                    if(item.CountryProizvodstva_ID == Unitaz.FK_CountryProizvodstva)
                    {
                        CountryCBox.SelectedItem = item;
                    }
                }
            }
            OshibkaTBlock.Text = null;
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (UnitazNameTbox.Text.Trim().Length < 40 && UnitazNameTbox.Text.Trim().Length > 3)
            {
                if (unitaziDG.SelectedItem != null)
                {
                    var selected = unitaziDG.SelectedItem as Unitazs;
                    bool proverka = true;
                    bool proverka2 = true;
                    bool proverka3 = true;
                    foreach (var item in Laba5Entities.Unitazs)
                    {
                        if (item.UnitazName == UnitazNameTbox.Text)
                        {
                            if(item.UnitazName != (unitaziDG.SelectedItem as Unitazs).UnitazName)
                            {
                                proverka = false;
                            }
                        }
                    }
                    if (proverka == true)
                    {
                        proverka2 = isLeter(UnitazNameTbox.Text);
                        try
                        {
                            Convert.ToDecimal(UnitazPriceTbox.Text.Trim());
                            proverka3 = true;
                        }
                        catch (Exception)
                        {
                            proverka3 = false;
                        }
                        if (proverka2 == true && proverka3 == true)
                        {
                            selected.UnitazName = UnitazNameTbox.Text.Trim();
                            selected.UnitazPrice = Convert.ToDecimal(UnitazPriceTbox.Text.Trim());
                            var UnitaType = Laba5Entities.UnitazTypes.ToList();
                            foreach (var item in UnitaType)
                            {
                                if (item == UnitazTypeCBox.SelectedItem)
                                {
                                    selected.FK_UnitazType = item.UnitazType_ID;

                                }
                            }
                            var Country = Laba5Entities.CountryProizvodstvas.ToList();
                            foreach (var item in Country)
                            {
                                if (item == CountryCBox.SelectedItem)
                                {
                                    selected.FK_CountryProizvodstva = item.CountryProizvodstva_ID;
                                }
                            }
                            Laba5Entities.SaveChanges();
                            OshibkaTBlock.Text = null;
                        }
                        else
                        {
                            OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                        }
                    }
                    if (proverka == false)
                    {
                        OshibkaTBlock.Text = "Такой унитаз уже есть";
                    }
                    unitaziDG.ItemsSource = Laba5Entities.Unitazs.ToList();
                    CountryCBox.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
                    UnitazTypeCBox.ItemsSource = Laba5Entities.UnitazTypes.ToList();
                    UnitazNameTbox.Text = null;
                    UnitazPriceTbox.Text = null;
                    CountryCBox.SelectedItem = null;
                    UnitazTypeCBox.SelectedItem = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Имя унитаза маленькое или большое";
                }
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (UnitazNameTbox.Text.Trim().Length < 40 && UnitazNameTbox.Text.Trim().Length > 3)
            {
                Unitazs unitaz = new Unitazs();
                bool proverka = true;
                bool proverka2 = true;
                bool proverka3 = true;
                foreach (var item in Laba5Entities.Unitazs)
                {
                    if (item.UnitazName == UnitazNameTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(UnitazNameTbox.Text);
                    try
                    {
                        Convert.ToDecimal(UnitazPriceTbox.Text.Trim());
                        proverka3 = true;
                    }
                    catch (Exception)
                    {
                        proverka3 = false;
                    }
                    if (proverka2 == true && proverka3 == true)
                    {
                        unitaz.UnitazName = UnitazNameTbox.Text.Trim();
                        unitaz.UnitazPrice = Convert.ToDecimal(UnitazPriceTbox.Text.Trim());
                        var UnitaType = Laba5Entities.UnitazTypes.ToList();
                        foreach (var item in UnitaType)
                        {
                            if (item == UnitazTypeCBox.SelectedItem)
                            {
                                unitaz.FK_UnitazType = item.UnitazType_ID;

                            }
                        }
                        var Country = Laba5Entities.CountryProizvodstvas.ToList();
                        foreach (var item in Country)
                        {
                            if (item == CountryCBox.SelectedItem)
                            {
                                unitaz.FK_CountryProizvodstva = item.CountryProizvodstva_ID;
                            }
                        }
                        Laba5Entities.Unitazs.Add(unitaz);
                        Laba5Entities.SaveChanges();
                        OshibkaTBlock.Text = null;
                        unitaziDG.ItemsSource = Laba5Entities.Unitazs.ToList();
                    }
                    else
                    {
                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                    }
                }
                if (proverka == false)
                {
                    OshibkaTBlock.Text = "Такой унитаз уже есть";
                }
                
                CountryCBox.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
                UnitazTypeCBox.ItemsSource = Laba5Entities.UnitazTypes.ToList();
                UnitazNameTbox.Text = null;
                UnitazPriceTbox.Text = null;
                CountryCBox.SelectedItem = null;
                UnitazTypeCBox.SelectedItem = null;
            }
            else
            {
                OshibkaTBlock.Text = "Имя унитаза маленькое или большое";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if (unitaziDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var item in Laba5Entities.Zakazs)
                {
                    if (item.FK_Unitaz == (unitaziDG.SelectedItem as Unitazs).Unitaz_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.Unitazs.Remove(unitaziDG.SelectedItem as Unitazs);
                    Laba5Entities.SaveChanges();
                }
                unitaziDG.ItemsSource = Laba5Entities.Unitazs.ToList();
                CountryCBox.ItemsSource = Laba5Entities.CountryProizvodstvas.ToList();
                UnitazTypeCBox.ItemsSource = Laba5Entities.UnitazTypes.ToList();
                UnitazNameTbox.Text = null;
                UnitazPriceTbox.Text = null;
                CountryCBox.SelectedItem = null;
                UnitazTypeCBox.SelectedItem = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }
    }
}