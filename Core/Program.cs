using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {

            #region C#6.0 语法
            int age = 90;
            Console.WriteLine($"年龄:{age}");

            //空值运算符 不需要判断是否为空
            string temp = "324324";
            Console.WriteLine(temp?.ToString());


            //索引
            var dic = new Dictionary<int, string>()
            {
                [1] = "1#", //这里代表索引 
                [2] = "1#"                
            };

            //异常过滤器
            try
            {
              
            }
            catch (Exception ex) when(ex.Source=="xxx") //当满足ex.source=xxx时 才执行Catch里面的代码 
            {
                throw ex;   //return 导致整个方法的结束             
            }





            #endregion
            #region C#7.0语法
            object obj=2;
            if (!(obj is int i))return;           
            Console.WriteLine(new string('*',i));

            //元组 Tuple 一个方法可以返回多个值

            //数字分隔符
            int Money = 10_0000; //<===>int Money=100000;
            Console.WriteLine($"我有人民币{Money}元");
            #endregion


            Address address = Address.CreateAddress("China", "000000", "Shenzhen", "LongGang", Constants.Roles.Administrator, 98,DateTime.Now);




            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            //【如果设置serializerSettings】 打印出来的结果为【{"Country":"China","PostCode":"000000","Street":"LongGang","StreetNumber":"90006","Floor":98}】
            //【如果没有设置serializerSettings】打印出来的结果为{"Country":"China","PostCode":"000000","Street":"LongGang","StreetNumber":"90006","Floor":98}
            string addressString = JsonConvert.SerializeObject(address); 
            Console.WriteLine(addressString);
            var a= JsonConvert.DeserializeObject<Address>(addressString);
            Console.WriteLine($"城市:{a.City}");








            Console.ReadKey();
        }


    }



    /*
     * 加上jsonproperty的才会被初始化
     */


    public class Address
    {
        protected Address() { }

        [JsonProperty]
        public string Country { get; private set; } = "China"; //C#6.0才有的新特性

        [JsonProperty]
        public string PostCode { get; private set; }

        [JsonIgnore] //在进行序列化的时候 null
        public string City { get; private set; }

        [JsonProperty]
        public string Street { get; private set; }

        [JsonProperty]
        public string StreetNumber { get; private set; }
        public int? Floor { get; private set; }

        [JsonConverter(typeof(ChinaDateTimeConcerter))]
        public DateTime BuildTime { get; private set; }
        public static Address CreateAddress(string Country, string PostCode, string City, string Street, string StreetNumber, int? Floor,DateTime BuildTime)
        {
            return new Address { Country = Country, PostCode = PostCode, City = City, Street = Street, StreetNumber = StreetNumber, Floor = Floor,BuildTime=BuildTime};
        }


        /*
         * public static implicit 目标类型(被转化类型 变量参数)
         *{
         *   return 目标类型结果;
         *}
         *public static explicit 目标类型(被转化类型 变量参数)
         *{
         *   return 目标类型结果;
         *}
         */

        public static explicit operator Address(string address)
        {
            var result = JsonConvert.DeserializeObject<Address>(address);
            return Address.CreateAddress(
                result.Country,
                result.PostCode,
                result.City,
                result.Street,
                result.StreetNumber,
                result.Floor,
                result.BuildTime=DateTime.Now);
        }


        //在属性/方法里使用lamd表达式
        public string fansjay => string.Format("this is fansjay {0}",0);
        public void SayHello() => Console.WriteLine("hello 我是LAMD表达式方法");
        //元组 要NUGET一个包 system.valueTuple
        private (string,int,string)LookupName(int AccountID)
        {
            return ("a",100,"b");
        }

        private (string name,int age,string sex) LookupNameTwo(int AccountID)
        {
            return (name: "", age: 28, sex: "");
        }

    }


    public class ChinaDateTimeConcerter : DateTimeConverterBase
    {
        private static IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };
        private static IsoDateTimeConverter dtLongConverter=new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return dtLongConverter.ReadJson(reader, objectType, existingValue, serializer);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            dtLongConverter.WriteJson(writer, value, serializer);
        }
    }


}
