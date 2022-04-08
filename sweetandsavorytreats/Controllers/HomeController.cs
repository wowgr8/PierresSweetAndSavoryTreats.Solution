using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SweetAndSavoryTreats.Models;
using System.Collections.Generic;
using System.Linq;


namespace SweetAndSavoryTreats.Controllers
{
  public class HomeController : Controller
  {
    private readonly SweetAndSavoryTreatsContext _db;

    public HomeController(SweetAndSavoryTreatsContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index(string search)
    {
      List<Treat> model = _db.Treats.Where(x => x.TreatName.Contains(search) || search == null).ToList();
      return View(model);
    }
  }
}