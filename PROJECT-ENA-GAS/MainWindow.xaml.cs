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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROJECT_ENA_GAS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();
            dataContext = new BaseDataContext();
            dt.ItemsSource = dataContext.Inventario;
            llenarcmbInventario();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inventario iv = new Inventario()
            {
                idCantidad = Convert.ToInt32(txtid.Text),
                cantidad = Convert.ToInt32(txtCantidad.Text)
            };
            var existe = (from tv in dataContext.Inventario
                          where tv.idCantidad == iv.idCantidad
                          select tv).SingleOrDefault();
            if (existe==null)
            {
                dataContext.Inventario.InsertOnSubmit(iv);
                dataContext.SubmitChanges();
            }
            else
            {
                existe.cantidad = iv.cantidad;
                dataContext.SubmitChanges();
            }
            dt.ItemsSource = dataContext.Inventario;
        }
        public void llenarcmbInventario()
        {
            BaseDataContext dataContext = new BaseDataContext();

            var trarDatos = (from q in dataContext.Inventario
                             select new { q.idCantidad}).ToList();
            cmbLista.ItemsSource = trarDatos;
            cmbLista.DisplayMemberPath = "idCantidad";
            cmbLista.SelectedValue = "idCantidad";
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            MenuGerente menuGerente = new MenuGerente();
            menuGerente.Show();
            this.Close();
        }
    }
}

