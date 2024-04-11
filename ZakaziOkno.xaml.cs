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
    /// Логика взаимодействия для ZakaziOkno.xaml
    /// </summary>
    public partial class ZakaziOkno : Window
    {
        Laba5Entities Laba5Entities = new Laba5Entities();
        public ZakaziOkno()
        {
            InitializeComponent();
            ZakaziDG.ItemsSource = Laba5Entities.Bills.ToList();
            ClientCBox.ItemsSource = Laba5Entities.Clients.ToList();
            ClientCBox.DisplayMemberPath = "ClientSurname";
            TypeDostavkiCBox.ItemsSource = Laba5Entities.TypeDostavkis.ToList();
            TypeDostavkiCBox.DisplayMemberPath = "TypeDostavki";
            TypeOplatiCBox.ItemsSource = Laba5Entities.TypeOplatis.ToList();
            TypeOplatiCBox.DisplayMemberPath = "TypeOplati";
            DateDPick.DisplayDateStart = DateTime.Now;
            DateDPick.DisplayDateEnd = DateTime.Now.AddDays(10);
        }
        private void BackBtm_Click(object sender, RoutedEventArgs e)
        {
            AdminOkno adminOkno = new AdminOkno();
            adminOkno.Show();
            Close();
        }

        private void ClientOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            ClientsOkno clientsOkno = new ClientsOkno();
            clientsOkno.BackBtm.IsEnabled = false;
            clientsOkno.ShowDialog();
        }

        private void TypeOplatiOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            TypeOplatiOkno typeOplatiOkno = new TypeOplatiOkno();
            typeOplatiOkno.BackBtm.IsEnabled = false;
            typeOplatiOkno.ShowDialog();
        }

        private void TypeDostavkiOknoBtm_Click(object sender, RoutedEventArgs e)
        {
            TypeDostavkiOkno typeDostavkiOkno = new TypeDostavkiOkno();
            typeDostavkiOkno.BackBtm.IsEnabled = false;
            typeDostavkiOkno.ShowDialog();
        }

        private void ZakaziDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Zakaz = ZakaziDG.SelectedItem as Bills ?? new Bills();
            var ClientList = Laba5Entities.Clients.ToList();
            var TypeOplatiList = Laba5Entities.TypeOplatis.ToList();
            var TypeDostavkiList = Laba5Entities.TypeDostavkis.ToList();
            if (Zakaz.DateBill != null)
            {
                foreach (var item in ClientList)
                {
                    if (item.Client_ID == Zakaz.FK_Client)
                    {
                        ClientCBox.SelectedItem = item;
                    }
                }
                foreach (var item in TypeOplatiList)
                {
                    if (item.TypeOplati_ID == Zakaz.FK_TypeOplati)
                    {
                        TypeOplatiCBox.SelectedItem = item;
                    }
                }
                foreach (var item in TypeDostavkiList)
                {
                    if (item.TypeDostavki_ID == Zakaz.FK_TypeDostavki)
                    {
                        TypeDostavkiCBox.SelectedItem = item;
                    }
                }
                DateDPick.SelectedDate = null;
                DateDPick.Text = Zakaz.DateBill;
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            if (DateDPick.Text != "")
            {
                if (ZakaziDG.SelectedItem != null)
                {
                    var selected = ZakaziDG.SelectedItem as Bills;
                    var ClientList = Laba5Entities.Clients.ToList();
                    foreach (var item in ClientList)
                    {
                        if (item == ClientCBox.SelectedItem)
                        {
                            selected.FK_Client = item.Client_ID;
                        }
                    }
                    var TypeOplatiList = Laba5Entities.TypeOplatis.ToList();
                    foreach (var item in TypeOplatiList)
                    {
                        if (item == TypeOplatiCBox.SelectedItem)
                        {
                            selected.FK_TypeOplati = item.TypeOplati_ID;
                        }
                    }
                    var TypeDostavkiList = Laba5Entities.TypeDostavkis.ToList();
                    foreach (var item in TypeDostavkiList)
                    {
                        if (item == TypeDostavkiCBox.SelectedItem)
                        {
                            selected.FK_TypeDostavki = item.TypeDostavki_ID;
                        }
                    }
                    try
                    {
                        var proverka = Convert.ToDateTime(DateDPick.Text.Trim());
                        selected.DateBill = DateDPick.Text;
                        Laba5Entities.SaveChanges();
                    }
                    catch (Exception)
                    {
                        OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
                    }
                    ZakaziDG.ItemsSource = Laba5Entities.Bills.ToList();
                    DateDPick.Text = null;
                    ClientCBox.SelectedItem = null;
                    TypeDostavkiCBox.SelectedItem = null;
                    TypeOplatiCBox.SelectedItem = null;
                    ZakaziDG.SelectedItem = null;
                    DateDPick.SelectedDate = null;
                }
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            if(DateDPick.Text != "")
            {
                Bills zakaz = new Bills();
                var client = Laba5Entities.Clients.ToList();
                foreach (var item in client)
                {
                    if (item == ClientCBox.SelectedItem)
                    {
                        zakaz.FK_Client = item.Client_ID;
                    }
                }
                var typeDostav = Laba5Entities.TypeDostavkis.ToList();
                foreach (var item in typeDostav)
                {
                    if (item == TypeDostavkiCBox.SelectedItem)
                    {
                        zakaz.FK_TypeDostavki = item.TypeDostavki_ID;
                    }
                }
                var typeOplati = Laba5Entities.TypeOplatis.ToList();
                foreach (var item in typeOplati)
                {
                    if (item == TypeOplatiCBox.SelectedItem)
                    {
                        zakaz.FK_TypeOplati = item.TypeOplati_ID;
                    }
                }
                try
                {
                    var proverka = Convert.ToDateTime(DateDPick.Text.Trim());
                    zakaz.DateBill = DateDPick.Text.Trim();
                    Laba5Entities.Bills.Add(zakaz);
                    Laba5Entities.SaveChanges();
                }
                catch (Exception)
                {
                    OshibkaTBlock.Text = "Некоторые поля заполнены неправильно";
                }
                ZakaziDG.ItemsSource = Laba5Entities.Bills.ToList();
                DateDPick.Text = null;
                ClientCBox.SelectedItem = null;
                TypeDostavkiCBox.SelectedItem = null;
                TypeOplatiCBox.SelectedItem = null;
                ZakaziDG.SelectedItem = null;
                DateDPick.SelectedDate = null;
            }
            else
            {
                OshibkaTBlock.Text = "Некоторые поля заполнены неверно";
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            if(ZakaziDG.SelectedItem != null)
            {
                bool proverka = true;
                foreach (var item in Laba5Entities.Zakazs)
                {
                    if (item.FK_Bill == (ZakaziDG.SelectedItem as Bills).Bill_ID)
                    {
                        OshibkaTBlock.Text = "Нельзя удалить, используется в связях";
                        proverka = false;
                    }
                }
                if (proverka != false)
                {
                    Laba5Entities.Bills.Remove(ZakaziDG.SelectedItem as Bills);
                    Laba5Entities.SaveChanges();
                }
                ZakaziDG.ItemsSource = Laba5Entities.Bills.ToList();
                DateDPick.Text = null;
                ClientCBox.SelectedItem = null;
                TypeDostavkiCBox.SelectedItem = null;
                TypeOplatiCBox.SelectedItem = null;
                ZakaziDG.SelectedItem = null;
                DateDPick.SelectedDate = null;
            }
            else
            {
                OshibkaTBlock.Text = "Поле не выбрано";
            }
        }
    }
}
