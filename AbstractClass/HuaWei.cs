using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class HuaWei : BasePhone
    {
        public override string Brand()
        {
            return "华为";
        }

        public override string Call()
        {
            return "华为手机正在拔打电话";
        }

        public override string System()
        {
            return "华为手机系统为Android";
        }

        public override string TakePhoto()
        {
            return "华为手机正在拍照";
        }
    }
}
