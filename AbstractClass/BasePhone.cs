using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{

    /*
     * 抽象类：所有的共性
     * 接口：所有手机都可以拍照 打电话 但有的手机可以TouchID付款
     */
    public abstract  class BasePhone
    {

        //四大功能
        public abstract string Brand();
        public abstract string Call();
        public abstract string TakePhoto();
        public abstract string System();
        public BasePhone()
        {
            Console.WriteLine("我是普通方法");
        }
        /// <summary>
        /// 虚方法你可以实现也可以不实现
        /// </summary>
        /// <returns></returns>

        public virtual bool FaceRecgonize()
        {
            return false;
        }

        public string SayHello()
        {
            return "SayHello";
        }

    }


    public class Phone : BasePhone
    {
        public override string Brand()
        {
            throw new NotImplementedException();
        }

        public override string Call()
        {
            throw new NotImplementedException();
        }

        public override string System()
        {
            throw new NotImplementedException();
        }
        public override string TakePhoto()
        {
            throw new NotImplementedException();
        }
        public new string SayHello() //如果是父类中有方法的时候子类最好写一个new才可以
        {
            return "Child SayHello";
        }
        
        

    }
}
