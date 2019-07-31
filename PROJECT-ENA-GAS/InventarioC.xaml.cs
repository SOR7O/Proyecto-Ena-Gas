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
    /// Lógica de interacción para InventarioC.xaml
    /// </summary>
    public partial class InventarioC : Window
    {
        BaseDeDatosDataContext bdt;
        public InventarioC()
        {
            InitializeComponent();
            bdt = new BaseDeDatosDataContext();
            MostrarInventario();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }
        private void MostrarInventario()
        {
            var mi = (from inv in bdt.Inventario
                      select inv);
            dtgView.DisplayMemberPath = "cantidad";
            dtgView.SelectedItem = "idCantidad";
            dtgView.ItemsSource = mi;
        }
    }
}
