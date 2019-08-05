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
    /// Lógica de interacción para VentasEmpleado.xaml
    /// </summary>
    public partial class VentasEmpleado : Window
    {
        BaseDeDatosDataContext dt;
        public VentasEmpleado()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
            startClock();
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
            MenuEmpleado menuEmpleado = new MenuEmpleado();
            menuEmpleado.Show();
            this.Close();
        }

        private void BtnVender_Click(object sender, RoutedEventArgs e)
        {

            using (BaseDeDatosDataContext bdt = new BaseDeDatosDataContext())
            {
                IQueryable<TotalVenta> totalVentas = from t in dt.TotalVenta
                                                     orderby t.idTotal descending
                                                     select t;

                IQueryable<ClientesEna> objClientes = from cl in bdt.ClientesEna
                                                      where txtId.Text == cl.identidad
                                                      select cl;

                var canti = (from d in dt.Inventario
                             select d).FirstOrDefault();
                var precio = (from p in dt.Chimbo
                              where p.peso == cmbPeso.Text
                              select p).FirstOrDefault();

                var cantidadMenor = (from cm in dt.Chimbo
                                     where cm.peso == cmbPeso.Text && cm.cantidad == 0
                                     select cm).FirstOrDefault();


                if (canti.cantidad == 0)
                {
                    MessageBox.Show("No existen chimbos en el inventario");

                }
                else
                {
                    if (cantidadMenor == null)
                    {
                        if (precio != null)
                        {
                            {
                                if (canti.cantidad > 0)
                                {

                                    dt.AGREGAR_VENTA(txtId.Text, txtNombre.Text, txtApellido.Text, txtNumero.Text, txtDireccion.Text, cmbPeso.Text, Convert.ToInt32(txtCantidad.Text));
                                    dt.TOTAL_VENTA(Convert.ToInt32(txtCantidad.Text), cmbPeso.Text);
                                    List<ClientesEna> lista = objClientes.ToList(); List<ClientesEna> listax = objClientes.ToList();
                                    dtgClientes.ItemsSource = listax;
                                    MessageBox.Show("Dato almacenado");
                                    if (canti.cantidad == 5)
                                    {
                                        MessageBox.Show("Quedan pocos chimbos");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Lo sentimos no hay chimbos en existencia");
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos no existen chimbos del peso requerido", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    var totalDeVenta = (from t in dt.TotalVenta
                                        orderby t.idTotal descending
                                        select t).FirstOrDefault();

                    lblTotal.Text = totalDeVenta.totalVenta1.ToString();
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
                    MessageBox.Show("Cliente encontrado", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Asterisk);



                }
                else
                {
                    MessageBox.Show("El cliente no existe","Mensaje",MessageBoxButton.OK);
                }
            }

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuEmpleado menuEmpleado = new MenuEmpleado();
            menuEmpleado.Show();
            this.Close();

        }
    }
}
