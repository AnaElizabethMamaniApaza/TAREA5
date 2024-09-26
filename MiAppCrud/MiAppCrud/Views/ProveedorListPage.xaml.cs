using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class ProveedorListPage : ContentPage
    {
        private ProveedorController _controller;

        public ProveedorListPage()
        {
            InitializeComponent();
            _controller = new ProveedorController();
            LoadProveedores();
        }

        private async void LoadProveedores()
        {
            ProveedoresListView.ItemsSource = await _controller.GetAllProveedores();
        }

        private async void OnAddProveedorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProveedorEditPage());
        }

        private async void OnProveedorTapped(object sender, ItemTappedEventArgs e)
        {
            var proveedor = (Proveedor)e.Item;
            await Navigation.PushAsync(new ProveedorEditPage(proveedor));
        }
    }
}
