
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientInfoSystem.Models;
using PatientInfoSystem.Repositories;
using System.Collections.Generic;

public class IndexModel : PageModel
{
    private readonly PatientRepository _patientRepository;
    public string SearchTerm { get; set; }
    public IndexModel(PatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public List<Patient> Patients { get; set; }
      public void OnGet(string search)
    {
        SearchTerm = search;
        Patients = _patientRepository.GetAllPatients(search);
    }

public IActionResult OnPost(string FirstName, string LastName, string MiddleName, string Suffix, string Gender, DateTime Birthday, string ContactNo, string Address, DateTime DateOfConsultation, string ChiefComplaint, string PurposeOfVisit)
{
    if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
    {
        ModelState.AddModelError(string.Empty, "First Name and Last Name are required.");
        return Page();
    }

    var newPatient = new Patient
    {
        FirstName = FirstName,
        LastName = LastName,
        MiddleName = MiddleName,
        Suffix = Suffix,
        Gender = Gender,
        Birthday = Birthday,
        ContactNo = ContactNo,
        Address = Address,
        DateOfConsultation = DateOfConsultation,
        ChiefComplaint = ChiefComplaint,
        PurposeOfVisit = PurposeOfVisit,
        IsDeleted = false
    };

    _patientRepository.AddPatient(newPatient);
    return RedirectToPage();
}

    public IActionResult OnGetDelete(int id)
    {
        _patientRepository.SoftDeletePatient(id);
        TempData["DeleteMessage"] = "Patient Deleted successfully!";
        return RedirectToPage();
    }
    public IActionResult OnPostAdd(Patient patient)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        patient.IsDeleted = false;
        _patientRepository.AddPatient(patient);
        TempData["SaveMessage"] = "Patient added successfully!";
        return RedirectToPage();
    }
    public IActionResult OnPostEdit(int Id, string FirstName, string LastName, string MiddleName, string Suffix, string Gender, DateTime Birthday, string ContactNo, string Address, DateTime DateOfConsultation, string ChiefComplaint, string PurposeOfVisit)
    {
        var patient = new Patient
        {
            Id = Id,  // Retrieve the ID
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            Suffix = Suffix,
            Gender = Gender,
            Birthday = Birthday,
            ContactNo = ContactNo,
            Address = Address,
            DateOfConsultation = DateOfConsultation,
            ChiefComplaint = ChiefComplaint,
            PurposeOfVisit = PurposeOfVisit
        };

        _patientRepository.UpdatePatient(patient);
        TempData["SuccessMessage"] = "Patient details updated successfully!";
        return RedirectToPage();
    }
}