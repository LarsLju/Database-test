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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace Database_test
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


        private void button_Click(object sender, RoutedEventArgs e)
        {

            // Data streng
            SqlConnection myConnection = new SqlConnection(@"Data Source = CV-BB-4750\SQLEXPRESS; Initial Catalog = Test; Integrated Security = True");


            // åben forbindelsen
            try
            {
                myConnection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Fejl i åbning af databasen");
            }

            // Afvikle en SQL kommando og hent resultatet ind i SqlDataReader myReader, der er et array
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT TOP 1 M.MedlemId " +
                                                      ", M.Fornavn, M.Efternavn, M.Telefon, M.Email, M.Postnr, PB.byen " +
                                                      "FROM Medlemmer M " +
                                                      "INNER JOIN Postnummer_by PB " +
                                                      "ON M.Postnr = PB.postnr", myConnection);
                myReader = myCommand.ExecuteReader();
                
                // loop myReader igennem indtil at du har alle enheder placeret
                while (myReader.Read())
                {
                    textBox.Text = myReader["Fornavn"].ToString();
                    textBox1.Text = myReader["Efternavn"].ToString();
                    textBox2.Text = myReader["Postnr"].ToString();
                    textBox3.Text = myReader["byen"].ToString();
                    textBox4.Text = myReader["Telefon"].ToString();
                    textBox5.Text = myReader["Email"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Fejl");
            }

            /// luk forbindelsen
            /// 

            try
            {
                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("Forbindelsen blev ikke lukket");
            }

         }
    }
 }
