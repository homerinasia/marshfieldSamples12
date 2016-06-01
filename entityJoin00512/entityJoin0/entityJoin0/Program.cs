using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace entityJoin0
{
    class Program
    {
        static void Main(string[] args)
        {
            pubsEntities DBContext = new pubsEntities();
            

            var cheapBook = DBContext.titles.First(e => e.price == (decimal)2.99);
            //FROM [dbo].[titles] AS [Extent1]
            //WHERE 2.99 = [Extent1].[price]
            
            //cheapBook = DBContext.titles.First(e => e.title_id == "bu1032");
            //FROM [dbo].[titles] AS [Extent1]
            //WHERE N'bu1032' = [Extent1].[title_id]            

            //var test0 = from t in DBContext.titles
                       //where t.title_id == "bu1032"
                       //select t;
            // query doesnt get executed til i call tolist()

            //var data = test0.ToList();
            //FROM [dbo].[titles] AS [Extent1]
            //WHERE N'bu1032' = [Extent1].[title_id]

            //var test1 = from t in DBContext.titles
            //            join p in DBContext.publishers
            //            on t.pub_id equals p.pub_id
            //            where t.title_id == "bu1032"
            //            select p;

            //test1.ToList();
            ////SELECT 
            ////[Extent2].[pub_id] AS [pub_id], 
            ////[Extent2].[pub_name] AS [pub_name], 
            ////[Extent2].[city] AS [city], 
            ////[Extent2].[state] AS [state], 
            ////[Extent2].[country] AS [country]
            ////FROM  [dbo].[titles] AS [Extent1]
            ////INNER JOIN [dbo].[publishers] AS [Extent2] ON [Extent1].[pub_id] = [Extent2].[pub_id]
            ////WHERE N'bu1032' = [Extent1].[title_id]
            //// note that this is pretty optimized. there is no 'titles' in the select clause

            //var test2 = from t in DBContext.titles
            //            join p in DBContext.publishers
            //            on t.pub_id equals p.pub_id
            //            where t.title_id == "bu1032"
            //            select new { p.pub_name, t.title1, t.price };

            //test2.ToList();
            //SELECT 
            //1 AS [C1], 
            //[Extent2].[pub_name] AS [pub_name], 
            //[Extent1].[title] AS [title], 
            //[Extent1].[price] AS [price]
            //FROM  [dbo].[titles] AS [Extent1]
            //INNER JOIN [dbo].[publishers] AS [Extent2] ON [Extent1].[pub_id] = [Extent2].[pub_id]
            //WHERE N'bu1032' = [Extent1].[title_id]

            //var test3 = from t in DBContext.titles
            //            where t.price == (decimal)7.99
            //            select new { t.price };

            //test3.ToList();
            // there is a nc index on price and the exec plan is a covered query :) 

            //sqlquery method
            //string sql = "select * from publishers where state='ca'";
            //var capubs = DBContext.publishers.SqlQuery(sql).ToList();
            //var sales = DBContext.sales.SqlQuery("select * from sales").ToList();
            //string uglysql = "select title_id, title as title1,pub_id, type, price, royalty,advance, ytd_sales, pubdate from titles where price between 10 and 12";
            //var books = DBContext.titles.SqlQuery(uglysql).ToList();

            // exectesqlcommand            
            //DBContext.Database.ExecuteSqlCommand("update titles set title='newer book' where title_id = 'bu1032'");
            //DBContext.Database.ExecuteSqlCommand("updatebookinfo bu1032, 'new title..'");
            //var param0 = new SqlParameter("title_id", "bu1032");
            //var param1 = new SqlParameter("newtitle", DateTime.Now.ToLongTimeString());
            //DBContext.Database.ExecuteSqlCommand
            //    ("updatebookinfo @title_id, @newtitle", param0, param1);

            ////objectcontext and entity sql
            //var context = ((IObjectContextAdapter)DBContext).ObjectContext;
            //string eSql = "select value publisher from pubsEntities.publishers as publisher";
            //ObjectQuery<publisher> pq = new ObjectQuery<publisher>(eSql, context);
            //string executedcommands = pq.ToTraceString();
            //pq.ToList();

            var book = DBContext.titles.Find("bu1032");
            book.pubdate = DateTime.Now;
            DBContext.SaveChanges();
            
        }
    }
}
