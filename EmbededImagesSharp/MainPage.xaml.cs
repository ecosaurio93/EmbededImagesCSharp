using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace EmbededImagesSharp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                SKBitmap bitmap = SKBitmap.Decode("Assets/Imagen1.png");
                SKBitmap bitmap2 = SKBitmap.Decode("Assets/Imagen2.png");

                var toBitmap = new SKBitmap((int)Math.Round((double)bitmap.Width * 1), (int)Math.Round((double)bitmap.Height * 1), bitmap.ColorType, bitmap.AlphaType);
                var imagen1 = SKImage.FromBitmap(bitmap);
                var imagen2 = SKImage.FromBitmap(bitmap2);
                SKCanvas canvas = new SKCanvas(bitmap);
                canvas.DrawImage(imagen1, new SKPoint(0,500));
                canvas.DrawImage(imagen2, new SKPoint(0,100));

                canvas.Flush();

                var image = SKImage.FromBitmap(toBitmap);
                var data = image.Encode(SKEncodedImageFormat.Jpeg, 90);

                var respuesta = data.AsStream();

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(respuesta.AsRandomAccessStream());

                ImagenGenerada.Source = bitmapImage;
                    
            }
            catch (ArgumentException)
            {
            }
        }
    }
}
