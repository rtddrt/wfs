using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Core
{
    public class TreeHelper
    {
        /// <summary>
        /// 递归生成无限层级树，
        /// 通过某一结点无限查找
        /// </summary>
        /// <param name="simpleData">简单树数据</param>
        /// <param name="currentItem">起始节点</param>
        public static void GenerateTree(List<Tree> simpleData, Tree currentItem)
        {
            var itemTree = simpleData.Where(x => x.PId == currentItem.Id).ToList();
            currentItem.Children = new List<Tree>();
            currentItem.Children.AddRange(itemTree);

            foreach (var item in itemTree)
            {
                GenerateTree(simpleData, item);
            }
        }

        /// <summary>
        /// 反射产生无限层级树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="simpleData">简单数数据</param>
        /// <param name="currentItem">起始节点</param>
        /// <param name="primaryId">主键节点名称</param>
        /// <param name="childrenName">孩子数组名称</param>
        /// <param name="parentId">父节点名称</param>
        public static void GenerateTree<T>(List<T> simpleData, T currentItem, string primaryId = "Id", string childrenName = "children", string parentId = "PId") where T : class
        {
            var itemTree =
                simpleData.Where(
                    x =>
                        x.GetType().GetProperty(parentId).GetValue(x, null).ToString() ==
                        currentItem.GetType().GetProperty(primaryId).GetValue(currentItem, null).ToString()).ToList();
            currentItem.GetType().GetField(childrenName).SetValue(currentItem, itemTree);
            foreach (var item in itemTree)
            {
                GenerateTree(simpleData, item);
            }
        }

        /// <summary>
        /// 无限级树,约定必须包含 Id,PId
        /// </summary>
        /// <param name="simpleData"></param>
        /// <param name="currentItem"></param>
        public static void GenerateTree(List<dynamic> simpleData, dynamic currentItem,string id="id",string parentId="pid",string children="children")
        {
            var list = simpleData.Where(x => x.PId == currentItem.Id).ToList();
        }
    }

    public class Tree
    {
        /// <summary>
        /// 树主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 树主键父母
        /// </summary>
        public string PId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public string Spread { get; set; }

        /// <summary>
        /// children
        /// </summary>
        public List<Tree> Children { get; set; }
    }
}
