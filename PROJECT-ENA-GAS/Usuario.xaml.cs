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

namespace PROJECT_ENA_GAS
{
    /// <summary>
    /// Lógica de interacción para Ausuario.xaml
    /// </summary>
    public partial class Ausuario : Window
    {
        BaseDeDatosDataContext dataContext;
        public Ausuario()
        {
            InitializeComponent();
            dataContext = new BaseDeDatosDataContext();
            llenar();

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
            lblUsu.ItemsSource = lista;

        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Usuario aUsu = new Usuario()
            {
                nombreUsuario = txtN.Text,
                contraseña = txtC.Password.ToString(),
                cargo=lblUsu.SelectedValue.ToString()
            };
            var existe = (from us in dataContext.Usuario
                          where us.idUsuario == aUsu.idUsuario
                          select us).SingleOrDefault();
            if (existe == null)
            {
                dataContext.Usuario.InsertOnSubmit(aUsu);
                dataContext.SubmitChanges();
                MessageBox.Show("Usuario almacenado");
            }
            else
            {
                existe.nombreUsuario = aUsu.nombreUsuario;
                existe.contraseña = aUsu.contraseña;
                existe.cargo = aUsu.cargo;
                dataContext.SubmitChanges();
      
            }
            lblUsu.ItemsSource = dataContext.Usuario;

        }
    }
}
