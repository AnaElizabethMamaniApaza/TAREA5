using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class OrdenEditPage : ContentPage
    {
        private OrdenController _ordenController;
        private Orden _orden;

        public OrdenEditPage(Orden orden = null)
        {
            InitializeComponent();
            _ordenController = new OrdenController();

            // Si la orden es nula, es una nueva orden
            _orden = orden ?? new Orden();
            BindingContext = _orden;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (_orden.Id == 0)
                await _ordenController.AddOrden(_orden);
            else
                await _ordenController.UpdateOrden(_orden);

            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_orden.Id != 0)
            {
                await _ordenController.DeleteOrden(_orden.Id);
            }
            await Navigation.PopAsync();
        }
    }
}
