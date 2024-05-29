using System.ComponentModel.DataAnnotations;

namespace Clinic.Models;

public class NewPrescriptionDTO
{
    [Required]
    public DateOnly? Date { get; init; }

    [Required]
    public DateOnly? DueDate { get; init; }

    [Required]
    public int? DoctorId { get; init; }

    public PatientDTO Patient { get; init; } = null!;

    [MinLength(1)]
    public List<MedicamentDTO> Medicaments { get; init; } = null!;

    public class PatientDTO
    {
        [Required]
        public int? Id { get; init; }

        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;

        [Required]
        public DateOnly? BirthDate { get; init; }
    }

    public class MedicamentDTO
    {
        [Required]
        public int? MedicamentId { get; init; }

        public int? Dose { get; init; }
        public string Details { get; init; } = null!;
    }
}
