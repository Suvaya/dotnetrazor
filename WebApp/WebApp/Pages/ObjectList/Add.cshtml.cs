using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Pages.ObjectList
{
    public class AddModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public AddModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Item Item { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Item.AddAsync(Item);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }
            else
            {
                return Page();
            }
        }
    }
}
