namespace RecipesShare.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UsersRoles { get; set; } = new List<UserRole>();
    }
}
