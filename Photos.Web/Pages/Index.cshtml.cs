using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Photos.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public bool IsAdmin { get; set; }

        public Task OnGet()
        {
            IsAdmin = User.IsInRole(Strings.AdminRole);
            return Task.CompletedTask;
        }
    }
}