using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Pages.ObjectList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;   
        }

        public IEnumerable<Item> Items { get; set; }

        public async Task OnGet()
        {
            Items = await _db.Item.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var item = await _db.Item.FindAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            
            _db.Item.Remove(item);
            
            await _db.SaveChangesAsync();

            return RedirectToPage("Index"); 
        }
    }
}
