using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsGUI
{
    internal class UserSession
    {
        public static bool IsLoggedIn { get; private set; }
        public static int AgentId { get; private set; }
        public static string? Email { get; private set; }
        public static bool IsAdmin { get; private set; }

        public static void Login(int agentId, string email, bool isAdmin)
        {
            IsLoggedIn = true;
            AgentId = agentId;
            Email = email;
            IsAdmin = isAdmin;
        }

        public static void Logout()
        {
            IsLoggedIn = false;
            AgentId = 0;
            Email = null;
            IsAdmin = false;
        }

        public static UserSessionDetails GetCurrentSession()
        {
            return new UserSessionDetails
            {
                AgentId = AgentId,
                Email = Email,
                IsAdmin = IsAdmin
            };
        }
    }

    public class UserSessionDetails
    {
        public int AgentId { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
