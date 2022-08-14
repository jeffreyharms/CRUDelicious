using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class DishController : Controller
{
    private CRUDeliciousContext _context;
    public DishController(CRUDeliciousContext context)
    {
        _context = context;
    }
    [HttpGet("")]
    [HttpGet("/dishes/all")]
    public IActionResult All()
    {
        List<Dish> AllDishes = _context.dishes.ToList();
        return View("All", AllDishes);
    }
    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }
    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid == false)
        {
            return New();
        }
        _context.dishes.Add(newDish);
        _context.SaveChanges();

        return RedirectToAction("All");
    }
    [HttpGet("/dishes/{dishId}")]
    public IActionResult ViewDish(int dishId)
    {
        Dish? dish = _context.dishes.FirstOrDefault(dish => dish.id == dishId);
        if (dish == null)
        {
            return RedirectToAction("All");
        }

        return View("ViewDish", dish);
    }
    [HttpPost("/dishes/{deletedDishId}")]
    public IActionResult Delete(int deletedDishId)
    {
        Dish? dishToBeDeleted = _context.dishes.FirstOrDefault(dish => dish.id == deletedDishId);
    
    if (dishToBeDeleted != null)
    {
        _context.dishes.Remove(dishToBeDeleted);
        _context.SaveChanges();
    }
    return RedirectToAction("All");
    }
    [HttpGet("dishes/{dishToBeEdited}/edit")]
    public IActionResult EditDish(int dishToBeEdited)
    {
        Dish? dish = _context.dishes.FirstOrDefault(dish => dish.id == dishToBeEdited);
    
    if (dish == null)
    {
        return RedirectToAction("All");
    }

    return View("Edit", dish);
    }
    [HttpPost("/dishes/{updatedDishId}/update")]
    public IActionResult UpdateDish(int updatedDishId, Dish updatedDish)
    {
        if (ModelState.IsValid == false)
        {
            return EditDish(updatedDishId);
        }

        Dish? dbDish = _context.dishes.FirstOrDefault(dish => dish.id == updatedDishId);

        if (dbDish == null)
        {
            return RedirectToAction("All");
        }

        dbDish.name = updatedDish.name;
        dbDish.chef = updatedDish.chef;
        dbDish.calories = updatedDish.calories;
        dbDish.tastiness = updatedDish.tastiness;
        dbDish.description = updatedDish.description;
        dbDish.updated_at = DateTime.Now;

        _context.dishes.Update(dbDish);
        _context.SaveChanges();

        return RedirectToAction("ViewDish", updatedDish);
    }
}