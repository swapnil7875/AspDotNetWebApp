﻿using PdfiumViewer;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace PdfToImage
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            try
            {
                string input = projectDir + @"\Sample\EAadhaar.pdf";

                string password = "BHUS1981"; // retrieve the password somehow 

                //using (PdfDocument document = new PdfDocument.Load(input, password))
                using (var document = PdfDocument.Load(projectDir + @"\Sample\EAadhaar.pdf", password))
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
                                System.Drawing.Imaging.Encoder.Quality, 100L);

                            image.Save(projectDir + @"\Sample\output_" + i + ".jpg", encoder, encParams);
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