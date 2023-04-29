namespace FoodAppAPI.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                Username = "admin",
                Email = "admin@dishdrop.pp.ua",
                Password = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Role = "Administrator"
            },
            new UserModel()
            {
                Username = "customer",
                Email = "customer@dishdrop.pp.ua",
                Password = "customer",
                FirstName = "John",
                LastName = "Doe",
                Role = "Customer"
            },
            new UserModel()
            {
                Username = "rider",
                Email = "rider@dishdrop.pp.ua",
                Password = "rider",
                FirstName = "John",
                LastName = "Smith",
                Role = "Rider"
            }
        };
    }
}
