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
    /// Lógica de interacción para MenuGerente.xaml
    /// </summary>
    public partial class MenuGerente : Window
    {
        public MenuGerente()
        {
            InitializeComponent();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItemCliente(object sender, RoutedEventArgs e)
        {
            //llama a la ventana de cliente
            Clientes clientes = new Clientes();
            clientes.Show();
            this.Close();
        }

      

        private void ListViewItemVentas(object sender, RoutedEventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.Show();
            this.Close();
        }

       

        private void ListViewItemInventario(object sender, RoutedEventArgs e)
        {
            InventarioC inventarioC = new InventarioC();
             inventarioC.Show();
            this.Close();
        }

      

        private void ListViewItemEstadisticas(object sender, RoutedEventArgs e)
        {
           
        }

      

        private void ListViewItemReporte(object sender, RoutedEventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
            this.Close();
        }

      

        private void ListViewItemAñadirPersona(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona();
            persona.Show();
            this.Close();
        }

        private void ListViewItemAñadirUsuario(object sender, RoutedEventArgs e)
        {
            Ausuario ausuario = new Ausuario();
            ausuario.Show();
            this.Close();
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow regresar = new MainWindow();
            regresar.Show();
            this.Close();
        }
    }
}
