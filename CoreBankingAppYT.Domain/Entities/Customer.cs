using System.ComponentModel.DataAnnotations;


namespace CoreBankingAppYT.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
