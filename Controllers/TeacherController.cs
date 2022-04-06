using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Data;
namespace MVC.Controllers;

public class TeacherController : Controller
{

    private readonly ApplicationDBContext _Db;
    public TeacherController(ApplicationDBContext db)
    {
        _Db = db;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var teachers = from t in _Db.Teacher
                       select t;
        if (!String.IsNullOrEmpty(searchString))
        {
            teachers = teachers.Where(s => s.Teacher_Name!.Contains(searchString));
        }

        return View(await teachers.ToListAsync());

    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Teacher obj)
    {

        if (ModelState.IsValid)
        {
            _Db.Teacher.Add(obj);
            _Db.SaveChanges();
            TempData["success"] = "Teacher created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    [HttpGet]
    public IActionResult Edit(int teacherid)
    {
        var subobj = _Db.Teacher.Find(teacherid);
        return View(subobj);

    }

    [HttpPost]
    public IActionResult Edit(Teacher updatedvaluesobj)
    {
        _Db.Teacher.Update(updatedvaluesobj);
        _Db.SaveChanges();
        return RedirectToAction("Index");

    }
    [HttpGet]
    public IActionResult Delete(int? TeacherID)
    {
        if (TeacherID == null || TeacherID == 0)
        {
            return NotFound();
        }
        var TeacherFromDb = _Db.Teacher.Find(TeacherID);


        if (TeacherFromDb == null)
        {
            return NotFound();
        }

        return View(TeacherFromDb);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int ID)
    {
        var teacherobj = _Db.Teacher.Find(ID);

        if (ModelState.IsValid)
        {

            _Db.Teacher.Remove(teacherobj);
            _Db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ID);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}