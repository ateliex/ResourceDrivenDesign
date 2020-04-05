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
    public partial class ModeloPage : Page
    {
        public DetalhesDeModeloResource Resource { get; }

        public ModeloPage(DetalhesDeModeloResource resource)
        {
            InitializeComponent();

            Resource = resource;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            nomeTextBlock.Text = Resource.Nome;
        }

        private void detalhesButton_Click(object sender, RoutedEventArgs e)
        {
            var x = Resource.GetDetalhesDeModelo();
        }
    }
}
