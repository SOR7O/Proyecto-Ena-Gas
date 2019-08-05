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
using System.ComponentModel;
using System.Data;

namespace PROJECT_ENA_GAS
{
    /// <summary>
    /// Lógica de interacción para Reporte.xaml
    /// </summary>
    public partial class Reporte : Window
    {
        BaseDeDatosDataContext dt;
        public Reporte()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
            llenar();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }

        
        private void llenar()
        {
            var lista = from cl in dt.TotalVenta
                        select cl;
            dtgReporte.ItemsSource = lista;

        }

        private void BtnRegresa_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();

        }

        
    }
}
