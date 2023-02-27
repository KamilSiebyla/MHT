using Microsoft.Graph;
using System.Security.Claims;

namespace MHT.Infrastructure.Providers
{
    public static class GraphClaimTypes
    {
        public const string DateFormat = "graph_dateformat";
        public const string Email = "graph_email";
        public const string Photo = "graph_photo";
        public const string TimeZone = "graph_timezone";
        public const string TimeFormat = "graph_timeformat";
    }

    public static class GraphClaimsPrincipalExtensions
    {
        public static string GetUserGraphDateFormat(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindFirst(GraphClaimTypes.DateFormat);
            return claim == null ? string.Empty : claim.Value;
        }

        public static string GetUserGraphEmail(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindFirst(GraphClaimTypes.Email);
            return claim == null ? string.Empty : claim.Value;
        }

        public static string GetUserGraphPhoto(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindFirst(GraphClaimTypes.Photo);
            return claim == null ? string.Empty : claim.Value;
        }

        public static string GetUserGraphTimeZone(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindFirst(GraphClaimTypes.TimeZone);
            return claim == null ? string.Empty : claim.Value;
        }

        public static string GetUserGraphTimeFormat(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindFirst(GraphClaimTypes.TimeFormat);
            return claim == null ? string.Empty : claim.Value;
        }

        public static void AddUserGraphInfo(this ClaimsPrincipal claimsPrincipal, User user)
        {
            var identity = claimsPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
            {
                throw new AuthenticationException(new Error
                {
                    Message = "ClaimsIdentity is null inside provided ClaimsPrincipal"
                });
            }

            identity.AddClaim(
                new Claim(GraphClaimTypes.DateFormat,
                    user.MailboxSettings?.DateFormat ?? "MMMM dd, yyyy"));
            identity.AddClaim(
                new Claim(GraphClaimTypes.Email,
                    user.Mail ?? user.UserPrincipalName));
            identity.AddClaim(
                new Claim(GraphClaimTypes.TimeZone,
                    user.MailboxSettings?.TimeZone ?? "UTC"));
            identity.AddClaim(
                new Claim(GraphClaimTypes.TimeFormat,
                    user.MailboxSettings?.TimeFormat ?? "HH:mm"));
        }

        public static void AddUserGraphPhoto(this ClaimsPrincipal claimsPrincipal, Stream photoStream)
        {
            var identity = claimsPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
            {
                throw new AuthenticationException(new Error
                {
                    Message = "ClaimsIdentity is null inside provided ClaimsPrincipal"
                });
            }

            if (photoStream != null)
            {
                var memoryStream = new MemoryStream();
                photoStream.CopyTo(memoryStream);
                var photoBytes = memoryStream.ToArray();

                var photoUri = $"data:image/png;base64,{Convert.ToBase64String(photoBytes)}";

                identity.AddClaim(
                    new Claim(GraphClaimTypes.Photo, photoUri));
            }
        }
    }
}

