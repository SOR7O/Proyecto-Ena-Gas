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
    /// Lógica de interacción para VentasEmpleado.xaml
    /// </summary>
    public partial class VentasEmpleado : Window
    {
        BaseDeDatosDataContext dt;
        public VentasEmpleado()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuEmpleado menuEmpleado = new MenuEmpleado();
            menuEmpleado.Show();
            this.Close();
        }

        private void BtnVender_Click(object sender, RoutedEventArgs e)
        {
            var canti = (from d in dt.Inventario
                         select d).FirstOrDefault();

            if (canti.cantidad == 0)
            {
                MessageBox.Show("No existen chimbos en el inventario");


            }
            else
            {
                if (canti.cantidad > 0)
                {
                    dt.AGREGAR_VENTA(txtId.Text, txtNombre.Text, txtApellido.Text, txtNumero.Text, txtDireccion.Text, cmbPeso.Text, Convert.ToInt32(txtCantidad.Text));
                    MessageBox.Show("Dato almacenado");
                    if (canti.cantidad == 5)
                    {
                        MessageBox.Show("Quedan pocos chimbos");
                    }
                }
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string iden = txtId.Text;
            using (BaseDeDatosDataContext bdt = new BaseDeDatosDataContext())
            {
                var canti = (from d in dt.Inventario
                             select d).FirstOrDefault();


                var exist = (from s in dt.ClientesEna
                             where s.identidad == txtId.Text
                             select s).FirstOrDefault();
                IQueryable<ClientesEna> objClientes = from cl in bdt.ClientesEna
                                                      where txtId.Text == cl.identidad
                                                      select cl;
                if (canti.cantidad == 5)
                {
                    MessageBox.Show("Quedan pocos chimbos");
                }
                if (exist != null)
                {
                    List<ClientesEna> lista = objClientes.ToList();
                    var llenarCliente = lista[0];
                    txtNombre.Text = llenarCliente.nombre;
                    txtApellido.Text = llenarCliente.apellido;
                    txtDireccion.Text = llenarCliente.direccion;
                    txtNumero.Text = llenarCliente.telefono;
                    cmbPeso.Text = llenarCliente.pesoC;
                    txtCantidad.Text = llenarCliente.cantidad.ToString();

                    dtgClientes.ItemsSource = lista;
                    MessageBox.Show("Cliente encontrado");



                }
                else
                {
                    MessageBox.Show("El cliente no existe");
                }
            }

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
