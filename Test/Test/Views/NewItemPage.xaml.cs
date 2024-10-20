using System;
using System.Collections.Generic;
using System.ComponentModel;
using Test.Models;
using Test.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}