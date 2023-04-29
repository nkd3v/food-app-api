namespace FoodAppAPI.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                Id = "aaaaaaaaaaaaaaaaaaaaaaaa",
                Email = "admin@dishdrop.pp.ua",
                Username = "admin",
                Password = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Role = "Administrator"
            },
            new UserModel()
            {
                Id = "bbbbbbbbbbbbbbbbbbbbbbbb",
                Email = "customer@dishdrop.pp.ua",
                Username = "customer",
                Password = "customer",
                FirstName = "John",
                LastName = "Doe",
                Role = "Customer"
            },
            new UserModel()
            {
                Id = "cccccccccccccccccccccccc",
                Email = "rider@dishdrop.pp.ua",
                Username = "rider",
                Password = "rider",
                FirstName = "John",
                LastName = "Smith",
                Role = "Rider"
            }
        };
    }
}
