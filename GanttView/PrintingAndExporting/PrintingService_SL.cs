using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;

namespace PrintingAndExporting
{
	public class PrintingService
	{
		public static void Print(RadGanttView ganttView)
		{
			var isFirstPass = true;
            var exportImages = Enumerable.Empty<ImageInfo>();
			var enumerator = exportImages.GetEnumerator();
			var pd = new System.Windows.Printing.PrintDocument();
			pd.PrintPage += (s, e) =>
			{
				if (isFirstPass)
				{
					var printingSettings = new ImageExportSettings(e.PrintableArea, true, GanttArea.AllAreas);
					using (var export = ganttView.ExportingService.BeginExporting(printingSettings))
					{
						exportImages = export.ImageInfos;
						enumerator = exportImages.GetEnumerator();
						enumerator.MoveNext();
					}
					isFirstPass = false;
				}

				e.PageVisual = PrintPage(enumerator.Current.Export());
				enumerator.MoveNext();
				e.HasMorePages = enumerator.Current != null;
			};
			pd.Print("Gantt");
		}

		private static UIElement PrintPage(BitmapSource bitmap)
		{
			var bitmapSize = new System.Windows.Size(bitmap.PixelWidth, bitmap.PixelHeight);
			var image = new System.Windows.Controls.Image { Source = bitmap };
			image.Measure(bitmapSize);
			image.Arrange(new System.Windows.Rect(new System.Windows.Point(0, 0), bitmapSize));
			return image;
		}
	}
}
