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
    /// Lógica de interacción para Persona.xaml
    /// </summary>
    public partial class Persona : Window
    {
        
        BaseDeDatosDataContext dt;
        public Persona()
        {
            InitializeComponent();
            dt = new BaseDeDatosDataContext();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtCantidad.Text==string.Empty || txtPeso.Text==string.Empty || txtPRecio.Text == string.Empty) { 
            MessageBox.Show("No debe dejar ningun campo vacio");
            }
            dt.AGREGAR_CHIMBO(Convert.ToInt32(txtCantidad.Text), Convert.ToDecimal(txtPRecio.Text), txtPeso.Text);
            MessageBox.Show("Datos almacenados");

        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente regresar = new MenuGerente();
            regresar.Show();
            this.Close();
        }
    }
}
