using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UzenetWCF.Models;

namespace UzenetWCF
{
    [ServiceContract]
    internal interface IUzenetService
    {
        [OperationContract]

        List<Uzenet> GetAllUzenet();

        [OperationContract]

        string PostUzenet(Uzenet uzenet);

        [OperationContract]

        string PutUzenet(Uzenet uzenet);

        [OperationContract]

        string DeleteUzenet(int id);
    }
}
