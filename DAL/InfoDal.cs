using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace DAL
{
    public class InfoDal
    {
        /// <summary>
        /// 数据库链接类
        /// </summary>
        private BLOGEntities bLOG = new BLOGEntities();
        /// <summary>
        /// 文章插入函数
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="introduce">介绍</param>
        /// <param name="context">内容</param>
        public void Insert(string title, string introduce, string context)
        {
            Info info = new Info() { Title = title, Introduce = introduce, Context = context ,Date=DateTime.Now};
            try
            {
                bLOG.Infoes.Add(info);
                bLOG.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// 删除函数
        /// </summary>
        /// <param name="id">记录ID</param>
        public void Delete(int id)
        {
            Info info = new Info()
            {
                ID = id
            };
            try
            {
                bLOG.Infoes.Attach(info);
                bLOG.Infoes.Remove(info);
                bLOG.SaveChanges();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// 按页全部查找
        /// </summary>
        /// <param name="page">页数</param>
        /// <returns></returns>
        public List<Info> GetInfoAll(int page,bool flag)
        {
            List<Info> list = null;
            try
            {
                if (flag)
                {
                    list = bLOG.Infoes.OrderBy(p => p.ID).Skip(page * 10).Take(10).ToList();
                    return list;
                }
                else
                {
                    list = bLOG.Infoes.OrderBy(p => p.Count).Skip(page * 10).Take(10).ToList();
                    return list;
                }
              
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return list;
            }
        }
        /// <summary>
        /// 返回所有记录总数
        /// </summary>
        /// <returns></returns>
        public int GetAllNums()
        {
            int num = 0;
            try
            {
                num = bLOG.Infoes.Count();
                return num;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return num;
            }
        }
        /// <summary>
        /// 按ID返回记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Info FindID(int id)
        {
            try
            {
                var info = (from p in bLOG.Infoes where p.ID == id select p).FirstOrDefault();
                return info;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// 查找标题并返回
        /// </summary>
        /// <param name="title">关键字</param>
        /// <param name="page">页数</param>
        /// <returns></returns>
        public List<Info> GetTitle(string title,int page)
        {
            List<Info> list = null;
            try
            {
                    list = bLOG.Infoes.Where(p => p.Title.IndexOf(title) >= 0).OrderBy(p => p.ID).Skip(page * 10).Take(10).ToList();
                    return list;        
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// 返回查找标题总数
        /// </summary>
        /// <param name="title">关键字</param>
        /// <returns></returns>
        public int GetTitleNums(string title)
        {
            int num = 0;
            try
            {
                num = bLOG.Infoes.Where(p => p.Title.IndexOf(title) >= 0).Count();
                return num;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return num;
            }
        }
    }
}
