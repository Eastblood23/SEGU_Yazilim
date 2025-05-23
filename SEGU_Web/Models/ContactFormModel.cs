using System.ComponentModel.DataAnnotations;

namespace SEGU_Web.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
    [Display(Name = "Ad Soyad")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-posta alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    [Display(Name = "E-posta")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefon alanı zorunludur.")]
    [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
    [Display(Name = "Telefon")]
    public string Phone { get; set; } = string.Empty;

    [Display(Name = "Şirket/Kurum")]
    public string Company { get; set; } = string.Empty;

    [Required(ErrorMessage = "Konu alanı zorunludur.")]
    [Display(Name = "Konu")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
    [Display(Name = "Mesajınız")]
    [MinLength(10, ErrorMessage = "Mesajınız en az 10 karakter olmalıdır.")]
    public string Message { get; set; } = string.Empty;

    [Display(Name = "İletişim Tercihi")]
    public ContactPreference ContactPreference { get; set; } = ContactPreference.Email;

    [Display(Name = "KVKK Onayı")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "KVKK aydınlatma metnini onaylamanız gerekmektedir.")]
    public bool PrivacyConsent { get; set; }
}

public enum ContactPreference
{
    [Display(Name = "E-posta")]
    Email,
    
    [Display(Name = "Telefon")]
    Phone,
    
    [Display(Name = "WhatsApp")]
    WhatsApp
} 