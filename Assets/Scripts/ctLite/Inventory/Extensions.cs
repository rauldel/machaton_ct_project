using ctLite.Common;

namespace ctLite.Inventory
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the InventoryManager.
        /// </summary>
        /// <returns>InventoryManager</returns>
        public static InventoryManager Inventories(this UnityClient client)
        {
            return new InventoryManager(client);
        }
    }
}
