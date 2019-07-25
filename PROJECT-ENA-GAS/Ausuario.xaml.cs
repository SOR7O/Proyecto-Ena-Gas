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
    /// Lógica de interacción para Ausuario.xaml
    /// </summary>
    public partial class Ausuario : Window
    {
        BaseDataContext dataContext;
        public Ausuario()
        {
            InitializeComponent();
            dataContext = new BaseDataContext();
            dtU.ItemsSource = dataContext.Usuario;
            LlenarCmb();
        }


        private void BtnA_Click(object sender, RoutedEventArgs e)
        {
            Usuario us = new Usuario()
            {
                nombreUsuario = txtNombre.Text,
                contraseña = txtContra.Password,
                cargo = cmbDatos.SelectedValue.ToString()
            };
            var existe = (from tu in dataContext.Usuario
                          where tu.idUsuario == us.idUsuario
                          select tu).SingleOrDefault();

            if (existe == null)
            {
                dataContext.Usuario.InsertOnSubmit(us);
                dataContext.SubmitChanges();
            }
            else
            {
                existe.nombreUsuario = us.nombreUsuario;
                existe.contraseña = us.contraseña;
                existe.cargo = us.cargo;
                dataContext.SubmitChanges();
            }
            dtU.ItemsSource = dataContext.Usuario;

        }
        private void LlenarCmb()
        {
            BaseDataContext dataContext = new BaseDataContext();

            var trarDatos = (from q in dataContext.Cargo
                             select new { q.cargoUsu} ).ToList();
            cmbDatos.ItemsSource = trarDatos;
           cmbDatos.DisplayMemberPath = "cargoUsu";
            cmbDatos.SelectedValue = "idCargo";
        }

        private void BtnRegresarMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
