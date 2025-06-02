using Netflix.Pages;

namespace Netflix
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CategoriePage), typeof(CategoriePage));
        }
    }
}
