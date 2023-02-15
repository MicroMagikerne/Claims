namespace ClaimsService; 

public class Claim 
{ 
    public long ClaimId { get; set; } 
    public DateTime ClaimDate { get; set; } 
    public int CustomerId { get; set; } 
    public string? Description { get; set; } 
} 

