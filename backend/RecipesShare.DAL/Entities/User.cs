namespace RecipesShare.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public ICollection<UserRole> UsersRoles { get; set; } = new List<UserRole>();
    }
}
