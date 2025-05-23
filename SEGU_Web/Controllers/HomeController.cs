using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SEGU_Web.Models;

namespace SEGU_Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(ContactFormModel model)
    {
        if (!ModelState.IsValid)
        {
            // Form validation failed, return to the form with validation errors
            return RedirectToAction(nameof(Index), new { section = "contact" });
        }

        try
        {
            // Log the contact form submission
            _logger.LogInformation($"Contact form submitted by {model.Name} ({model.Email})");
            
            // In a real application, you would:
            // 1. Save to database
            // 2. Send email notification
            // 3. Process the contact request

            // Add success message to TempData
            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi. En kısa sürede size dönüş yapacağız.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing contact form");
            TempData["ErrorMessage"] = "Mesajınız gönderilirken bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
        }

        // Redirect to prevent form resubmission
        return RedirectToAction(nameof(Index), new { section = "contact" });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
