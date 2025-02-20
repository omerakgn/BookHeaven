﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHeaven.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FilesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("[action]")]
        public IActionResult GetBaseStorageUrl()
        {

            return Ok(new
            {
               baseUrl= _configuration["BaseStorageUrl"],
            });
        }
    }
}
