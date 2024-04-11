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
    /// Логика взаимодействия для TypeDostavkiOkno.xaml
    /// </summary>
    public partial class TypeDostavkiOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public TypeDostavkiOkno()
        {
            InitializeComponent();
            typeDostavkiDG.ItemsSource = Laba5Entities.TypeDostavkis.ToList();
        }
        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        public bool isLeter(string input)
        {
            return input.All(c => char.IsLetter(c));
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (TypeDostavTbox.Text.Trim().Length < 20 && TypeDostavTbox.Text.Trim().Length > 4)
            {
                TypeDostavkis typeDostav = new TypeDostavkis();
                bool proverka = true;
                bool proverka2 = true;
                foreach (var item in Laba5Entities.TypeDostavkis)
                {
                    if (item.TypeDostavki == TypeDostavTbox.Text)
                    {
                        proverka = false;
                    }
                }
                if (proverka == true)
                {
                    proverka2 = isLeter(TypeDostavTbox.Text);
                    if (proverka2 == true)
                    {
                        typeDostav.TypeDostavki = TypeDostavTbox.Text.Trim();
                        Laba5Entities.TypeDostavkis.Add(typeDostav);
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
                typeDostavkiDG.ItemsSource = Laba5Entities.TypeDostavkis.ToList();
                TypeDostavTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void typeDostavkiDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var unitazType = typeDostavkiDG.SelectedItem as TypeDostavkis ?? new TypeDostavkis();
            if (unitazType.TypeDostavki != null)
            {
                TypeDostavTbox.Text = unitazType.TypeDostavki.ToString();
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (TypeDostavTbox.Text.Trim().Length < 20 && TypeDostavTbox.Text.Trim().Length > 4)
            {
                if (typeDostavkiDG.SelectedItem != null)
                {
                    var selected = typeDostavkiDG.SelectedItem as TypeDostavkis;
                    bool proverka = true;
                    bool proverka2 = true;
                    foreach (var item in Laba5Entities.TypeDostavkis)
                    {
                        if (item.TypeDostavki == TypeDostavTbox.Text)
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        proverka2 = isLeter(TypeDostavTbox.Text);
                        if (proverka2 == true)
                        {
                            selected.TypeDostavki = TypeDostavTbox.Text.Trim();
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
                    typeDostavkiDG.ItemsSource = Laba5Entities.TypeDostavkis.ToList();
                    TypeDostavTbox.Text = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                }
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if (typeDostavkiDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var login in Laba5Entities.Bills)
                {
                    if (login.FK_TypeDostavki == (typeDostavkiDG.SelectedItem as TypeDostavkis).TypeDostavki_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.TypeDostavkis.Remove(typeDostavkiDG.SelectedItem as TypeDostavkis);
                    Laba5Entities.SaveChanges();
                }
                typeDostavkiDG.ItemsSource = Laba5Entities.TypeDostavkis.ToList();
                TypeDostavTbox.Text = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }
    }
}
