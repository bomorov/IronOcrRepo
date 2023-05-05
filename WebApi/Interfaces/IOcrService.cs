using System.Drawing;

namespace WebApi.Interfaces;

public interface IOcrService
{
  Task<string> PassportNumberRecognition(Bitmap image);
}