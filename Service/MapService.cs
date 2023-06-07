namespace Gazenergokomplekt.Service
{
    public class MapService
    {
        static string Controller = "";
        public MapService()
        {

        }
        public void SetName(string name)
        {
            switch (name)
            {
                case "Home":
                    Controller = "Home";
                    break;
                case "Admin":
                    Controller = "Admin";
                    break;
                case "Orders":
                    Controller = "Orders";
                    break;
                default:
                    Controller = "Home";
                    break;
            }
        }
        public string ReturnName()
        {
            return Controller;
        }
    }
}
