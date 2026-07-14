using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace g2soire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormateurIAController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IHttpClientFactory _httpFactory;

    public FormateurIAController(IConfiguration config, IHttpClientFactory httpFactory)
    {
        _config = config;
        _httpFactory = httpFactory;
    }

    // POST /api/FormateurIA/session-token
    [HttpPost("session-token")]
    public async Task<IActionResult> GetSessionToken()
    {
        var apiKey = _config["Anam:ApiKey"];
        if (string.IsNullOrEmpty(apiKey))
            return BadRequest(new { message = "Clé API Anam manquante." });

        // Configuration de l'avatar Martin (formateur)
        var body = new
        {
            personaConfig = new
            {
                name = "Martin",
                avatarId = "91e9e4d4-f0a2-49da-bad9-1d9bf77e62e7",
                voiceId = "77f3a4f8-7bf1-4a5f-8f06-21164b16b85e",
                llmId = "0934d97d-0c3a-4f33-91b0-5e136a0ef466",
                systemPrompt = "[STYLE] Réponds en français, en langage naturel parlé, sans formatage, avec des phrases courtes. [PERSONALITY] Tu es Martin, un formateur pédagogue et bienveillant de la plateforme g2soire. Tu présentes des formations et réponds aux questions des apprenants de manière claire et encourageante."
            }
        };

        var json = JsonSerializer.Serialize(body);

        var client = _httpFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.anam.ai/v1/auth/session-token");
        request.Headers.Add("Authorization", $"Bearer {apiKey}");
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode, new { message = "Erreur Anam", details = content });

        return Content(content, "application/json");
    }
}