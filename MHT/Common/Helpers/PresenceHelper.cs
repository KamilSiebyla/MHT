using Microsoft.Graph;

namespace MHT.Common.Helpers
{
    public static class PresenceHelper
    {
        public static string ResolvePresence(User user)
        {
            switch (user.Presence.Activity)
            {
                case "Offline":
                case "Inactive":
                case "PresenceUnknown":
                    {
                        return "border-gray";
                    }
                case "Online":
                case "Available":
                    {
                        return "border-success";
                    }
                case "Busy":
                case "InACall":
                case "InAConferenceCall":
                case "InAMeeting":
                case "DoNotDisturb":
                case "Presenting":
                case "UrgentInterruptionsOnly":
                    {
                        return "border-danger";
                    }
                case "BeRightBack":
                case "Away":
                    {
                        return "border-warning";
                    }
                case "OutOfOffice":
                case "OffWork":
                    {
                        return "border-purple";
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
    }
}
