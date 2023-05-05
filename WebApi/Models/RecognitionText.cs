namespace WebApi.Models;

public class RecognitionText
{
  public RecognitionText(string byPath, string byVariable)
  {
    ByPath = byPath;
    ByVariable = byVariable;
  }

  public string ByPath { get; set; }
  public string ByVariable { get; set; }
}