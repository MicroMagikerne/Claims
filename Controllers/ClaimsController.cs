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

[HttpGet("GetClaimById/(claimId)}")] 
 public Claim Get(int claimId) 
 {    
    _logger.LogInformation("Metode GetClaimById called at {DT}",  
         DateTime.UtcNow.ToLongTimeString()); 

    return _claims.Where(c => c.ClaimId == claimId).First(); 
 } 
 [HttpPost("PostClaim")]
 public Claim? Post(Claim claim)
 {
    _logger.LogInformation("Metode PostClaim called at {DT}",  
         DateTime.UtcNow.ToLongTimeString()); 

     if(_claims.Where(x => x.ClaimId == claim.ClaimId).Count() != 0) {
        _logger.LogError("Claim ID already exists in the list!");
        return null;
     }   
     else{
    _claims.Add(claim);
    _logger.LogInformation("Claim Succecfully added to list at {DT}", DateTime.UtcNow.ToLongTimeString());
    return claim;
     }
 }
}


