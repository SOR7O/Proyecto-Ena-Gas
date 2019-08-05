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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        BaseDeDatosDataContext dt;
        public Clientes()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
            llenar();

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
        private void llenar()
        {
            var lista = from cl in dt.ClientesEna
                        select cl;
            dtgClientes.ItemsSource = lista;

        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

            using (BaseDeDatosDataContext bdt = new BaseDeDatosDataContext())
            {
                var canti = (from d in dt.Inventario
                             select d).FirstOrDefault();


                var exist = (from s in dt.ClientesEna
                             where s.identidad ==buscarCliente.Text
                             select s).FirstOrDefault();
                IQueryable<ClientesEna> objClientes = from cl in bdt.ClientesEna
                                                      where buscarCliente.Text == cl.identidad
                                                      select cl;
                if (canti.cantidad == 5)
                {
                    MessageBox.Show("Quedan pocos chimbos");
                }
                if (exist != null)
                {
                    List<ClientesEna> lista = objClientes.ToList();
                    dtgClientes.ItemsSource = lista;
                    MessageBox.Show("Cliente encontrado", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                else
                {
                    MessageBox.Show("El cliente no existe");
                }
            }



        }

    }
}
