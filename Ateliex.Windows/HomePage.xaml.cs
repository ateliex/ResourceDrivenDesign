using Ateliex.Cadastro.Modelos;
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

namespace Ateliex
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomeResource Resource { get; set; }

        public HomePage()
        {
            InitializeComponent();

            Resource = new HomeResource();
        }

        private void getModelosButton_Click(object sender, RoutedEventArgs e)
        {
            var resource = Resource.GetCadastro().GetModelos();

            NavigationService.Navigate(new ModelosPage(resource));
        }
    }
}
