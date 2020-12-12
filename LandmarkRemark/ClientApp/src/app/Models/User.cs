
public class Interface
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; } // Not handling security correctly as it is out of scope.
    }
}
