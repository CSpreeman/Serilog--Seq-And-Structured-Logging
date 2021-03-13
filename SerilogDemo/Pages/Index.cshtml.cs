﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the index page.");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 50)
                    {
                        throw new Exception("This is our demo exception");
                    }
                    else
                    {
                        //Structured event logging
                        _logger.LogInformation("The value of i is {LoopCountValue}", i);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception caught in Index OnGet");
            }
        }
    }
}
