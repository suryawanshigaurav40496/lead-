using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AgroErp.Server
{
    
        public class ContactRepository
        {
            private readonly string _connectionString;

            public ContactRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("AgroERPConnection");
            }

        public async Task<IEnumerable<Contacts>> GetContactsAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            // Execute the query and assign the result to a variable
            var contacts = await db.QueryAsync<Contacts>(
                @"SELECT 
            id AS Id, 
            contact_owner AS ContactOwner, 
            first_name AS FirstName, 
            middle_name AS MiddleName, 
            last_name AS LastName, 
            date_of_birth AS DateOfBirth, 
            email AS Email, 
            phone_no AS PhoneNo, 
            current_address AS CurrentAddress, 
            permanent_address AS PermanentAddress, 
            email_optout AS EmailOptOut, 
            lead_source AS LeadSource, 
            created_at AS CreatedAt, 
            modified_at AS ModifiedAt, 
            description AS Description
          FROM Contacts"
            );

            // Debug: Print out results
            Console.WriteLine("Retrieved Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Id: {contact.Id}, FirstName: {contact.FirstName}, LastName: {contact.LastName}");
            }

            // Return the contacts data
            return contacts;
        }




        public async Task AddContactAsync(Contacts contact)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = @"
         INSERT INTO Contacts 
         (contact_owner, first_name, middle_name, last_name, date_of_birth, email, phone_no, current_address, permanent_address, email_optout, lead_source, created_at, modified_at, description) 
         VALUES 
         (@ContactOwner, @FirstName, @MiddleName, @LastName, @DateOfBirth, @Email, @PhoneNo, @CurrentAddress, @PermanentAddress, @EmailOptOut, @LeadSource, @CreatedAt, @ModifiedAt, @Description)";

           // contact.CreatedAt = DateTime.Now;
           // contact.ModifiedAt = DateTime.Now;

            await db.ExecuteAsync(sql, contact);
        }
    }
    
}
