using Microsoft.AspNetCore.Mvc;
using ClaimsService;
using System.Linq; 

namespace ClaimsService.Controllers;

[ApiController]
[Route("[controller]")]
public class ClaimsController : ControllerBase
{
    private static List<Claim> _claims = new List<Claim>() { 
     new Claim() {  
       ClaimId = 1, 
       ClaimDate = new DateTime(2023, 02, 06, 12, 11, 0), 
       CustomerId = 2266, 
       Description = "Hvorfor kommer taxa'en ikke?" 
     } 
 }; 

    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(ILogger<ClaimsController> logger)
    {
        _logger = logger;
    }

[HttpGet("GetClaimById")] 
 public Claim Get(int claimId) 
 {    
    return _claims.Where(c => c.ClaimId == claimId).First(); 
 } 
}
