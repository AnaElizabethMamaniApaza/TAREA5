using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class OrdenListPage : ContentPage
    {
        private OrdenController _ordenController;

        public OrdenListPage()
        {
            InitializeComponent();
            _ordenController = new OrdenController();
            LoadOrdenes();
        }

        private async void LoadOrdenes()
        {
            OrdenesListView.ItemsSource = await _ordenController.GetAllOrdenes();
        }

        private async void OnOrdenTapped(object sender, ItemTappedEventArgs e)
        {
            var orden = (Orden)e.Item;
            await Navigation.PushAsync(new OrdenEditPage(orden));
        }

        private async void OnAddOrdenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdenEditPage());
        }
    }
}
