using System;
using System.Collections.Generic;

namespace InventoryDesignTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //初始化一个游戏资产的资源池
            GamePropModel resourceModel = new GamePropModel();
            //创建一个超市类;
            SuperMarket bigRunFaSuperMarket = new SuperMarket(resourceModel.GetGameItemDictPool(), 4 * 4, 64);
            //从GameItem资源池送一些货物给超市
            bigRunFaSuperMarket.AddGameItemById(0);
            bigRunFaSuperMarket.AddGameItemById(0);
            bigRunFaSuperMarket.AddGameItemById(1);
            bigRunFaSuperMarket.AddGameItemById(0);
            //获取一下大润发超市现在的商品情况,打印出来
            List<InventoryGridInfo> result = bigRunFaSuperMarket.GetInventoryStatus();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].id != -1)
                {
                    Console.WriteLine($"商品ID：{result[i].id}数量：{result[i].count} 商品名字：{bigRunFaSuperMarket.FindGameItemById(result[i].id).itemName}");
                    Console.WriteLine($"商品描述:{bigRunFaSuperMarket.FindGameItemById(result[i].id).itemDes}");
                }
            }
            //删除大润发超市里面的几件物品，再打印一下结果
            bigRunFaSuperMarket.RemoveGameItemById(0);
            bigRunFaSuperMarket.RemoveGameItemById(0);
            bigRunFaSuperMarket.RemoveGameItemById(1);
            bigRunFaSuperMarket.RemoveGameItemById(1);
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].id != -1)
                {
                    Console.WriteLine($"商品ID：{result[i].id}数量：{result[i].count} 商品名字：{bigRunFaSuperMarket.FindGameItemById(result[i].id).itemName}");
                    Console.WriteLine($"商品描述:{bigRunFaSuperMarket.FindGameItemById(result[i].id).itemDes}");
                }
            }
        }
    }

    public class SuperMarket : AbstractInventory
    {
        public SuperMarket(Dictionary<int, GameItem> gameItemPool, int gridSize, int perGridSize) : base(gameItemPool, 4, 4,perGridSize)
        {
        }
        
    }
}