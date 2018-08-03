using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucene
{
    public  class Article
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string  Content { get; set; }

        public  DateTime PublishDateTime { set; get; }
    }
}
