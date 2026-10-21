
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAdmin.Models;
using MoviesAdmin.Services;

public class MoviesController : Controller
{
    private readonly MoviesAdminContext _context;
    private readonly AzureStorageService _azureStorage;

    // Constructor
    public MoviesController(MoviesAdminContext context, AzureStorageService azureStorage)
    {
        _context = context;
        _azureStorage = azureStorage;
    }

    // GET: MOVIES/Index
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Movie
            .OrderByDescending(t => t.ReleaseDate)
            .ToListAsync());
        //List<Movie> movies = await _context.Movie.ToListAsync();
        //return View(movies); // Display movies into the view
    }

    // GET: MOVIES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) // Is an ID included in URL?
        {
            return NotFound();
        }

        var movie = await _context.Movie
            .FirstOrDefaultAsync(m => m.Id == id); // get Movie from db where Id = 5
        if (movie == null) // Was the row found in db?
        {
            return NotFound();
        }

        return View(movie);
    }

    // GET: MOVIES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MOVIES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Synopsis,Genre,ContentRating,ReleaseDate,Runtime,OriginalLanguage")] Movie movie, IFormFile? ImageUpload)
    {
        //Validate if Image  File is missing
        if (ImageUpload == null)
        {
            // Add a validation error
            ModelState.AddModelError("ImageUpload", "Image file is required.");
            //return View(movie);
        }

        if (ModelState.IsValid) // Validate input
        {
            //
            // Upload file to Azure Storage (after input validation occurs)
            //

            // Make a unique filename (GUID.ext)
            string extension = Path.GetExtension(ImageUpload!.FileName); // includes the leading dot, e.g. ".jpg"
            string newFileName = $"{Guid.NewGuid()}{extension}";

            // Upload file to Azure Storage
            string url = await _azureStorage.UploadFileAsync(ImageUpload, newFileName);

            //string filename = ImageUpload.FileName;
            //string url = await _azureStorage.UploadFileAsync(ImageUpload, filename);

            // Set the image URL in trail record
            movie.ImageUrl = url;

            //
            // Save movie in database
            //

            _context.Add(movie); // Add new Movie to context (db)
            await _context.SaveChangesAsync(); // Save changes in db
            
            return RedirectToAction(nameof(Index)); // re-direct to Movies/Index page
        }
        return View(movie);
    }

    // GET: MOVIES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    // POST: MOVIES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Synopsis,Genre,ContentRating,ReleaseDate,Runtime,OriginalLanguage,ImageUrl")] Movie movie)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id))
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
        return View(movie);
    }

    // GET: MOVIES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: MOVIES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var movie = await _context.Movie.FindAsync(id);
        if (movie != null)
        {
            _context.Movie.Remove(movie);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int? id)
    {
        return _context.Movie.Any(e => e.Id == id);
    }
}
