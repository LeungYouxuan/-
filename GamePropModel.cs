using System.Collections.Generic;
namespace InventoryDesignTest
{
    public class GamePropModel
    {
        //整个游戏的GameItem资源总量
        //每个不同的商店，库存等，货源都是来自这里
        private static Dictionary<int, GameItem> gameItemDictPool = new Dictionary<int, GameItem>();
        public GamePropModel()
        {
            //给GameItem资源池添加一些测试数据
            gameItemDictPool.Add(0,new GameItem(0,"苹果","超市买的水果"));
            gameItemDictPool.Add(1,new GameItem(1,"香蕉","超市买的香蕉"));
        }
        public Dictionary<int, GameItem> GetGameItemDictPool()
        {
            return new Dictionary<int, GameItem>(gameItemDictPool);
        }
    }
}