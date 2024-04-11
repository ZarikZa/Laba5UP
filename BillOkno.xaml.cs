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

namespace Laba5
{
    /// <summary>
    /// Логика взаимодействия для BillOkno.xaml
    /// </summary>
    public partial class BillOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public BillOkno()
        {
            InitializeComponent();
            BillDG.ItemsSource = Laba5Entities.Zakazs.ToList();
            UnitazCBox.ItemsSource = Laba5Entities.Unitazs.ToList();
            UnitazCBox.DisplayMemberPath = "UnitazName";
            ZakazCBox.ItemsSource = Laba5Entities.Bills.ToList();
            ZakazCBox.DisplayMemberPath = "Bill_ID";
        }

        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        private void UnitazOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            UnitaziOkno unitaziOkno = new UnitaziOkno();
            unitaziOkno.ShowDialog();
        }

        private void ZakazOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            ZakaziOkno zakaziOkno = new ZakaziOkno();
            zakaziOkno.ShowDialog();
        }

        private void BillDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Bill = BillDG.SelectedItem as Zakazs ?? new Zakazs();
            var bilList = Laba5Entities.Bills.ToList();
            var UnitazList = Laba5Entities.Unitazs.ToList();
            if (Bill.KolvoUnitaz.ToString() != null)
            {
                foreach (var item in bilList)
                {
                    if (item.Bill_ID == Bill.FK_Bill)
                    {
                        ZakazCBox.SelectedItem = item;
                    }
                }
                foreach (var item in UnitazList)
                {
                    if (item.Unitaz_ID == Bill.FK_Unitaz)
                    {
                        UnitazCBox.SelectedItem = item;
                    }
                }
                KolvoUniTBox.Text = Bill.KolvoUnitaz.ToString();
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (KolvoUniTBox.Text != "")
            {
                if (BillDG.SelectedItem != null)
                {

                    var selected = BillDG.SelectedItem as Zakazs;
                    var bilList = Laba5Entities.Bills.ToList();
                    foreach (var item in bilList)
                    {
                        if (item == ZakazCBox.SelectedItem)
                        {
                            selected.FK_Bill = item.Bill_ID;

                        }
                    }
                    var UnitazList = Laba5Entities.Unitazs.ToList();
                    foreach (var item in UnitazList)
                    {
                        if (item == UnitazCBox.SelectedItem)
                        {
                            selected.FK_Unitaz = item.Unitaz_ID;
                        }
                    }
                    try
                    {
                        selected.KolvoUnitaz = Convert.ToInt32(KolvoUniTBox.Text);
                        var billsList = Laba5Entities.Zakazs.ToList();
                        decimal price = 0;
                        bool ura = false;
                        var unitaz = Laba5Entities.Unitazs.ToList();
                        foreach (var bill in billsList)
                        {
                            if (ura == false)
                            {
                                if (bill.FK_Bill == Convert.ToInt32(ZakazCBox.Text))
                                {
                                    var nuzniyBill = billsList.Last(b => b.FK_Bill == Convert.ToInt32(ZakazCBox.Text));
                                    foreach (var unita in unitaz)
                                    {
                                        if (unita.Unitaz_ID == bill.FK_Unitaz)
                                        {
                                            price += unita.UnitazPrice * selected.KolvoUnitaz;
                                            nuzniyBill.PriceBill += price;
                                            ura = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        selected.PriceBill = price;
                        Laba5Entities.SaveChanges();
                        BillDG.ItemsSource = Laba5Entities.Zakazs.ToList();
                        KolvoUniTBox.Text = null;
                        UnitazCBox.SelectedItem = null;
                        ZakazCBox.SelectedItem = null;
                        BillDG.SelectedItem = null;
                    }
                    catch (Exception)
                    {
                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                    }
                }
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            Zakazs Bill = new Zakazs();
            var unitaz = Laba5Entities.Unitazs.ToList();
            foreach (var item in unitaz)
            {
                if (item == UnitazCBox.SelectedItem)
                {
                    Bill.FK_Unitaz = item.Unitaz_ID;
                }
            }
            var zakaz = Laba5Entities.Bills.ToList();
            foreach (var item in zakaz)
            {
                if (item == ZakazCBox.SelectedItem)
                {
                    Bill.FK_Bill = item.Bill_ID;
                }
            }
            try
            {
                Bill.KolvoUnitaz = Convert.ToInt32(KolvoUniTBox.Text);
                var billsList = Laba5Entities.Zakazs.ToList();
                decimal price = 0;
                foreach(var item in unitaz)
                {
                    if(item.Unitaz_ID == Bill.FK_Unitaz)
                    {
                        price = item.UnitazPrice * Bill.KolvoUnitaz;
                    }
                }
                bool ura = false;
                foreach (var bill in billsList)
                {
                    if(ura == false)
                    {
                        if(bill.FK_Bill == Convert.ToInt32(ZakazCBox.Text))
                        {
                            var nuzniyBill = billsList.Last(b => b.FK_Bill == Convert.ToInt32(ZakazCBox.Text));
                            price += nuzniyBill.PriceBill;
                            ura = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Bill.PriceBill = price;
                Laba5Entities.Zakazs.Add(Bill);
                Laba5Entities.SaveChanges();
                BillDG.ItemsSource = Laba5Entities.Zakazs.ToList();
                KolvoUniTBox.Text = null;
                UnitazCBox.SelectedItem = null;
                ZakazCBox.SelectedItem = null;
                BillDG.SelectedItem = null;
            }
            catch (Exception)
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неправильно";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if(BillDG.SelectedItem != null)
            {
                Laba5Entities.Zakazs.Remove(BillDG.SelectedItem as Zakazs);
                Laba5Entities.SaveChanges();
                BillDG.ItemsSource = Laba5Entities.Zakazs.ToList();
                KolvoUniTBox.Text = null;
                UnitazCBox.SelectedItem = null;
                ZakazCBox.SelectedItem = null;
                BillDG.SelectedItem = null;
            }
        }

        private void VigruzkaBtm_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder chek = new StringBuilder();
            var ListZak = Laba5Entities.Zakazs.ToList();
            foreach ( var zak in ListZak )
            {
                chek.AppendLine($"Кассовый чек №{zak.Zakaz_ID}");
                
                foreach (var item2 in Laba5Entities.Unitazs)
                {
                    if (zak.FK_Unitaz == item2.Unitaz_ID)
                    {
                        chek.AppendLine($"{item2.UnitazName} - {item2.UnitazPrice} - {zak.KolvoUnitaz}");
                    }
                }
                chek.AppendLine();
                chek.AppendLine($"Итого к оплате: {zak.PriceBill}");
                if (zak.Bills.TypeOplatis.TypeOplati == "Наличный")
                {
                    chek.AppendLine($"Тип оплаты: Наличный");
                }
                else
                {
                    chek.AppendLine($"Тип оплаты: Безналичный");
                }
                chek.AppendLine();
                File.AppendAllText($"C:\\Users\\MSI-MODERN-14\\OneDrive\\Desktop\\Все_чеки.txt", chek.ToString());
                MessageBox.Show("Чеки выгружены по этому пути 'C:\\Users\\MSI-MODERN-14\\OneDrive\\Desktop\\Все_чеки.txt'");
                chek.Clear();
            }
        }
    }
}
