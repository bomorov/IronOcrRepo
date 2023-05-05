using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TextRecognitionController : ControllerBase
{
  private readonly ITextRecognitionService _recognition;

  public TextRecognitionController(ITextRecognitionService recognition)
  {
    _recognition = recognition;
  }

  [HttpPost("Index")]
  public async Task<IActionResult> Index(IFormFile file)
  {
    using var ms = new MemoryStream();
    await file.CopyToAsync(ms);
    var fileBytes = ms.ToArray();
    var recognitionText = await _recognition.GetText(fileBytes);
    return Ok(recognitionText);
  }
}