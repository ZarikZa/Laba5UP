using System;
using System.Collections.Generic;
using System.IO;
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
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Laba5
{
    /// <summary>
    /// Логика взаимодействия для PokupkaOkno.xaml
    /// </summary>
    public partial class PokupkaOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        List<Zakazs> zakazAll = new List<Zakazs>();
        List<UnitazKolvo> unitazs = new List<UnitazKolvo>();
        int ClientID = 0;
        Bills bills = new Bills();
        decimal price = 0;

        public PokupkaOkno(int ID)
        {
            InitializeComponent();
            TovariDG.ItemsSource = Laba5Entities.Unitazs.ToList();
            TypeDostavkiCBox.ItemsSource = Laba5Entities.TypeDostavkis.ToList();
            TypeDostavkiCBox.DisplayMemberPath = "TypeDostavki";
            TypeDostavkiCBox.SelectedIndex = 1;
            TypeOplatiCBox.ItemsSource = Laba5Entities.TypeOplatis.ToList();
            TypeOplatiCBox.SelectedIndex = 1;
            TypeOplatiCBox.DisplayMemberPath = "TypeOplati";
            ClientID = ID;
        }

        private void TypeOplatiCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((TypeOplatiCBox.SelectedItem as TypeOplatis).TypeOplati == "Наличный")
            {
                bills.FK_TypeOplati = (TypeOplatiCBox.SelectedItem as TypeOplatis).TypeOplati_ID;
                ColvoDTbox.IsEnabled = true;
            }
            else
            {
                bills.FK_TypeOplati = (TypeOplatiCBox.SelectedItem as TypeOplatis).TypeOplati_ID;
                ColvoDTbox.IsEnabled = false;
            }
        }

        private void DobavBtm_Click(object sender, RoutedEventArgs e)
        {
            if(TovariDG.SelectedItem != null)
            {
                UnitazKolvo zakazUnit = new UnitazKolvo();
                Zakazs zakazs = new Zakazs();
                foreach (var item in Laba5Entities.Clients)
                {
                    if (item.FK_LoginPass == ClientID)
                    {
                        bills.FK_Client = item.Client_ID;

                    }
                }
                bills.FK_TypeDostavki = 1;
                bills.FK_TypeOplati = 1;
                bills.DateBill = DateTime.Now.Date.ToShortDateString();
                Laba5Entities.Bills.Add(bills);
                Laba5Entities.SaveChanges();
                foreach (var entity in Laba5Entities.Bills)
                {
                    if (entity == bills)
                    {
                        zakazs.FK_Bill = entity.Bill_ID;
                    }
                }

                zakazUnit.unit = TovariDG.SelectedItem as Unitazs;
                zakazs.FK_Unitaz = zakazUnit.unit.Unitaz_ID;
                unitazs.Add(zakazUnit);
                if (unitazs.Count != 0)
                {
                    bool found = false;
                    for (int i = 0; i < unitazs.Count; i++)
                    {
                        if (unitazs[i].unit == (TovariDG.SelectedItem as Unitazs))
                        {
                            unitazs[i].kolvo++;
                            if (unitazs[i].kolvo > 1)
                            {
                                unitazs.Remove(unitazs.Last());
                            }
                            found = true; 
                            break; 
                        }
                    }
                    if (!found)
                    {
                        unitazs.Add(zakazUnit); 
                    }
                }
                price += zakazUnit.unit.UnitazPrice;
                zakazs.KolvoUnitaz = zakazUnit.kolvo;
                zakazs.PriceBill = price;
                zakazAll.Add(zakazs);
                PokupkiDG.ItemsSource = null;
                PokupkiDG.ItemsSource = unitazs;
                PriceTblock.Text = price.ToString();
            }
        }

        private void TypeDostavkiCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((TypeDostavkiCBox.SelectedItem as TypeDostavkis).TypeDostavki == "Доставка")
            {
                bills.FK_TypeDostavki = (TypeDostavkiCBox.SelectedItem as TypeDostavkis).TypeDostavki_ID;
            }
            else
            {
                bills.FK_TypeDostavki = (TypeDostavkiCBox.SelectedItem as TypeDostavkis).TypeDostavki_ID;
            }
        }

        private void VihodBtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void UbratBtm_Click(object sender, RoutedEventArgs e)
        {
            if (PokupkiDG.SelectedItem != null)
            {
                if((PokupkiDG.SelectedItem as UnitazKolvo).kolvo > 1)
                {
                    (PokupkiDG.SelectedItem as UnitazKolvo).kolvo--;
                }
                else
                {
                    unitazs.Remove(PokupkiDG.SelectedItem as UnitazKolvo);
                }
                for (int i = 0; i < zakazAll.Count; i++)
                {
                    if (zakazAll[i].FK_Unitaz == (PokupkiDG.SelectedItem as UnitazKolvo).unit.Unitaz_ID)
                    {
                        zakazAll.Remove(zakazAll[i]);
                    }
                }
                price -= (PokupkiDG.SelectedItem as UnitazKolvo).unit.UnitazPrice;
                PokupkiDG.ItemsSource = null;
                PokupkiDG.ItemsSource = unitazs;
                PriceTblock.Text = price.ToString();
            }
        }

        private void KupitBtm_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in zakazAll)
            {
                Laba5Entities.Zakazs.Add(item);
                Laba5Entities.SaveChanges();
            }
            bool proverka1 = false;
            try
            {
                decimal proverka12 = Convert.ToDecimal(ColvoDTbox.Text);
            }
            catch (Exception)
            {
                if ((TypeOplatiCBox.SelectedItem as TypeOplatis).TypeOplati != "Безналичный")
                {
                    proverka1 = true;
                }
                else
                {
                    proverka1 = false;
                }
            }
            if(proverka1 == false)
            {
                bool provrka = false;
                if((TypeOplatiCBox.SelectedItem as TypeOplatis).TypeOplati == "Наличный")
                {
                    if (price <= Convert.ToDecimal(ColvoDTbox.Text))
                    {
                        provrka = true;
                    }
                    else
                    {
                        MessageBox.Show("Внесенная сумма недостаточна для оплаты заказа");
                    }
                }
                else
                {
                    provrka = true;
                }
                if(provrka == true)
                {
                    StringBuilder chek = new StringBuilder();
                    var ListZak = Laba5Entities.Zakazs.ToList();
                    chek.AppendLine($"Магазин унитазов 'Овета'");   
                    chek.AppendLine($"Кассовый чек №{ListZak.Last().Zakaz_ID}");
                    foreach (var item in zakazAll)
                    {
                        foreach (var item2 in Laba5Entities.Unitazs)
                        {
                            if(item.FK_Unitaz == item2.Unitaz_ID)
                            {
                                if(item.KolvoUnitaz != 0)
                                {
                                    chek.AppendLine($"{item2.UnitazName} - {item2.UnitazPrice} - {item.KolvoUnitaz}");
                                }
                                else 
                                {
                                    chek.AppendLine($"{item2.UnitazName} - {item2.UnitazPrice} - {item.KolvoUnitaz + 1}");
                                }
                            }
                        }
                    }
                    chek.AppendLine();
                    chek.AppendLine($"Итого к оплате: {zakazAll.Last().PriceBill}");
                    if((TypeOplatiCBox.SelectedItem as TypeOplatis).TypeOplati == "Наличный")
                    {
                        chek.AppendLine($"Внесено: {ColvoDTbox.Text}");
                        decimal sdacha = Convert.ToInt32(ColvoDTbox.Text) - price;
                        chek.AppendLine($"Сдача: {sdacha}");
                    }
                    else
                    {
                        chek.AppendLine($"Внесено: {zakazAll.Last().PriceBill}");
                        chek.AppendLine($"Сдача: 0");
                    }
                    File.WriteAllText($"C:\\Users\\MSI-MODERN-14\\OneDrive\\Desktop\\текст1.txt", chek.ToString());
                    PokupkiDG.ItemsSource = null;
                    ColvoDTbox.Text = null;
                    price = 0;
                    PriceTblock.Text = null;
                    zakazAll = new List<Zakazs>();
                    unitazs = new List<UnitazKolvo>();
                    bills = new Bills();
                }
            }
            else
            {
                MessageBox.Show("Денежное поле заполнено неверно");
            }
        }
    }
}
