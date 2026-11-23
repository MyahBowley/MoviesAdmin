
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAdmin.Models;

public class ContentRatingsController : Controller
{
    private readonly MoviesAdminContext _context;

    public ContentRatingsController(MoviesAdminContext context)
    {
        _context = context;
    }

    // GET: CONTENTRATINGS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.ContentRating.ToListAsync());
    }

    // GET: CONTENTRATINGS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contentrating = await _context.ContentRating
            .FirstOrDefaultAsync(m => m.Id == id);
        if (contentrating == null)
        {
            return NotFound();
        }

        return View(contentrating);
    }

    // GET: CONTENTRATINGS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CONTENTRATINGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Movies,Title")] ContentRating contentrating)
    {
        if (ModelState.IsValid)
        {
            _context.Add(contentrating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(contentrating);
    }

    // GET: CONTENTRATINGS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contentrating = await _context.ContentRating.FindAsync(id);
        if (contentrating == null)
        {
            return NotFound();
        }
        return View(contentrating);
    }

    // POST: CONTENTRATINGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Movies,Title")] ContentRating contentrating)
    {
        if (id != contentrating.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(contentrating);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentRatingExists(contentrating.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(contentrating);
    }

    // GET: CONTENTRATINGS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contentrating = await _context.ContentRating
            .FirstOrDefaultAsync(m => m.Id == id);
        if (contentrating == null)
        {
            return NotFound();
        }

        return View(contentrating);
    }

    // POST: CONTENTRATINGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var contentrating = await _context.ContentRating.FindAsync(id);
        if (contentrating != null)
        {
            _context.ContentRating.Remove(contentrating);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContentRatingExists(int? id)
    {
        return _context.ContentRating.Any(e => e.Id == id);
    }
}
