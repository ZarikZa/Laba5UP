using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для AdminOkno.xaml
    /// </summary>
    public partial class AdminOkno : Window
    {
        public AdminOkno()
        {
            InitializeComponent();
            List<string> Tables = new List<string>()
            {
                "Тип унитаза",
                "Страна производства",
                "Унитазы",
                "Заказы",
                "Адреса доставки",
                "Клиенты",
                "ФИО Сотрудников",
                "Должности",
                "Сотрудники",
                "Тип оплаты",
                "Тип доставки",
                "Чеки",
                "Логины и пароли",
                "Города"
            };
            TablisiLB.ItemsSource = Tables;
        }

        private void ExitBtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void TablisiLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TablisiLB.SelectedItem.ToString() == "Тип унитаза")
            {
                UnitazTypeOkno unitazTypeOkno = new UnitazTypeOkno();
                unitazTypeOkno.Show();
                Close();
            }
            else if(TablisiLB.SelectedItem.ToString() == "Страна производства")
            {
                CountryProizvodstvaOkno countryProizvodstvaOkno = new CountryProizvodstvaOkno();
                countryProizvodstvaOkno.Show();
                Close();
            }
            else if(TablisiLB.SelectedItem.ToString() == "Унитазы")
            {
                UnitaziOkno unitaziOkno = new UnitaziOkno();
                unitaziOkno.Show();
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Заказы")
            {
                ZakaziOkno zakaziOkno = new ZakaziOkno();
                zakaziOkno.Show();
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Адреса доставки")
            {
                AdrasaDostavkiOkno adrasaDostavkiOkno = new AdrasaDostavkiOkno();
                adrasaDostavkiOkno.Show();
                Close();
            }
            else if(TablisiLB.SelectedItem.ToString() == "Клиенты")
            {
                ClientsOkno clientsOkno = new ClientsOkno();
                clientsOkno.Show(); 
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "ФИО Сотрудников")
            {
                SNMSotrudnicaOkno sNMSotrudnicaOkno = new SNMSotrudnicaOkno();
                sNMSotrudnicaOkno.Show();
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Должности")
            {
                DolznostiOkno dolznostiOkno = new DolznostiOkno();
                dolznostiOkno.Show();
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Сотрудники")
            {
                SotrudnickOkno sotrudnickOkno = new SotrudnickOkno();
                sotrudnickOkno.Show();
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Тип оплаты")
            {
                TypeOplatiOkno typeOplatiOkno = new TypeOplatiOkno();
                typeOplatiOkno.Show();
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Тип доставки")
            {
                TypeDostavkiOkno typeDostavkiOkno = new TypeDostavkiOkno();
                typeDostavkiOkno.Show();
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Чеки")
            {
                BillOkno billOkno = new BillOkno();
                billOkno.Show(); 
                Close();
            }
            else if (TablisiLB.SelectedItem.ToString() == "Логины и пароли")
            {
                LoginPassOkno loginPassOkno = new LoginPassOkno();
                loginPassOkno.Show(); 
                Close();
            }
            else if(TablisiLB.SelectedItem.ToString() == "Города")
            {
                GorodOkno gorodOkno = new GorodOkno();
                gorodOkno.Show(); 
                Close();
            }
        }

        private void MakeBackupBtm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=DESKTOP-H0SNFQR\SQLEXPRESS;Initial Catalog=Laba5;" +
                "Integrated Security=SSPI;Pooling=False";

                sqlConnection.Open();

                string backupQuery = $@"BACKUP DATABASE Laba5 TO DISK = 'C:\\Users\\Public\\Documents\\MS\\Laba5.bak'";

                using (var command = new SqlCommand(backupQuery, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
                MessageBox.Show("Бэкап сделан по этому пути 'C:\\Users\\Public\\Documents\\MS\\Laba5.bak'");
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось сделать бэкап");
            }
        }
    }
}