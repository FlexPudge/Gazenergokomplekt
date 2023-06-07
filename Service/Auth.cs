namespace Gazenergokomplekt.Service
{
    public class Auth
    {
        static bool Authet { get; set; } = false;
        public Auth() { }

        public void SetAuthStatus(bool value)
        {
            Authet = value;
        }
        public bool ReturnAuthetStatus()
        {
            return Authet;
        }
    }
}
