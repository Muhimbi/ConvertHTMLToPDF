using ServiceReference1;

namespace PDFConversion
{
    public class HTMLConversion
    {
        /// <summary>
        /// Simple sample to convert either a URL or HTML code fragment to PDF format
        /// </summary>
        static void Main(string[] args) {
            DocumentConverterServiceClient? client = null;
            try {
                string? sourceFileName = null;
                byte[]? sourceFile = null;
                
                client = UtilClass.OpenService();
                OpenOptions openOptions = new OpenOptions();
                
                //** Specify authentication settings for the web page if it'll be required
                //openOptions.UserName = "";
                //openOptions.Password = "";
                
                //** Specify the HTML content to convert in UTF8
                //sourceFile = System.Text.Encoding.UTF8.GetBytes("Hello <b>world</b>");
                
                // ** If the sourceFile is null, then specify the URL to convert
                openOptions.OriginalFileName = "https://www.muhimbi.com";
                openOptions.FileExtension = "html";
                
                //** Generate a temp file name that is later used to write the PDF to
                sourceFileName = Path.GetTempFileName();
                File.Delete(sourceFileName);
                // ** Enable JavaScript on the page to convert.
                openOptions.AllowMacros = MacroSecurityOption.All;
                
                // ** Set the various conversion settings
                ConversionSettings conversionSettings = new ConversionSettings();
                conversionSettings.Fidelity = ConversionFidelities.Full;
               //conversionSettings.PageOrientation = PageOrientation.Landscape;
                conversionSettings.Quality = ConversionQuality.OptimizeForPrint;

                ConverterSpecificSettings_HTML converterSpecificSettings_HTML = new ConverterSpecificSettings_HTML();
                converterSpecificSettings_HTML.AuthenticationMode = AuthenticationMode.WebAuthentication;
                //converterSpecificSettings_HTML.HtmlRenderingEngine = HTMLRenderingEngine.WebKit;
                converterSpecificSettings_HTML.ConversionDelay = 3500;
                converterSpecificSettings_HTML.PaperSize = "A3";
                converterSpecificSettings_HTML.Zoom = "1.4";
                conversionSettings.ConverterSpecificSettings = converterSpecificSettings_HTML;

                // ** Carry out the actual conversion
                byte[] convertedFile = client.Convert(sourceFile, openOptions, conversionSettings);
                
                // ** Write the PDF file to the local file system.
                using (FileStream fs = File.Create("C:\\Converter\\HTMLOutput.pdf")) {
                    fs.Write(convertedFile, 0, convertedFile.Length);
                    fs.Close();
                }
                // ** Display the converted file in a PDF viewer.
                // NavigateBrowser(destinationFileName);
            }
            finally {
                if (client != null)
                {
                    UtilClass.CloseService(client);
                }
            }
        }
    }
}
