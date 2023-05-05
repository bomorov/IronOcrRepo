using System.Drawing;
using IronOcr;
using WebApi.Interfaces;

namespace WebApi.Services;

public class IronOcrService : IOcrService
{
  public async Task<string> PassportNumberRecognition(Bitmap image)
  {
    var ironOcr = new IronTesseract();
    ironOcr.Configuration.WhiteListCharacters = "ANID0123456789";
    ironOcr.Language = OcrLanguage.English;
    ironOcr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
    using var input = new OcrInput();
    input.Deskew();
    input.DeNoise();
    input.Despeckle();
    input.EnhanceResolution(225);
    input.Sharpen();
    input.Erode();
    input.Dilate();
    input.Scale(200);
    input.ToGrayScale();
    input.AddImage(image);
    var text = ironOcr.Read(input).Text;
    text = text.Trim(); 
    text = text.Replace(" ", "");
    return text;
  }
}