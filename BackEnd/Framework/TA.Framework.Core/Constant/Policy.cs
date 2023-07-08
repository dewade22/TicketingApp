namespace TA.Framework.Core.Constant
{
    public class Policy
    {
        public const string Administrator = "Admin";
        public const string Guest = "Guest";
        public const string Driver = "Driver";
        public const string TravelAgent = "TravelAgent";
        public const string AllRoles = Administrator + "," + Guest + "," + Driver + "," + TravelAgent;
        public const string AdminAndTravelAgent = Administrator + "," + TravelAgent;
    }
}
