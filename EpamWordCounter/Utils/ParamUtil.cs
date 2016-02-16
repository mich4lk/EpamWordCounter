﻿namespace EpamWordCounter.Utils
{
    public static class ParamUtil
    {
        public static bool CheckParams(string[] args, out string message)
        {
            message = string.Empty;

            if (args == null || args.Length != 1)
            {
                message = "No sentence provided";
                return false;
            }
            
            return true;
        }
    }
}
