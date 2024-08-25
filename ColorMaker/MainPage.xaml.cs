﻿
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {

        bool isRandom;
        string hexValue;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom) { 
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red,green,blue);
            SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            btnRandom.BackgroundColor= color;
            Container.BackgroundColor= color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();
            var color = Color.FromRgb(random.Next(0,265),random.Next(0,265),random.Next(0,265));

            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
            isRandom = false;

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("color copiado", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
            
        }
    }

}
