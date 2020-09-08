using LRCA.classes;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Linq;

namespace LRCA
{
	/// <summary>
	/// Summary description for FileHandler
	/// </summary>
	public class FileHandler : IHttpHandler, IRequiresSessionState
	{
		CryptoJS objcryptoJS = new CryptoJS();
		public void ProcessRequest(HttpContext context)
		{
			if (!context.User.Identity.IsAuthenticated)
			{
				FormsAuthentication.RedirectToLoginPage();
				return;
			}
			if (context.Request.Url.AbsoluteUri.IndexOf(".pdf") > -1)
			{
				using (var stream = new MemoryStream())
				{
					var url = objcryptoJS.AES_decrypt(context.Request.Url.AbsoluteUri.Split('/').Last().Replace(".pdf", ""), AppConstants.secretKey, AppConstants.initVec);
					var fileName = url;
					using (FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uf",url+".pdf"), FileMode.Create))
					{
						stream.CopyTo(fs);
					}
					context.Response.BinaryWrite(stream.ToArray());
				}
			}
			else
			{
				var userId = HttpContext.Current.Session["UserAuthId"];
				var template = objcryptoJS.AES_decrypt(context.Request.Url.AbsoluteUri.Split('/').Last().Replace(".cert", ""), AppConstants.secretKey, AppConstants.initVec);
				var content = new StringBuilder(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_data", template + ".htm")));
				if (template == "Acct_Certificate")
				{
					content.Replace("{{Name}}", ConvertTextToBase64Image("				Jack Vu", "Arial", 14, Color.White, Color.Black, 694, 70));
					content.Replace("{{CourseName}}", ConvertTextToBase64Image("		Inspection (IC)", "Arial", 14, Color.White, Color.Black, 598, 77));
					content.Replace("{{ExpDate}}", ConvertTextToBase64Image("12,12,2021", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{TP}}", ConvertTextToBase64Image("Zoom Training Center", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{CourseDate}}", ConvertTextToBase64Image("12,12,2020", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{CertId}}", ConvertTextToBase64Image(RandomNumber(5, 100).ToString(), "Arial", 18, Color.White, Color.Black, 152, 31));
				}
				else if (template == "TrainingCard")
				{
					content.Replace("{{Name}}", ConvertTextToBase64Image("Jack Vu", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{ClassCode}}", ConvertTextToBase64Image("Inspection (IC)", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{DOB}}", ConvertTextToBase64Image("12,12,1984", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{ProviderName}}", ConvertTextToBase64Image("Zoom Training Center", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{ExpDate}}", ConvertTextToBase64Image("12,12,2021", "Arial", 18, Color.White, Color.Black, 262, 32));
					content.Replace("{{Number}}", ConvertTextToBase64Image(RandomNumber(5, 100).ToString(), "Arial", 18, Color.White, Color.Black, 262, 32));
				}
				var fileName = Guid.NewGuid();
				context.Response.Headers.Add("Content-Type", "text/pdf");
				context.Response.Headers.Add("Content-Disposition", "attachment; filename=" + objcryptoJS.AES_encrypt(userId.ToString(), AppConstants.secretKey, AppConstants.initVec) + "_" + template + ".pdf");
				using (var stream = new MemoryStream())
				{
					new PdfConverter().Convert(stream, content.ToString());
					var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attachments");
					var dir = new DirectoryInfo(path);
					if (!dir.Exists)
						dir.Create();
					using (FileStream fs = new FileStream(string.Format("{0}\\{1}.pdf", path, fileName), FileMode.Create))
					{
						stream.CopyTo(fs);
					}
					context.Response.BinaryWrite(stream.ToArray());
					stream.Flush();

				}
			}

		}
		private readonly Random _random = new Random();
		public int RandomNumber(int min, int max)
		{
			return _random.Next(min, max);
		}
		public string ConvertTextToBase64Image(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height)
		{
			var result = string.Empty;
			Bitmap bmp = new Bitmap(width, Height);
			using (var ms = new MemoryStream())
			using (Graphics graphics = Graphics.FromImage(bmp))
			{

				Font font = new Font(fontname, fontsize);
				graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height);
				graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
				graphics.Flush();
				font.Dispose();
				graphics.Dispose();
				bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				result = Convert.ToBase64String(ms.GetBuffer()); //Get Base64


			}
			return result;
		}
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}