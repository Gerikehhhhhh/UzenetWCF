using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UzenetWCF.Models
{
    [DataContract]
    public class UzenetId
    {
        [DataMember]
        public int Id { get; set; }
    }
}