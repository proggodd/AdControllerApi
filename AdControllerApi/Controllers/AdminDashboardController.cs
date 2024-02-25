using Microsoft.AspNetCore.Mvc;
using MyAdsApi.Services;

namespace MyAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminDashboardController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("dashboard")]
        public IActionResult GetDashboardData()
        {
            var dashboardData = _adminService.GetDashboardData();
            return Ok(dashboardData);
        }

        [HttpPost("updateAdSettings")]
        public IActionResult UpdateAdSettings([FromBody] AdSettingsUpdateRequest request)
        {
            _adminService.UpdateAdSettings(request);
            return Ok();
        }

        // Other actions related to admin operations can be added here
    }
}
