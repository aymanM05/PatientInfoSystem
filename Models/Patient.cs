namespace PatientInfoSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public DateTime DateOfConsultation { get; set; }
        public string ChiefComplaint { get; set; }
        public string PurposeOfVisit { get; set; }
        public bool IsDeleted { get; set; }  // Soft delete flag
    }
}
