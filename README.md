# ConvertHTMLToPDF

This project demonstrates how to convert a URL or HTML code fragment to PDF format using the Document Converter OnPremises web service.

## Files

- `TestURLConversion.cs`: Contains the main class `HTMLConversion` which performs the conversion.
- `UtilClass.cs`: Contains utility methods for opening and closing the web service.

## Usage

1. Ensure the web service URL in `UtilClass.cs` is correct.
2. Run the `HTMLConversion` class in `TestURLConversion.cs` to perform the conversion.

## Example

The example in `TestURLConversion.cs` converts the URL `https://www.muhimbi.com` to a PDF file and saves it to `C:\\Converter\\HTMLOutput.pdf`.

## Dependencies

- .NET Framework
- ServiceReference1 (Web Service Reference)

## License

This project is licensed under the MIT License.