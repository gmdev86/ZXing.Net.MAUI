using System;
using System.Linq;
using BigIslandBarcode.Controls;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using ZXing.Net.Maui;

namespace BigIslandBarcode
{
	public partial class MainPage : ContentPage
	{
		public GraphicsDrawable graphicsDrawable { get; set; }
        public MainPage()
		{
			InitializeComponent();

			barcodeView.Options = new BarcodeReaderOptions
			{
				Formats = BarcodeFormats.TwoDimensional,
				AutoRotate = true,
				Multiple = false
			};

			graphicsDrawable = new GraphicsDrawable();
			MyCanvas.Drawable = graphicsDrawable;
			MyCanvas.Invalidate();
		}

		protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
		{
			foreach (var barcode in e.Results)
				Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");

			Device.InvokeOnMainThreadAsync(() =>
			{
				var r = e.Results.First();

				//barcodeGenerator.Value = r.Value;
				//barcodeGenerator.Format = r.Format;
				DecodedValue.Text = r.Value;
				graphicsDrawable.StrokeColor = Colors.Red;
                MyCanvas.Invalidate();
				
			});
		}

		void SwitchCameraButton_Clicked(object sender, EventArgs e)
		{
			barcodeView.CameraLocation = barcodeView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
		}

		void TorchButton_Clicked(object sender, EventArgs e)
		{
			barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
		}
	}
}
