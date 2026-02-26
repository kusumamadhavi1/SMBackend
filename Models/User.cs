namespace StudentPR.Models
{
    public class User
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public string PasswordHash { get; set; }   // ✅ STRING
    }
}
