using FrontEndDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontEndDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        public UserController()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5134/") };
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<User>? usersList = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
                    return View(usersList ?? []);
                }

                ModelState.AddModelError(string.Empty, "Failed to retrieve user details.");
                IEnumerable<User> users = [];
                return View(users);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }



        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password,Phone,BirthDate")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var response = await _httpClient.PostAsJsonAsync("api/user", user);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = user.Id });
            }

            ModelState.AddModelError(string.Empty, "Failed to create user.");
            return View(user);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
