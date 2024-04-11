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
    /// Логика взаимодействия для AdrasaDostavkiOkno.xaml
    /// </summary>
    public partial class AdrasaDostavkiOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public AdrasaDostavkiOkno()
        {
            InitializeComponent();
            AdresaDG.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
            GorodCbox.ItemsSource = Laba5Entities.Gorods.ToList();
            GorodCbox.DisplayMemberPath = "GorodName";
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

        public bool ContainsBukvi(string input)
        {
            return input.Any(char.IsLetter);
        }

        private void AdresaDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var adres = AdresaDG.SelectedItem as AdresaDostavkis ?? new AdresaDostavkis();
            if (adres.Street != null)
            {
                foreach (var item in Laba5Entities.Gorods)
                {
                    if(item.Gorod_ID == (AdresaDG.SelectedItem as AdresaDostavkis).FK_Gorod)
                    {
                        GorodCbox.SelectedItem = item;
                    }

                }
                StreetTbox.Text = adres.Street.ToString();
                DomTbox.Text = adres.Dom.ToString();
                KvartiraTbox.Text = adres.Kvartira.ToString();
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (DomTbox.Text.Length <= 3 && StreetTbox.Text.Length < 100 && StreetTbox.Text.Length > 5)
            {
                if (AdresaDG.SelectedItem != null)
                {
                    var selected = AdresaDG.SelectedItem as AdresaDostavkis;
                    bool proverka = true;
                    bool proverka2 = true;
                    bool proverka3 = true;
                    bool proverka4 = true;
                    try
                    {
                        Convert.ToInt32(KvartiraTbox.Text);
                        Convert.ToInt32(DomTbox.Text);
                    }
                    catch (Exception)
                    {
                        proverka3 = false;
                        proverka4 = false;
                    }
                    foreach (var item in Laba5Entities.AdresaDostavkis)
                    {
                        if(proverka3 == false && proverka4 == false)
                        {
                            if (item.FK_Gorod == (GorodCbox.SelectedItem as Gorods).Gorod_ID
                               && item.Street == StreetTbox.Text
                               && item.Dom == Convert.ToInt32(DomTbox.Text))
                            {
                                if (item.Kvartira != null && KvartiraTbox.Text != "")
                                {
                                    if (item.Kvartira == Convert.ToInt32(KvartiraTbox.Text))
                                    {
                                        proverka = false;
                                    }
                                }
                                else
                                {
                                    proverka = false;
                                }
                            }
                        }
                        else
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        proverka2 = isLeter(StreetTbox.Text);
                        if (proverka2 == true && proverka3 == false && proverka4 == false)
                        {
                            foreach (var item in Laba5Entities.Gorods) 
                            {
                                if(item == GorodCbox.SelectedItem)
                                {
                                    selected.FK_Gorod = item.Gorod_ID;
                                }
                            }
                            selected.Street = StreetTbox.Text.Trim();
                            selected.Dom = Convert.ToInt32(DomTbox.Text.Trim());
                            if (KvartiraTbox.Text != "")
                            {
                                selected.Kvartira = Convert.ToInt32(KvartiraTbox.Text.Trim());
                            }
                            else
                            {
                                selected.Kvartira = 0;
                            }
                            Laba5Entities.SaveChanges();
                        }
                    }
                    if (proverka == false)
                    {
                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                    }
                    AdresaDG.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
                    DomTbox.Text = null;
                    GorodCbox.SelectedItem = null;
                    KvartiraTbox.Text = null;
                    StreetTbox.Text = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Неверно заполены поля";
                }
            }
            else
            {
                OshibkaTBlock.Text = "Что-то маленькое или большое";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if (DomTbox.Text.Length <= 3 && StreetTbox.Text.Length < 100 && StreetTbox.Text.Length > 5)
            {
                if(GorodCbox.SelectedItem != null)
                {
                    AdresaDostavkis adres = new AdresaDostavkis();
                    bool proverka = true;
                    bool proverka2 = true;
                    bool proverka3 = true;
                    bool proverka4 = true;
                    proverka3 = ContainsBukvi(DomTbox.Text);
                    proverka4 = ContainsBukvi(KvartiraTbox.Text);
                    foreach (var item in Laba5Entities.AdresaDostavkis)
                    {
                        if (proverka3 == false && proverka4 == false)
                        {
                            if (item.FK_Gorod == (GorodCbox.SelectedItem as Gorods).Gorod_ID
                                && item.Street == StreetTbox.Text
                                && item.Dom == Convert.ToInt32(DomTbox.Text))
                            {
                                if(item.Kvartira != null && KvartiraTbox.Text != "")
                                {
                                    if(item.Kvartira == Convert.ToInt32(KvartiraTbox.Text))
                                    {
                                        proverka = false;
                                    }
                                }
                                else
                                {
                                    proverka = false;
                                }
                            }
                        }
                        else
                        {
                            proverka = false;
                        }
                    }
                    if (proverka == true)
                    {
                        proverka2 = isLeter(StreetTbox.Text);
                        if (proverka2 == true && proverka3 == false && proverka4 == false)
                        {
                            foreach (var item in Laba5Entities.Gorods)
                            {
                                if (item == GorodCbox.SelectedItem)
                                {
                                    adres.FK_Gorod = item.Gorod_ID;
                                }
                            }
                            adres.Street = StreetTbox.Text.Trim();
                            adres.Dom = Convert.ToInt32(DomTbox.Text.Trim());
                            if (KvartiraTbox.Text != "")
                            {
                                adres.Kvartira = Convert.ToInt32(KvartiraTbox.Text.Trim());
                            }
                            Laba5Entities.AdresaDostavkis.Add(adres);
                            Laba5Entities.SaveChanges();
                        }
                    }
                    if (proverka == false)
                    {
                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                    }
                    AdresaDG.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
                    DomTbox.Text = null;
                    GorodCbox.SelectedItem = null;
                    KvartiraTbox.Text = null;
                    StreetTbox.Text = null;
                }
                else
                {
                    OshibkaTBlock.Text = "Неверно заполены поля";
                }
            }
            else
            {
                OshibkaTBlock.Text = "Что-то маленькое или большое";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if(AdresaDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var item in Laba5Entities.Clients)
                {
                    if (item.FK_AdresDostavki == (AdresaDG.SelectedItem as AdresaDostavkis).AdresaDostavki_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.AdresaDostavkis.Remove(AdresaDG.SelectedItem as AdresaDostavkis);
                    Laba5Entities.SaveChanges();
                }
                AdresaDG.ItemsSource = Laba5Entities.AdresaDostavkis.ToList();
                DomTbox.Text = null;
                GorodCbox.SelectedItem = null;
                KvartiraTbox.Text = null;
                StreetTbox.Text = null;
            }
        }

        private void GorodOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            GorodOkno gorodOkno = new GorodOkno();
            gorodOkno.ShowDialog();
        }
    }
}
