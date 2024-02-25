using Microsoft.AspNetCore.Mvc;
using MyAdsApi.Models;

namespace MyAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly GoogleAdsService _adsService;

        public AdsController(GoogleAdsService adsService)
        {
            _adsService = adsService;
        }

        [HttpGet]
        public IActionResult GetAllAds()
        {
            List<Ad> ads = _adsService.GetAllAds();
            return Ok(ads);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdById(int id)
        {
            Ad ad = _adsService.GetAdById(id);
            if (ad == null)
            {
                return NotFound();
            }
            return Ok(ad);
        }

        [HttpPost]
        public IActionResult CreateAd([FromBody] Ad ad)
        {
            _adsService.CreateAd(ad);
            return CreatedAtAction(nameof(GetAdById), new { id = ad.Id }, ad);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAd(int id, [FromBody] Ad ad)
        {
            if (id != ad.Id)
            {
                return BadRequest();
            }
            _adsService.UpdateAd(ad);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAd(int id)
        {
            _adsService.DeleteAd(id);
            return NoContent();
        }
    }
}
