namespace MHT.Common.Helpers
{
    public static class DateHelper
    {
        public static string FormatDate(string dateAsString)
        {
            DateTime date = DateTime.Parse(dateAsString);
            string formattedDate = date.ToString("dd-MM-yyyy:HH:mm");
            
            return formattedDate;
        }
    }
}
