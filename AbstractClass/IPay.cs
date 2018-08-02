using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public  interface IPay
    {
        /// <summary>
        /// 手机付款功能
        /// </summary>
        /// <returns></returns>
        string Paying();

        string SendPhotoToMac();
       
    }
}
