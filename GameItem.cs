namespace InventoryDesignTest
{
    public class GameItem
    {
        public int id;//物品的唯一标识
        public string itemName;//物品的名字
        public string itemDes;//物品的描述
        public GameItem(int id, string itemName, string itemDes)
        {
            this.id = id;
            this.itemName = itemName;
            this.itemDes = itemDes;
        }
    }
}