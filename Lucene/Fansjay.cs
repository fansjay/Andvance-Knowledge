using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Tokenattributes;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Diagnostics;
using System.IO;
using static Lucene.Net.Index.IndexWriter;

namespace Lucene
{
    public class Fansjay
    {


        private static string IndexDirectory = $"{Environment.CurrentDirectory}\\IndexDirectory";

        private static string[] TitleArray=new string[] { "材料是作者在形成或表达特定主题时摄取、使用的各种信息——感知和理念", "还应提及的是，上边这个定义中“形成或表达特定主题”这个修饰性成分绝不可省，因为它揭示了材料的自身规定性——与主题的相对性或相互依存关系。", "拟制标题所依据的文章内容要素，主要有三个：一是文章的主题，二是文章的课题，三是文章的材料。", "依据课题拟制标题，就是运用简炼的语言点明文章所要研究和讨论的主要问题，以此作为文章的标题",
        "依据材料拟制标题，就是把文章中用来表现主题的主要材料的名称拿来作为标题使用。","虚实结合法这是拟制双行标题所采用的一种拟题方法","这两篇文章就都是采用这种方法拟制的标题。这种标题容量大且富于变化，使用起来灵活、方便，是一种颇具表现力的标题形式。",
        };
        public Fansjay()
        {

        }


        /// <summary>
        /// 创建Lucence索引 
        /// </summary>
        public static void Initstance()
        {
            /*
             * 第一步 ： 创建索引 【必须有索引目录】
             *      a.创建索引目录
             *      b.添加索引
             * 
             */


            //索引目录
   
            FSDirectory fSDirectory = FSDirectory.Open(IndexDirectory);
           

            //添加索引 true:如果有则删除 表示新建 单独写到一个物理文件  
            using (IndexWriter indexWriter = new IndexWriter(fSDirectory, new PanGuAnalyzer(),true, MaxFieldLength.UNLIMITED))//用USING 不需要释放资源
            {
                for (int i = 0; i < 10000; i++)
                {
                    Document document = new Document();
                    document.Add(new Field("ID",i.ToString(),Field.Store.NO,Field.Index.NOT_ANALYZED)); //ID不需要创建索引 【【不建索引】】
                    document.Add(new Field("Title", TitleArray[i%TitleArray.Length]+i, Field.Store.YES, Field.Index.ANALYZED));
                    document.Add(new Field("Content", "Content"+i.ToString(), Field.Store.NO, Field.Index.NOT_ANALYZED));
                    document.Add(new NumericField("Price",  Field.Store.YES,true).SetDoubleValue(0.00001*new Random().Next(1000000000)));
                    document.Add(new NumericField("ColTime", Field.Store.YES, true).SetIntValue(new Random().Next(20160000,20190000)));
                    indexWriter.AddDocument(document); //写到缓冲区去 到10个以后才写入物理文件中
                }
                indexWriter.Optimize();//合并                 
            }

            Console.WriteLine("------OK-------");


#if false

            StandardAnalyzer standardAnalyzer = new StandardAnalyzer(Net.Util.Version.LUCENE_30);
            /*
             * Lucene分词结果【英文】: term=i|term=love|term=have|term=apples|
             * Lucene分词结果【中文】: term=我|term=爱|term=吃|term=苹|term=果|term=呀|  
             * 从这里可以看得到如果用Lucene则是一个字一个字的拆分 中文推荐使用盘古分词
             */
            Console.WriteLine($"Lucene分词结果【英文】: {SerperateKeyWord("I love have apples", standardAnalyzer)}");
            Console.WriteLine($"Lucene分词结果【中文】: {SerperateKeyWord("我爱吃苹果呀", panGuAnalyzer)}");//???为什么
#endif
        }



        public static void QueryShow()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //查询
            FSDirectory fSDirectory = FSDirectory.Open($"{Environment.CurrentDirectory}\\IndexDirectory");
            IndexSearcher indexSearcher = new IndexSearcher(fSDirectory);//查找器

            #region TermQuery
            TermQuery termQuery = new TermQuery(new Term("Title", "主题"));
            TopDocs topDocs = indexSearcher.Search(termQuery, null, 10000);
            int i = 0;
            foreach (var item in topDocs.ScoreDocs)
            {
                Document document = indexSearcher.Doc(item.Doc);
                Console.WriteLine($"Title:{document.Get("Title")},\r\n{document.Get("Price")},\r\n{document.Get("ColTime")}");
                i++;
            }
            stopwatch.Stop();
            Console.WriteLine($"共查出结果【{i}】个,用时【{stopwatch.ElapsedMilliseconds}】毫秒");
            #endregion

            #region QueryParser
            //Title 要查询的字段
            QueryParser queryParser = new QueryParser(Net.Util.Version.LUCENE_30, "Title", new PanGuAnalyzer());
            string SearchKeyWord = "标题形式";// 查询的关键词
            Query query = queryParser.Parse(SearchKeyWord); //让系统自动给我们选择来怎么查询
            TopDocs docs = indexSearcher.Search(query, null, 10000);
            int ResultsCount = 0;
            foreach (var item in docs.ScoreDocs)
            {
                Document document = indexSearcher.Doc(item.Doc);
                Console.WriteLine($"Title:{document.Get("Title")},\r\n{document.Get("Price")},\r\n{document.Get("ColTime")}");
                ResultsCount++;
            }
            Console.WriteLine($"共查到 \'标题形式\' 的结果{ResultsCount}个");



            #endregion







        }

        /// <summary>
        /// 把搜索关键字分词方法
        /// </summary>
        /// <param name="KeyWord">待分词</param>
        /// <param name="analyzer"></param>
        /// <returns></returns>
        private  static string SerperateKeyWord(string KeyWord,Analyzer analyzer)
        {
            string ResultString = "";
            StringReader stringReader = new StringReader(KeyWord);
            TokenStream tokenStream = analyzer.TokenStream(KeyWord, stringReader);
            bool HasNext = tokenStream.IncrementToken();
            ITermAttribute termAttribute;
            while (HasNext)
            {
                termAttribute= tokenStream.GetAttribute<ITermAttribute>();
                ResultString += termAttribute + "|";
                HasNext = tokenStream.IncrementToken();
            }
            tokenStream.CloneAttributes();
            stringReader.Close();
            analyzer.Close();
            return ResultString;
        }




    }




}
