using System;
using System.Collections.Generic;

namespace InventoryDesignTest
{
    /// <summary>
    /// 抽象库存
    /// </summary>
    public abstract class AbstractInventory
    {
        public List<InventoryGridInfo> gridInfoList;//记录格子信息的List
        private int inventoryLength;//库存长度
        private int inventoryWidth;//库存宽度
        private int gridSize;//库存的格子数量
        private int perGridSize;//库存每个格子最多容纳的物品数
        private int inventorySize;//库存的总存储容量
        private readonly Dictionary<int, GameItem> gameItemPool;//GameItem资源池的引用
        protected AbstractInventory(Dictionary<int,GameItem>gameItemPool,int inventoryLength,int inventoryWidth,int perGridSize)
        {
            this.gameItemPool = gameItemPool;//引用赋值
            //构建库存网格
            this.inventoryLength = inventoryLength;
            this.inventoryWidth = inventoryWidth;
            gridSize = inventoryLength*inventoryWidth;
            this.perGridSize = perGridSize;
            inventorySize = perGridSize * gridSize;
            gridInfoList = new List<InventoryGridInfo>(gridSize);
            //库存网格构建完毕之后，初始化网格数据
            for (int i = 0; i < gridSize; i++)
            {
                var gridInfo = new InventoryGridInfo
                {
                    id=-1,
                    count = 0
                };
                gridInfoList.Add(gridInfo);
            }
        }
        #region 增删查改方法
        public void AddGameItemById(int id)
        {
            gameItemPool.TryGetValue(id, out var item);
            if (item == null)
            {
                Console.WriteLine("你添加的货物不存在！");
                return;
            }
            //遍历二维格子，找寻可放置位置
            for (int i = 0; i < gridInfoList.Count; i++)
            {
                //情况1：找到一个放置了同类物品的格子，并且该格子容量是足够的
                if (gridInfoList[i].id == id && gridInfoList[i].count < perGridSize)
                {
                    gridInfoList[i].count += 1;
                    Console.WriteLine("找到一个放置了同类物品的格子，并且该格子容量是足够的");
                    return;
                }
                //情况2：找到了一个什么都没有放置的格子
                if (gridInfoList[i].id == -1)
                {
                    gridInfoList[i].id = id;
                    gridInfoList[i].count += 1;
                    Console.WriteLine("找到了一个什么都没有放置的格子");
                    return;
                }
            }
        }
        public virtual void AddGameItemByIdToConfirmPos()
        {
            
        }
        public void RemoveGameItemById(int id)
        {
            for (int i = 0; i < gridInfoList.Count; i++)
            {
                if (gridInfoList[i].id == id && gridInfoList[i].count > 0)
                {
                    gridInfoList[i].count -= 1;
                    if (gridInfoList[i].count <= 0)
                    {
                        gridInfoList[i].id = -1;
                        Console.WriteLine($"ID为{id}的物品被清除");
                        return;
                    }
                    Console.WriteLine($"ID为{id}的物品数量-1");
                }
            }
            Console.WriteLine($"ID为{id}的物品不存在");
        }
        public virtual void RemoveGameItemByPos()
        {
            
        }
        public GameItem FindGameItemById(int id)
        {
            for (int i = 0; i < gridInfoList.Count; i++)
            {
                if (gridInfoList[i].id == id&&gridInfoList[i].count>0)
                {
                    gameItemPool.TryGetValue(id, out var item);
                    return item;
                }
            }
            Console.WriteLine($"ID为{id}的物品不存在");
            return null;
        }
        public GameItem FindGameItemByPos()
        {
            return null;
        }
        public int GetCurrentInventorySize()
        {
            int sum = 0;
            for (int i = 0; i < gridInfoList.Count; i++)
            {
                sum += gridInfoList[i].count;
            }
            return sum;
        }
        public List<InventoryGridInfo> GetInventoryStatus()
        {
            return new List<InventoryGridInfo>(gridInfoList);
        }
        public virtual void ExchangeGameItemPos()
        {
            
        }
        #endregion
    }
}