using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class ProveedorEditPage : ContentPage
    {
        private ProveedorController _controller;
        private Proveedor _proveedor;

        public ProveedorEditPage(Proveedor proveedor = null)
        {
            InitializeComponent();
            _controller = new ProveedorController();

            if (proveedor != null)
            {
                _proveedor = proveedor;
                NombreEntry.Text = proveedor.Nombre;
                TelefonoEntry.Text = proveedor.Telefono; // Asumiendo que tienes una propiedad Telefono
            }
            else
            {
                _proveedor = new Proveedor(); // Nuevo proveedor
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _proveedor.Nombre = NombreEntry.Text;
            _proveedor.Telefono = TelefonoEntry.Text; // Asumiendo que tienes una propiedad Telefono

            if (_proveedor.Id != 0)
            {
                await _controller.UpdateProveedor(_proveedor);
            }
            else
            {
                await _controller.AddProveedor(_proveedor);
            }

            await Navigation.PopAsync(); // Regresa a la lista de proveedores
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_proveedor.Id != 0)
            {
                await _controller.DeleteProveedor(_proveedor.Id);
                await Navigation.PopAsync(); // Regresa a la lista de proveedores
            }
        }
    }
}
