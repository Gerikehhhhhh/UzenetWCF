using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetWCF.Models;
using UzenetWCF.Services;

namespace UzenetWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UzenetService : IUzenetService
    {
        public string DeleteUzenet(int id)
        {
            return new UzenetService().DeleteUzenet(id);
        }

        public List<Uzenet> GetAllUzenet()
        {
            List<Uzenet> UzenetList = new List<Uzenet>();
            List<UzenetId> idList = new UzenetService().Read();

            foreach (var item in idList)
            {
                UzenetList.Add((Uzenet)item);
            }

            return UzenetList;
        }

        public string PostUzenet(Uzenet Uzenet)
        {
            return new UzenetService().Create(Uzenet);
        }

        public string PutUzenet(Uzenet Uzenet)
        {
            return new UzenetService().Update(Uzenet);
        }
    }
}
