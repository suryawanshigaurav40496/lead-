using System.ComponentModel.DataAnnotations.Schema;

namespace AgroErp.Server
{
    public class Contacts
    {
        public int Id { get; set; }

        [Column("contact_owner")]
        public string ContactOwner { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone_no")]
        public string PhoneNo { get; set; }

        [Column("current_address")]
        public string CurrentAddress { get; set; }

        [Column("permanent_address")]
        public string PermanentAddress { get; set; }

        [Column("email_optout")]
        public bool EmailOptOut { get; set; }

        [Column("lead_source")]
        public string LeadSource { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [Column("description")]
        public string Description { get; set; }

    }

}

