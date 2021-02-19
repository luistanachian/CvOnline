using Cv.Dao.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Repository.Class
{
    public sealed class CandidatesRepository : ICandidatesRepository
    {
        private readonly ICandidatesDao candidatesDao;
        public CandidatesRepository(ICandidatesDao candidatesDao)
        {
            this.candidatesDao = candidatesDao;
        }
        public bool Insert(CandidateModel candidate)
        {
            try
            {
                candidatesDao.Insert(candidate);
                return true;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }
        public bool Replace(CandidateModel candidate)
        {
            try
            {
                var result = candidatesDao.Replace(c => c.CandidateId == candidate.CandidateId, candidate);
                return result > 0;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var result = candidatesDao.Delete(c => c.CandidateId == id);
                return result > 0;
            }
            catch (Exception)
            {
                //TODO loguear
                return false;
            }
        }
        public CandidateModel GetBy(string companyId, string candidateId)
        {
            try
            {
                var result = candidatesDao.GetOneByFunc(c =>
                c.CompanyId == companyId &&
                c.CandidateId == candidateId);

                return result;
            }
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }

        public List<CandidateModel> GetBy(
            string companyId,
            int top,
            string name = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                var result = candidatesDao.GetListByFunc(c =>
                    c.CompanyId == companyId &&
                    (string.IsNullOrWhiteSpace(name) ||
                        (c.Name.Contains(name) ||
                        c.LastName.Contains(name) ||
                        $"{c.Name} {c.LastName}".Contains(name) ||
                        $"{c.LastName} {c.Name}".Contains(name))) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId)
                , top);
                return result.OrderBy(c => c.LastName).ThenBy(c => c.Name).ToList();
            }
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }
        public List<CandidateModel> GetBy(
            string companyId,
            int top,
            List<string> skills,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                var result = candidatesDao.GetListByFunc(c =>
                    c.CompanyId == companyId &&
                    (c.ListSkills.Select(s => s.Skill).All(s => skills.Any(sks => sks == s))) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId)
                , top);
                return result.OrderBy(c => c.LastName).ThenBy(c => c.Name).ToList();
            }
            catch (Exception)
            {
                //TODO loguear
                return null;
            }
        }

        public long GetCount(
            string companyId,
            string name = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                var result = candidatesDao.GetCount(c =>
                c.CompanyId == companyId &&
                (string.IsNullOrWhiteSpace(name) ||
                    (c.Name.Contains(name) ||
                    c.LastName.Contains(name) ||
                    $"{c.Name} {c.LastName}".Contains(name) ||
                    $"{c.LastName} {c.Name}".Contains(name))) &&
                (countryId == null || c.CountryId == countryId) &&
                (stateId == null || c.StateId == stateId));

                return result;

            }
            catch (Exception)
            {
                //TODO loguear
                return 0;
            }
        }
        public long GetCount(
            string companyId,
            List<string> skills,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                var result = candidatesDao.GetCount(c =>
                c.CompanyId == companyId &&
                (c.ListSkills.Select(s => s.Skill).All(s => skills.Any(sks => sks == s))) &&
                (countryId == null || c.CountryId == countryId) &&
                (stateId == null || c.StateId == stateId));

                return result;
            }
            catch (Exception)
            {
                //TODO loguear
                return 0;
            }
        }
    }
}