using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoreWebFormAppAspx.PdfToImg
{
    public partial class PdfToImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
            protected void btnUploadClick(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["myFile"];

            //check file was submitted
            if (file != null && file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));

                var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                try
                {
                    string input = Server.MapPath(Path.Combine("~/App_Data/", fname));

                    string password = "BHUS1981"; // retrieve the password somehow 

                    using (var document = PdfDocument.Load(input, password))
                    {
                        var pageCount = document.PageCount;

                        for (int i = 0; i < pageCount; i++)
                        {
                            var dpi = 300;

                            using (var image = document.Render(i, dpi, dpi, PdfRenderFlags.CorrectFromDpi))
                            {
                                var encoder = ImageCodecInfo.GetImageEncoders()
                                    .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                                var encParams = new EncoderParameters(1);
                                encParams.Param[0] = new EncoderParameter(
                                    Encoder.Quality, 100L);

                                image.Save(Server.MapPath(Path.Combine("~/App_Data/","OutPut" + i + ".jpg")), encoder, encParams);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Press enter to continue...");

            }
        }

        
    }
}