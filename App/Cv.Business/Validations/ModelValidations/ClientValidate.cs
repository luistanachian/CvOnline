using Cv.Models;

namespace Cv.Business.Validations
{
    public class ClientValidate
    {

        public static readonly Vali<ClientModel>[] Predicates =
        {
            new Vali<ClientModel>{ Validate = (c) => Validator.Guid(c.ClientId), Error = "ClientId" }
        };
    }
}
