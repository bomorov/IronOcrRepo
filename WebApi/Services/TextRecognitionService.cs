using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using WebApi.Interfaces;
using WebApi.Models;
using Image = System.Drawing.Image;
using Rectangle = System.Drawing.Rectangle;

#pragma warning disable CA1416
namespace WebApi.Services;

public class TextRecognitionService : ITextRecognitionService
{
  private readonly IOcrService _ocrService;

  public TextRecognitionService(IOcrService ocrService)
  {
    _ocrService = ocrService;
  }

  public async Task<RecognitionText> GetText(byte[] file)
  {
    using var stream = new MemoryStream(file);
    stream.Seek(0, SeekOrigin.Begin);
    
    var image = Image.FromStream(stream) as Bitmap;
    
    image = ScaleSize(image, 2);
    
    var outputFilePath = $@"D:\\images\\image{Guid.NewGuid()}.jpg";

    image.Save(outputFilePath, ImageFormat.Jpeg);
    
    var newImage = new Bitmap(outputFilePath);
    var textt = await _ocrService.PassportNumberRecognition(newImage); 

    
    var text = await _ocrService.PassportNumberRecognition(image); 
    
    return new RecognitionText(textt, text);
  }
  
  private static Bitmap ScaleSize(Bitmap image, int sizeValue)
  {
    // задание нового размера
    var newWidth = image.Width * sizeValue;
    var newHeight = image.Height * sizeValue;
    
    // создание нового изображения
    var newImage = new Bitmap(newWidth, newHeight);

    // установка свойств графики
    var graphics = Graphics.FromImage(newImage);
    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    graphics.SmoothingMode = SmoothingMode.HighQuality;

    // увеличение изображения
    graphics.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));

    return newImage;
  }
}