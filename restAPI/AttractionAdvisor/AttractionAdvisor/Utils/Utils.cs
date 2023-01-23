using AttractionAdvisor.Models;

namespace AttractionAdvisor.Utils
{
    public class Utils
    {

        public static bool validateUser(User user)
        {

            if (user.UserName == "")
            {
                return false;
            }
            if (user.Password == "")
            {
                return false;
            }
            return true;


        }
    }
}
