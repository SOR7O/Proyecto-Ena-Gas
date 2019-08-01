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

namespace PROJECT_ENA_GAS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseDeDatosDataContext dt;
        public MainWindow()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
            LlenarU();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
   
        }
        private void LlenarU()
        {
            BaseDeDatosDataContext dt = new BaseDeDatosDataContext();
            var lista = (from x in dt.Cargo
                         select new { x.cargoUsuario }).ToList();
            lblUsu.DisplayMemberPath = "cargoUsuario";
            lblUsu.SelectedItem = "cargoUsuario";
            lblUsu.ItemsSource = lista;

        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            var existeNombre = (from usuario in dt.Usuario
                                where usuario.nombreUsuario == txtNombre.Text && usuario.contraseña == txtContraLogin.Text && usuario.cargo==lblUsu.SelectedValue.ToString()
                                select usuario).FirstOrDefault();


            if (txtNombre.Text == string.Empty || txtContraLogin.Text == string.Empty)
            {
                MessageBox.Show("No debe dejar ningun campo vacio");
            }
            else
            {

                if (existeNombre != null && lblUsu.SelectedValue.ToString()== "{ cargoUsuario = Administrador }")
                {
                    MenuGerente menuGerente = new MenuGerente();
                    menuGerente.Show();
                    this.Close();
                }
               else if (existeNombre != null && lblUsu.SelectedValue.ToString() == "{ cargoUsuario = Empleado }")
                {
                    MenuEmpleado menuEmpleado = new MenuEmpleado();
                    menuEmpleado.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario no existe o contraseña incorrecta o nivel de usuario invalido ");
                }
                
            }

        }




    }
        }


    

