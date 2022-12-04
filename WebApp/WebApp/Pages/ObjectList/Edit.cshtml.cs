using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Pages.ObjectList
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        
        public Item Item { get; set; }

        public async Task OnGet(int id)
        {
            Item = await _db.Item.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ItemFromDb = await _db.Item.FindAsync(Item.Id);
                ItemFromDb.Name = Item.Name;
                ItemFromDb.Dealer = Item.Dealer;
                ItemFromDb.ISO = Item.ISO; 

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
