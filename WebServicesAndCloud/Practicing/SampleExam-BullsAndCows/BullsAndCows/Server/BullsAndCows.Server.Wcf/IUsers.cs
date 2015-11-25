namespace BullsAndCows.Server.Wcf
{
    using BullsAndCows.Server.Wcf.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        [WebInvoke(Method="Get",  UriTemplate="services/users.svc")]
        IEnumerable<ListedUserMember> GetAll(string page);

        [OperationContract]
        [WebInvoke(Method = "Get", UriTemplate = "services/users/{id}.svc")]
        DetailedUserModel GetById(string id);
    }
}
