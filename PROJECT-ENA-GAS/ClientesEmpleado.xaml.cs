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
    /// Lógica de interacción para ClientesEmpleado.xaml
    /// </summary>
    public partial class ClientesEmpleado : Window
    {
        BaseDeDatosDataContext dt = new BaseDeDatosDataContext();
        public ClientesEmpleado()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
        }
        private void llenar()
        {
            var lista = from cl in dt.ClientesEna
                        select cl;
            dtgClientes.ItemsSource = lista;

        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MenuEmpleado menuEmpleado = new MenuEmpleado();
            menuEmpleado.Show();
            this.Close();

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            using (BaseDeDatosDataContext bdt = new BaseDeDatosDataContext())
            {
                var exist = (from s in dt.ClientesEna
                             where s.identidad == txtbuscarCliente.Text
                             select s).FirstOrDefault();
                IQueryable<ClientesEna> objClientes = from cl in bdt.ClientesEna
                                                      where txtbuscarCliente.Text == cl.identidad
                                                      select cl;
                if (exist != null)
                {
                    List<ClientesEna> lista = objClientes.ToList();
                    var llenarCliente = lista[0];
                    dtgClientes.ItemsSource = lista;
                    MessageBox.Show("Cliente encontrado");
                }

            }
        }
    }
}

