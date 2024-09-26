using MiAppCrud.Views;

namespace MiAppCrud
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProductoEditPage), typeof(ProductoEditPage));
            Routing.RegisterRoute(nameof(ProductoListPage), typeof(ProductoListPage));
        }
    }
}
