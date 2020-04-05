using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ateliex.Cadastro.Modelos
{
    public partial class ModelosPage : Page
    {
        public ModelosResource Resource { get; }

        public ModelosPage(ModelosResource resource)
        {
            InitializeComponent();

            Resource = resource;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mainListView.ItemsSource = Resource;
        }

        private void detalhesButton_Click(object sender, RoutedEventArgs e)
        {
            var detalhesButton = sender as Button;

            var resource = detalhesButton.DataContext as ModeloResource;

            var detalhesDeModelo = resource.GetDetalhesDeModelo();

            NavigationService.Navigate(new ModeloPage(detalhesDeModelo));
        }
    }
}
