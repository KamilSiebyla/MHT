namespace MHT.Common.Helpers
{
    public static class StylingHelper
    {
        public static string ResolveEventsBorder(string startDateAsString)
        {
            double timeDiff = (DateTime.Parse(startDateAsString) - DateTime.Now).TotalDays;

            if (timeDiff < 1)
            {
                return "border-danger";
            }
            else if (timeDiff >= 1 && timeDiff <= 2)
            {
                return "border-warning";
            }
            else
            {
                return "border-success";
            }
        }
    }
}
