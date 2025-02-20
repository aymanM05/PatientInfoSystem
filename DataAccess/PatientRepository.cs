using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using PatientInfoSystem.Models;

namespace PatientInfoSystem.Repositories
{
    public class PatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Patient> GetAllPatients(string search = "")
        {
            List<Patient> patients = new();
            using (SqlConnection conn = new(_connectionString))
            {
                string query = "SELECT * FROM tbl_Patient WHERE IsDeleted = 0 AND (FirstName LIKE @search OR LastName LIKE @search OR MiddleName LIKE @search OR ChiefComplaint LIKE @search) ";
                SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        MiddleName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Suffix = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        Gender = reader.GetString(5),
                        Birthday = reader.GetDateTime(6),
                        ContactNo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        Address = reader.GetString(8),
                        DateOfConsultation = reader.GetDateTime(9),
                        ChiefComplaint = reader.GetString(10),
                        PurposeOfVisit = reader.GetString(11),
                        IsDeleted = reader.GetBoolean(12)
                    });
                }
            }
            return patients;
        }

        public void AddPatient(Patient patient)
        {
            using (SqlConnection conn = new(_connectionString))
            {
                string query = "INSERT INTO tbl_Patient (FirstName, LastName, MiddleName, Suffix, Gender, Birthday, ContactNo, Address, DateOfConsultation, ChiefComplaint, PurposeOfVisit) VALUES (@FirstName, @LastName, @MiddleName, @Suffix, @Gender, @Birthday, @ContactNo, @Address, @DateOfConsultation, @ChiefComplaint, @PurposeOfVisit)";
                SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@MiddleName", patient.MiddleName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Suffix", patient.Suffix ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Birthday", patient.Birthday);
                cmd.Parameters.AddWithValue("@ContactNo", patient.ContactNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@DateOfConsultation", patient.DateOfConsultation);
                cmd.Parameters.AddWithValue("@ChiefComplaint", patient.ChiefComplaint);
                cmd.Parameters.AddWithValue("@PurposeOfVisit", patient.PurposeOfVisit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDeletePatient(int id)
        {
            using (SqlConnection conn = new(_connectionString))
            {
                string query = "UPDATE tbl_Patient SET IsDeleted = 1 WHERE Id = @Id";
                SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
         public void UpdatePatient(Patient patient)
        {
            using (SqlConnection conn = new(_connectionString))
            {
               string query = @"
                UPDATE tbl_Patient 
                SET FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, 
                    Suffix = @Suffix, Gender = @Gender, Birthday = @Birthday, 
                    ContactNo = @ContactNo, Address = @Address, 
                    DateOfConsultation = @DateOfConsultation, ChiefComplaint = @ChiefComplaint, 
                    PurposeOfVisit = @PurposeOfVisit 
                WHERE Id = @Id";
                SqlCommand cmd = new(query, conn);
                 cmd.Parameters.AddWithValue("@Id", patient.Id);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@MiddleName", patient.MiddleName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Suffix", patient.Suffix ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Birthday", patient.Birthday);
                cmd.Parameters.AddWithValue("@ContactNo", patient.ContactNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@DateOfConsultation", patient.DateOfConsultation);
                cmd.Parameters.AddWithValue("@ChiefComplaint", patient.ChiefComplaint);
                cmd.Parameters.AddWithValue("@PurposeOfVisit", patient.PurposeOfVisit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        
        
    }
}
