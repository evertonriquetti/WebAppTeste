using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppTeste.Data;
using WebAppTeste.Models;
namespace WebAppTeste.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _userContext;
        public UserController(UserContext context) 
        {  
            _userContext = context; 
        }
        public IActionResult Index() 
        { 
            return View(); 
        }
        public IActionResult AddUser() 
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(string generate)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://randomuser.me/api/?nat=BR");
            Console.WriteLine(response);
            dynamic user = JsonConvert.DeserializeObject(response);
            var newUser = new User
            {
                name = $"{user.results[0].name.first} {user.results[0].name.last}",
                gender = user.results[0].gender,
                cpf = user.results[0].id.value,
                email = user.results[0].email,
                cell = user.results[0].phone,
                address = $"{user.results[0].location.street.name} {user.results[0].location.street.number}",
                city = user.results[0].location.city,
                state = user.results[0].location.state,
                postcode = user.results[0].location.postcode.ToString(),
                country = user.results[0].location.country
            };

            _userContext.Users.Add(newUser);
            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar: {ex.Message}");
            }
            return RedirectToAction("Report");
        }
        public IActionResult Report() 
        {
            var users = _userContext.Users.ToList();
            return View(users);
        }
        public IActionResult EditUser(int id)
        {
            var user = _userContext.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            _userContext.Users.Update(user);
            _userContext.SaveChanges();
            return RedirectToAction("Report");
        }

    }
}
