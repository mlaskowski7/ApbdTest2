using System.ComponentModel.DataAnnotations;

namespace ApbdTest2.Api.Contracts.Request;

public class CreateCustomerPurchasesRequestDto
{
    [Required]
    public CustomerReq Customer { get; set; }
    
    [Required]
    public List<PurchasesReq> Purchases { get; set; }
    
    public class CustomerReq
    {
        public int Id { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        
        [MaxLength(100)]
        public string? PhoneNumber { get; set; }
    }

    public class PurchasesReq
    {
        [Required]
        public int SeatNumber { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string ConcertName { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}