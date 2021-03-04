﻿using Cv.Models;
using Cv.Models.Enums;
using System.Collections.Generic;

namespace Cv.Repository.Interface
{
    public interface IUserRepository
    {
        public void Insert(UserModel entity);
        public bool Replace(UserModel entity);
        public bool Delete(string userId);
        public UserModel GetBy(string userId);
        public UserModel GetBy(string email, string password);
        public List<UserModel> GetBy(string companyId, LinesEnum lines, string name = null);
        public long GetCount(string companyId, string name = null);
    }
}