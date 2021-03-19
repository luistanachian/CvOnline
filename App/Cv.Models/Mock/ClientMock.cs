using System;
using System.Collections.Generic;

namespace Cv.Models.Mock
{
    public class ClientMock
    {
        public static readonly ClientModel ClientOk = new()
        {
            ClientId = "7a1e1935-e45a-4792-9c19-b0f3dbb43576",
            CompanyId = "7a1e1935-e45a-4792-9c19-b0f3dbb43576",
            BlackList = false,
            Name = "Ramona c.a",
            Document = "65468a43s",

            Adress = new AdressItem
            {
                CountryId = 1,
                StateId = 1,
                AdressOne = "alvear 45",
                AdressTwo = "piso 2 depto f",
                PostalCode = "5000"
            },
            Contacts = new List<ContactItem>
            {
                new ContactItem
                {
                    FullName = "loka penelope bla bla",
                    Email = "lokapenelope@bla.com",
                    Role = "TL",
                    Phone = "+543216549877"
                }
            },
            Sites = new List<string> { "https://github.com/luistanachian" },
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
