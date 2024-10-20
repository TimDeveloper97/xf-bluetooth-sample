using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Test.Resx;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Views
{
    class MyBoxView : BoxView
    {
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        static int index = -1;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this;
            //string language = Thread.CurrentThread.CurrentUICulture.Name;
            //picker.SelectedIndex = language == "vi" ? 2 : language == "en" ? 1 : 0;
            genGrid();
            showAnimation();
        }

        Color tmp;

        public Color Tmp { get => tmp; set { tmp = value; OnPropertyChanged(); } }

        //private void picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (index == picker.SelectedIndex)
        //        return;
        //    index = picker.SelectedIndex;
        //    CultureInfo language = new CultureInfo(picker.SelectedIndex == 0 ? "" : picker.SelectedIndex == 1 ? "en" : "vi");
        //    Thread.CurrentThread.CurrentUICulture = language;
        //    AppResource.Culture = language;
        //    Application.Current.MainPage = new AppShell();
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void genGrid()
        {
            gContent.RowDefinitions = new RowDefinitionCollection();
            gContent.ColumnDefinitions = new ColumnDefinitionCollection();
            for (int i = 0; i < 49; i++)
            {
                gContent.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            }

            for (int i = 0; i < 4; i++)
            {
                gContent.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            }

            //title
            var ltitle = new List<string> { "Time", "DISARM", "ARM0", "ARM1" };
            for (int j = 0; j < 4; j++)
            {
                gContent.Children.Add(new Label
                {
                    BackgroundColor = Color.Blue,
                    TextColor = Color.White,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Text = ltitle[j],
                    Padding = 0,
                    Margin = 0,
                }, j, 0);


            }

            bool half = false;
            int hour = 0;
            //time
            for (int i = 1; i < 49; i++)
            {
                var m = half == false ? "00" : "30";
                var h = hour < 10 ? "0" + hour : hour.ToString();

                gContent.Children.Add(new Label
                {
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = $"{h}:{m}",
                }, 0, i);

                if (half)
                    hour++;
                half = !half;
            }
            //Tmp = Color.Green;
            // content
            List<string> hex = new List<string>();
            List<MyBoxView> lboxview = new List<MyBoxView>();
            for (int i = 0; i < 48; i++)
            {
                hex.Add("0");
            }

            for (int i = 1; i < 49; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    var tap = new TapGestureRecognizer();
                    var box = new MyBoxView
                    {
                        BackgroundColor = Color.Green,
                        Margin = 0,
                        X = i,
                        Y = j,
                    };
                    tap.Tapped += (sender, e) =>
                    {
                        for (int z = box.X - 1; z < 48; z++)
                        {
                            hex[z] = (box.Y - 1).ToString();
                            lboxview.Find(x => x.X == z + 1 && x.Y == box.Y).BackgroundColor = Color.Red;
                            for (int k = 1; k < 4; k++)
                            {
                                if (k != box.Y)
                                    lboxview.Find(x => x.X == z + 1 && x.Y == k).BackgroundColor = Color.Green;
                            }
                        }

                    };
                    box.GestureRecognizers.Add(tap);

                    if (hex[i - 1].ToString() == (j - 1).ToString())
                    {
                        box.BackgroundColor = Color.Red;
                    }
                    lboxview.Add(box);
                    gContent.Children.Add(box, j, i);
                }
            }
        }

        async void showAnimation()
        {
            await Task.Delay(1000);

            // rotate
            //await button.RotateTo(360, 2000);
            //button.Rotation = 0;
            //await button.RelRotateTo(360, 2000);

            // show up
            //for (float i = 0; i <= 1; i += 0.1f)
            //{
            //    await Task.Delay(200);
            //    button.Opacity = i;
            //}

            //scale up
            //await Task.Delay(1000);
            //await button.ScaleTo(2, 2000);
            //await button.RelScaleTo(1, 2000);

            //Scaling and Rotation with Anchors
            //double radius = Math.Min(Application.Current.MainPage.Width, Application.Current.MainPage.Height) / 2;
            //button.AnchorY = radius / button.Height;
            //await button.RotateTo(360, 2000);

            //TranslateTo
            //await button.TranslateTo(-100, -100, 5000);

            //face
            //button.Opacity = 0;
            //await button.FadeTo(1, 2000);

            //
            await Task.WhenAny<bool>
                    (
                      button.RotateTo(360, 4000),
                      button.ScaleTo(2, 2000)
                    );
            await button.ScaleTo(1, 2000);
        }
    }
}