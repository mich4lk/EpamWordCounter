namespace EpamWordCounter.Utils
{
    public static class ParamUtil
    {
        public static bool CheckParams(string[] args, out string message)
        {
            message = string.Empty;

            if (args.Length == 1)
                return true;

            message = "No sentence provided";

            return false;
        }
    }
}
