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

        }
  
    }
}
