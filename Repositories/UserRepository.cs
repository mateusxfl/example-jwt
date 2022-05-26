using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {

            // Sintax alternative: new User {Id = 1, Username = "Mateus", Password = "mypassmateus", Role="Manager"},
            var users = new List<User>(){
                new() {Id = 1, Username = "Mateus", Password = "mypassmateus", Role="Manager"},
                new() {Id = 2, Username = "Brena", Password = "mypassbrena", Role="Manager"},
                new() {Id = 3, Username = "Danny", Password = "mypassdanny", Role="Employee"},
                new() {Id = 4, Username = "Helena", Password = "mypasshelena", Role="Employee"},
                new() {Id = 5, Username = "Deassis", Password = "mypassdeassis", Role="Employee"}
            };

            // return users.Where(x: User => x.Username.ToLower() == username.ToLower() && x.Password == password);
            // return users.FirstOrDefault(x: User => x.Username == username && x.Password == password);

            return users.Find(x => x.Username.ToLower().Contains(username.ToLower()) && x.Password.Contains(password));
        }
    }
}