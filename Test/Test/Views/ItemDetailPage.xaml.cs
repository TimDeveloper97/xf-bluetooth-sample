using System.ComponentModel;
using Test.ViewModels;
using Xamarin.Forms;

namespace Test.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}