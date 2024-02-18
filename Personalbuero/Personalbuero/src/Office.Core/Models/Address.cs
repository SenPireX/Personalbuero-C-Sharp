using System.ComponentModel.DataAnnotations;

namespace Personalverwaltung.Office.Core.Models;

public record Address([MaxLength(255)] string Street, [MaxLength(255)] string Zip, [MaxLength(255)] string City);