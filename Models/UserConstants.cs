namespace FoodAppAPI.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                Username = "admin",
                Email = "admin@example.com",
                Password = "admin",
                FirstName = "John",
                LastName = "Doe",
                Role = "Administrator"
            }
        };
    }
}
