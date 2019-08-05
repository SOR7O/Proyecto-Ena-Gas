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
using System.Windows.Threading;


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
            //Llenamos el combobos lblUsu, mandamos a llamar los tipos de usuarios que existen
            BaseDeDatosDataContext dt = new BaseDeDatosDataContext();
            var lista = (from x in dt.Cargo
                         select new { x.cargoUsuario }).ToList();
            lblUsu.DisplayMemberPath = "cargoUsuario";
            lblUsu.SelectedItem = "cargoUsuario";
            lblUsu.SelectedIndex = 0;//Le asignamos el primer valor de la base de datos
            lblUsu.ItemsSource = lista;

        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            //Definimos la variable existeNombre y le mandamos los valores que ingramos y los compara con la base de datos y si existen el usuario puede ingresar
            var existeNombre = (from usuario in dt.Usuario
                                where usuario.nombreUsuario == txtNombre.Text && usuario.contraseña == txtContraLogin.Password.ToString() && usuario.cargo==lblUsu.SelectedValue.ToString()
                                select usuario).FirstOrDefault();

            //condicion que si el usuario deja un campo vacio se lo recordamos mediante un mensaje
            if (txtNombre.Text == string.Empty || txtContraLogin.Password == string.Empty)
            {
                MessageBox.Show("No debe dejar ningun campo vacio","Mensaje",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                //Aqui compara si el usuario existe pero si el cargo es igual al seleccion mostrara la ventana que le corresponde
                if (existeNombre != null && lblUsu.SelectedValue.ToString()== "{ cargoUsuario = Administrador }")
                {
                    MenuGerente menuGerente = new MenuGerente();
                    menuGerente.Show();
                    this.Close();
                }
                //Aqui compara si el usuario existe pero si el cargo es igual al seleccion mostrara la ventana que le corresponde
                else if (existeNombre != null && lblUsu.SelectedValue.ToString() == "{ cargoUsuario = Empleado }")
                {
                    MenuEmpleado menuEmpleado = new MenuEmpleado();
                    menuEmpleado.Show();
                    this.Close();
                }
                //Y si el usuario no existe o ah ingresado algun dato malo se lo decimos mediante un mensaje
                else
                {
                    MessageBox.Show("El usuario no existe o contraseña incorrecta o nivel de usuario invalido ","Mensaje",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                
            }

        }




    }
        }


    

