using SelectPdf;
using System.IO;

namespace LRCA.classes
{
	public class PdfConverter
	{
		#region Convert
		public byte[] Convert(string template)
		{
			byte[] outPdfBuffer = null;
			HtmlToPdf converter = new HtmlToPdf();

			converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
			//converter.Options.ViewerPreferences.FitWindow = true;
			converter.Options.ViewerPreferences.CenterWindow = true;
			converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
			converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit;
			converter.Options.PdfPageSize = PdfPageSize.A4;
			converter.Options.PdfPageOrientation = PdfPageOrientation.Landscape;
			PdfDocument doc = converter.ConvertHtmlString(template, AppConstants.ConstAppURL);
			outPdfBuffer = doc.Save();
			return outPdfBuffer;
		}

		public void Convert(MemoryStream stream, string template)
		{
			HtmlToPdf converter = new HtmlToPdf();

			converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
			//converter.Options.ViewerPreferences.FitWindow = true;
			converter.Options.ViewerPreferences.CenterWindow = true;
			converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
			converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit;
			//converter.Options.PdfPageSize = PdfPageSize.B5;
			converter.Options.PdfPageOrientation = PdfPageOrientation.Landscape;
			PdfDocument doc = converter.ConvertHtmlString(template, AppConstants.ConstAppURL);
			doc.Save(stream);
			stream.Position = 0;
		}
		#endregion
	}
}