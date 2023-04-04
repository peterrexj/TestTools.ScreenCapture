using Aspose.Words;
using Pj.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.ScreenCapture.Library
{
    internal static class AsposeWordHelper
    {
        public static void GenerateWordDocWithImages(string folderWithImages, string inputTemplateFile, string outputFile, 
            bool includePdf, bool includeXaml, bool includeHtml, bool includeXps)
        {
            var images = Directory
                .EnumerateFiles(folderWithImages, "*.png")
                .Select(f => new { Path = f, Created = new FileInfo(f).CreationTime })
                .OrderBy(f => f.Created)
                .Select(f => f.Path);

            if (images.IsEmpty()) return;


            // Load the Word document into a Document object
            Document doc = new Document(inputTemplateFile);

            // Create a DocumentBuilder object
            DocumentBuilder builder = new DocumentBuilder(doc);
            
            foreach (var image in images)
            {
                // Insert the image into the document
                builder.InsertImage(image);
            }
            //builder.InsertParagraph();

            // Save the document
            doc.Save(outputFile);

            if (includePdf)
            {
                var filePath = IoHelper.CombinePath(Path.GetDirectoryName(outputFile), $"{Path.GetFileNameWithoutExtension(outputFile)}.pdf");
                // Save the document as PDF
                doc.Save(filePath, SaveFormat.Pdf);
            }

            if (includeHtml)
            {
                var filePath = IoHelper.CombinePath(Path.GetDirectoryName(outputFile), $"{Path.GetFileNameWithoutExtension(outputFile)}.html");
                // Save the document as PDF
                doc.Save(filePath, SaveFormat.Mhtml);
            }

            if (includeXps)
            {
                var filePath = IoHelper.CombinePath(Path.GetDirectoryName(outputFile), $"{Path.GetFileNameWithoutExtension(outputFile)}.xps");
                // Save the document as PDF
                doc.Save(filePath, SaveFormat.Xps);
            }

            if (includeXaml)
            {
                var filePath = IoHelper.CombinePath(Path.GetDirectoryName(outputFile), $"{Path.GetFileNameWithoutExtension(outputFile)}.xaml");
                // Save the document as PDF
                doc.Save(filePath, SaveFormat.XamlFlowPack);
            }
        }
    }
}
