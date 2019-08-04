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
            MostrarIngresos();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }

        private void BtnRegresar_Click_1(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }
        public static List<object> GenerarGrafico()
            {
                BaseDeDatosDataContext bdt = new BaseDeDatosDataContext();
            var query = bdt.Chimbo.
                     Select(ci => new
                     {
                         Chimbo = ci.cantidad,
                         Cantidad = ObtenerValores(ci.cantidad)
                     }).ToList<object>() ;
            return query;
            } 
        public static int ObtenerValores(int cantidad)
        {
            int can=0;
            BaseDeDatosDataContext dt = new BaseDeDatosDataContext();
            var query = dt.Chimbo.Where(pc => pc.idChimbo == cantidad).Select(pc => pc);
            if (query.Count()>0)
            can = query.Count();
            return can;
        }


        private void MostrarIngresos()
        {    
                var lista = from cl in dt.Chimbo
                            select cl;
                dtgReporte.ItemsSource = lista;
        }

    }
}
