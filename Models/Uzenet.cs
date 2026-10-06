using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace UzenetWCF.Models
{
    [DataContract]
    public class Uzenet: UzenetId
    {
        [DataMember]
        public string Szoveg { get; set; }
        [DataMember]
        public DateTime KuldesiIdo { get; set; }
        [DataMember]
        public string Uzenettipus { get; set; }
        [DataMember]
        public string Telefon { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}