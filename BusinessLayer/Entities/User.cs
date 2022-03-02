using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class User
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string ConnectionId { get; set; }
        public string SMSReciver { get; set; }

        public User()
        {

        }

        public User(int? id=null, string name=null, string message=null, string connectionId=null,string smsReciver=null)
        {
            this.ID = id;
            this.Name = name;
            this.Message = message;
            this.ConnectionId = connectionId;
            this.SMSReciver = smsReciver;
        }

    }
}
