namespace RateYourIdea.Core.BaseModels
{
    public class UserInfo
    {
        public UserInfo()
        {

        }

        public UserInfo(int ID, string UserName, string FirstName, string LastName)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
