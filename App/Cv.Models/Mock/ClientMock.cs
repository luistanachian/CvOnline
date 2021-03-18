using Cv.Models.Items;
using System;
using System.Collections.Generic;

namespace Cv.Models.Mock
{
    public class ClientMock
    {
        public static readonly ClientModel ClientOk = new ClientModel
        {
            ClientId = "7a1e1935-e45a-4792-9c19-b0f3dbb43576",
            CompanyId = "7a1e1935-e45a-4792-9c19-b0f3dbb43576",
            StarDate = DateTime.Now,
            LastUpdate = DateTime.Now,
            BlackList = false,
            Name = "Ramona c.a",
            Document = "65468a43s",
            CountryId = 1,
            StateId = 1,
            AdressOne = "alvear 45",
            AdressTwo = "piso 2 depto f",
            PostalCode = "5000",
            Contacts = new List<ContactItem>
            {
                new ContactItem
                {
                    Name = "loka penelope",
                    LastName = "bla bla",
                    Email = "lokapenelope@bla.com",
                    Role = "TL",
                    Phone = "+543216549877"
                }
            },
            SitesList = new List<string> { "https://github.com/luistanachian" },
            Comments = new List<CommentItem>
                {
                    new CommentItem
                    {
                        User = "ltanachian",
                        Comment = "Lo llame y no contesto"
                    }
                }
        };
    }
}
