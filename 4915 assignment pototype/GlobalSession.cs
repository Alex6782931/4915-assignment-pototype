using System;
using SDP_EntityModels;

namespace _4915_assignment_pototype // Note the .login1 at the end
{
    public static class GlobalSession
    {
        public static Staff CurrentUser { get; set; }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}