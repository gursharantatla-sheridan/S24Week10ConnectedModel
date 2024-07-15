using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace S24Week10ConnectedModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            using (SqlConnection conn = new SqlConnection(Data.ConnectionStr))
            {
                string query = "select EmployeeID, FirstName, LastName, City from Employees";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Load(reader);

                grdEmployees.ItemsSource = tbl.DefaultView;
            }
            //conn.Close();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Data.ConnectionStr))
            {
                // string concatenation - DO NOT USE IT
                string query = "select EmployeeID, FirstName, LastName, City from Employees where FirstName='" + txtFirstname.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Load(reader);

                grdEmployees.ItemsSource = tbl.DefaultView;
            }
        }
    }
}