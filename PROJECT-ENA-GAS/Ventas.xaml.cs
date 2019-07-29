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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        BaseDeDatosDataContext dt;
        public Ventas()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
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
            var ch = (from x in dt.Chimbo
                      select new { x.peso }).ToList();
            cmbPeso.DisplayMemberPath = "peso";
            cmbPeso.SelectedItem = "idChimbo";
            cmbPeso.ItemsSource = ch;
        }

        private void BtnVender_Click(object sender, RoutedEventArgs e)
        {
            ClientesEna cli = new ClientesEna()
            {
                identidad =txtId.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                direccion = txtDireccion.Text,
                telefono = txtNumero.Text,
                peso = cmbPeso.SelectedValue.ToString()
            };
            var existe = (from xi in dt.ClientesEna
                          where xi.idCliente == cli.idCliente
                          select xi).SingleOrDefault();
            if (existe==null)
            {
                dt.ClientesEna.InsertOnSubmit(cli);
                dt.SubmitChanges();
                MessageBox.Show("Venta realizada");
            }
            else
            {
                existe.identidad = cli.identidad;
                existe.nombre = cli.nombre;
                existe.apellido = cli.apellido;
                existe.telefono = cli.telefono;
                existe.direccion = cli.direccion;
                existe.peso = cli.peso;
                dt.SubmitChanges();
            }
            cmbPeso.ItemsSource = dt.ClientesEna;

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }
    }
}
