using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Actividad1_P2_CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuLateral : MasterDetailPage
    {
        public MenuLateral()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());
            App.MasterDet = this;
        }
    }
}