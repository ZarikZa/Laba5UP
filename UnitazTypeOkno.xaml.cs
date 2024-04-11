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
    /// Логика взаимодействия для UnitazTypeOkno.xaml
    /// </summary>
    public partial class UnitazTypeOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public UnitazTypeOkno()
        {
            InitializeComponent();
            typeUnitazDG.ItemsSource = Laba5Entities.UnitazTypes.ToList();
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

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (TypeUniTbox.Text.Trim().Length < 40 && TypeUniTbox.Text.Trim().Length > 3)
            {
                UnitazTypes unitazTypes = new UnitazTypes();
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.UnitazTypes)
                {
                    if (item.UnitazType == TypeUniTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(TypeUniTbox.Text);
                    if (proverka2 == true)
                    {
                        unitazTypes.UnitazType = TypeUniTbox.Text.Trim();
                        Laba5Entities.UnitazTypes.Add(unitazTypes);
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
                    OshibkaTBlock.Text = "Такой тип уже есть";
                }
                typeUnitazDG.ItemsSource = Laba5Entities.UnitazTypes.ToList();
                TypeUniTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Тип унитаза маленький или большой";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if (typeUnitazDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var item in Laba5Entities.Unitazs)
                {
                    if (item.FK_UnitazType == (typeUnitazDG.SelectedItem as UnitazTypes).UnitazType_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.UnitazTypes.Remove(typeUnitazDG.SelectedItem as UnitazTypes);
                    Laba5Entities.SaveChanges();
                    OshibkaTBlock.Text = null;
                }
                typeUnitazDG.ItemsSource = Laba5Entities.UnitazTypes.ToList();
                TypeUniTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }

        private void typeUnitazDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var unitazType = typeUnitazDG.SelectedItem as UnitazTypes ?? new UnitazTypes();
            if (unitazType.UnitazType != null)
            {
                TypeUniTbox.Text = unitazType.UnitazType.ToString();
            }
            OshibkaTBlock.Text = null;
        }
        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (TypeUniTbox.Text.Trim().Length < 40 && TypeUniTbox.Text.Trim().Length > 3)
            {
                var selected = typeUnitazDG.SelectedItem as UnitazTypes;
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.UnitazTypes)
                {
                    if (item.UnitazType == TypeUniTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(TypeUniTbox.Text);
                    if (proverka2 == true)
                    {
                        selected.UnitazType = TypeUniTbox.Text.Trim();
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
                    OshibkaTBlock.Text = "Такой тип уже есть";
                }
                typeUnitazDG.ItemsSource = Laba5Entities.UnitazTypes.ToList();
                TypeUniTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Тип унитаза маленький или большой";
            }
        }

        private void VigruzkaBtm_Click(object sender, RoutedEventArgs e)
        {
            Conve conve = new Conve();
            var ListCoun = conve.Jsonviser<List<UnitazTypes>>("UnitazTypes.json");
            foreach (var item in ListCoun)
            {
                var povtorThing = Laba5Entities.UnitazTypes.FirstOrDefault(x => x.UnitazType == item.UnitazType);
                if (povtorThing == null)
                {
                    Laba5Entities.UnitazTypes.Add(item);
                    Laba5Entities.SaveChanges();
                }
            }
            VigruzkaBtm.IsEnabled = false;
            typeUnitazDG.ItemsSource = Laba5Entities.UnitazTypes.ToList();
        }
    }
}