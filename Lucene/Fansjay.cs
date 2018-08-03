using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Tokenattributes;
using System;
using System.IO;

namespace Lucene
{
    public class Fansjay
    {
        public Fansjay()
        {

        }

        public static void Initstance(string SearchContent)
        {
            PanGu.Segment.Init("fansjay.xml");
            PanGu.Segment segment = new PanGu.Segment();



            //ICollection<WordInfo> words = segment.DoSegment(SearchContent, options, parameters);



            StandardAnalyzer standardAnalyzer = new StandardAnalyzer(Net.Util.Version.LUCENE_30);
            
            Console.WriteLine($"Lucene分词结果【英文】: {SerperateKeyWord("I love have apples", standardAnalyzer)}");
            Console.WriteLine($"Lucene分词结果【中文】: {SerperateKeyWord("我爱吃苹果呀", standardAnalyzer)}");
        }


        /// <summary>
        /// 把搜索关键字分词方法
        /// </summary>
        /// <param name="KeyWord">待分词</param>
        /// <param name="analyzer"></param>
        /// <returns></returns>
        private static string SerperateKeyWord(string KeyWord,Analyzer analyzer)
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
