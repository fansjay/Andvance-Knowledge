using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WebWCFService
{
    
    [DataContract]
    public class User
    {
        public int ID { get; set; }
        
        [DataMember]
        public string Username { set; get; }
        [DataMember]
        public DateTime RegisterTime { set; get; } = DateTime.Now;

        public User() { }

        public User(int ID,string Username,DateTime RegisterTime)
        {
            this.ID = ID;
            this.Username = Username;
            this.RegisterTime = RegisterTime;            
        }
    }


    public class Student
    {
        public Student(){}

        public Student(int iD, string username, string major)
        {
            ID = iD;
            Username = username;
            Major = major;
        }

        public int ID { get; set; }
        public string Username { set; get; }

        /// <summary>
        /// 主修
        /// </summary>
        public string Major { set; get; }
    }
}