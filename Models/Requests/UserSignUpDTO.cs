namespace FoodAppAPI.Models.Requests
{
    public class UserSignUpDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Coordinate { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;

    }
}
