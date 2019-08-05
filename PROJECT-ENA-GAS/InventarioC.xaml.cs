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
