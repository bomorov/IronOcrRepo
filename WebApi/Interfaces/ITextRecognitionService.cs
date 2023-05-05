using WebApi.Models;

namespace WebApi.Interfaces;

public interface ITextRecognitionService
{
  Task<RecognitionText> GetText(byte[] file);
}