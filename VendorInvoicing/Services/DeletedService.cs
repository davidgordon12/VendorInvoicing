namespace VendorInvoicing.Services
{
    public class DeletedService
    {
        private static Dictionary<string, int> deleted = new Dictionary<string, int>();

        public static void AddLastDeleted(int id)
        {
            deleted["lastDeleted"] = id;
        }

        public static int GetLastDeleted()
        {
            if (deleted.ContainsKey("lastDeleted"))
                return deleted["lastDeleted"];
            else
                return 0;
        }
    }
}
