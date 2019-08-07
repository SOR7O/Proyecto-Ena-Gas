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
using System.Windows.Threading;

namespace PROJECT_ENA_GAS
{
    /// <summary>
    /// Lógica de interacción para Ausuario.xaml
    /// </summary>
    public partial class Ausuario : Window
    {
        BaseDeDatosDataContext dataContext;
        EncriptarClass1 clave;
        public Ausuario()
        {
            InitializeComponent();
            dataContext = new BaseDeDatosDataContext();
            llenar();
            startClock();
            clave = new EncriptarClass1();
        }
        private void startClock()
        {
            DispatcherTimer hora = new DispatcherTimer();
            hora.Tick += tickEvent;
            hora.Start();

        }

        private void tickEvent(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }
        private void llenar()
        {
            BaseDeDatosDataContext dt = new BaseDeDatosDataContext();
            var lista = (from x in dt.Cargo
                         select new {x.cargoUsuario}).ToList();
            lblUsu.DisplayMemberPath = "cargoUsuario";
            lblUsu.SelectedItem = "cargoUsuario";
           lblUsu.SelectedIndex = 0;
            lblUsu.ItemsSource = lista;

        }
 

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Usuario aUsu = new Usuario()
            {
                nombreUsuario = txtN.Text,
                contraseña =clave.EcryptKey(txtC.Password.ToString()),
                cargo = lblUsu.SelectedValue.ToString()
            };
            var existe = (from us in dataContext.Usuario
                          where us.idUsuario == aUsu.idUsuario
                          select us).SingleOrDefault();

            NewMethod(aUsu, existe);

        }

        private void NewMethod(Usuario aUsu, Usuario existe)
        {
            if (txtN.Text == string.Empty || txtC.Password == string.Empty || lblUsu.SelectedIndex==-1 || txtCc.Password == string.Empty)
            {
                MessageBox.Show("No debes dejar ningun campo vacio");
            }
            else
            {
                if (txtC.Password == txtCc.Password)
                {
                    if (existe == null)
                    {
                        dataContext.Usuario.InsertOnSubmit(aUsu);
                        dataContext.SubmitChanges();
                        MessageBox.Show("Usuario almacenado");
                    }
                    else
                    {
                        existe.nombreUsuario = aUsu.nombreUsuario;
                        existe.contraseña = clave.EcryptKey(aUsu.contraseña);
                        existe.cargo = aUsu.cargo;
                        dataContext.SubmitChanges();

                    }
                    lblUsu.ItemsSource = dataContext.Usuario;
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            Usuario aUsu = new Usuario()
            {
                nombreUsuario = txtN.Text,
                contraseña = clave.EcryptKey(txtC.Password.ToString()),
                cargo = lblUsu.SelectedValue.ToString()
            };

            
            var existe = (from us in dataContext.Usuario
                          where us.nombreUsuario==txtN.Text && us.contraseña== txtCAntigua.Password
                          select us).SingleOrDefault();
            if (txtN.Text == string.Empty || txtC.Password == string.Empty || lblUsu.SelectedIndex == -1 || txtCc.Password == string.Empty)
            {
                MessageBox.Show("No debes dejar ningun campo vacio");
            }
            else
            {
                if (txtC.Password == txtCc.Password)
                {
                    if (existe == null)
                    {
                        MessageBox.Show("El usuario no existe o tiene un campo incorrecto");
                    }
                    else
                    {
                        existe.nombreUsuario = aUsu.nombreUsuario;
                        existe.contraseña = clave.EcryptKey(aUsu.contraseña);
                        existe.cargo = aUsu.cargo;
                        dataContext.SubmitChanges();
                        MessageBox.Show("Usuario modificado","Mensaje",MessageBoxButton.OK,MessageBoxImage.None);
                        lblUsu.ItemsSource = dataContext.Usuario;
                    }
                    lblUsu.ItemsSource = dataContext.Usuario;
                }
                                    
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }

        }
    }
}
