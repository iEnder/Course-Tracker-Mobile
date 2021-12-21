using C971_CourseTracker.Views;
using Xamarin.Forms;

namespace C971_CourseTracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("terms", typeof(TermPage));
        }
    }
}
