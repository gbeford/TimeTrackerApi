namespace TimeTrackerAPI.Models
{
    public class AppUserAuth
    {
        public AppUserAuth() : base()
        {
            UserName = "Not authorized";
            BearerToken = string.Empty;

        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool CanAccess_Student { get; set; }
        public bool CanAccess_Admin { get; set; }


    }
}