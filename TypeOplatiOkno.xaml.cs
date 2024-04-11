using Laba5;
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
    /// Логика взаимодействия для TypeOplatiOkno.xaml
    /// </summary>
    public partial class TypeOplatiOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public TypeOplatiOkno()
        {
            InitializeComponent();
            typeOplatiDG.ItemsSource = Laba5Entities.TypeOplatis.ToList();
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

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (TypeOplatiTbox.Text.Trim().Length < 30 && TypeOplatiTbox.Text.Trim().Length > 4)
            {
                if(typeOplatiDG.SelectedItem != null)
                {
                    var selected = typeOplatiDG.SelectedItem as TypeOplatis;
                    bool proverka = true;
                    bool proverka2 = true;
                    foreach (var item in Laba5Entities.TypeOplatis)
                    {
                        if (item.TypeOplati == TypeOplatiTbox.Text)
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        proverka2 = isLeter(TypeOplatiTbox.Text);
                        if (proverka2 == true)
                        {
                            selected.TypeOplati = TypeOplatiTbox.Text.Trim();
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
                        OshibkaTBlock.Text = "Такой тип оплаты уже есть";
                    }
                    typeOplatiDG.ItemsSource = Laba5Entities.TypeOplatis.ToList();
                    TypeOplatiTbox.Text = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                }
            }
        }

        private void typeOplatiDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var typrOplat = typeOplatiDG.SelectedItem as TypeOplatis ?? new TypeOplatis();
            if (typrOplat.TypeOplati != null)
            {
                TypeOplatiTbox.Text = typrOplat.TypeOplati.ToString();
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (TypeOplatiTbox.Text.Trim().Length < 30 && TypeOplatiTbox.Text.Trim().Length > 4)
            {
                TypeOplatis typrOplat = new TypeOplatis();
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.TypeOplatis)
                {
                    if (item.TypeOplati == TypeOplatiTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(TypeOplatiTbox.Text);
                    if (proverka2 == true)
                    {
                        typrOplat.TypeOplati = TypeOplatiTbox.Text.Trim();
                        Laba5Entities.TypeOplatis.Add(typrOplat);
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
                    OshibkaTBlock.Text = "Такой тип оплаты уже есть";
                }
                typeOplatiDG.ItemsSource = Laba5Entities.TypeOplatis.ToList();
                TypeOplatiTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if (typeOplatiDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var login in Laba5Entities.Bills)
                {
                    if (login.FK_TypeOplati == (typeOplatiDG.SelectedItem as TypeOplatis).TypeOplati_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.TypeOplatis.Remove(typeOplatiDG.SelectedItem as TypeOplatis);
                    Laba5Entities.SaveChanges();
                }
                typeOplatiDG.ItemsSource = Laba5Entities.TypeOplatis.ToList();
                TypeOplatiTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }
    }
}
