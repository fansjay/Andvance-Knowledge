using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Iphone : Phone,IPay
    {
        public override string Brand()
        {
            return "Iphone";
        }

        public override bool FaceRecgonize()
        {
            return true;
        }

        public override string Call()
        {
            return "Iphone正在打电话";
        }

        public string Paying()
        {
            return "Iphone正在付款买东西";
        }

        public override string System()
        {
            return "Iphone系统为IOS";
        }

        public override string TakePhoto()
        {
            return "Iphone正在拍照";
        }

        public string SendPhotoToMac()
        {
            return "Iphone正在发送照片到MAC上";
        }
    }
}
