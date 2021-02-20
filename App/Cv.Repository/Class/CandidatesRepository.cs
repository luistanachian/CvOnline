using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
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
                return candidatesDao.Replace(c => c.CandidateId == candidate.CandidateId, candidate) > 0;
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
                return candidatesDao.Delete(c => c.CandidateId == id) > 0;
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
                return candidatesDao.GetOneByFunc(c =>
                c.CompanyId == companyId &&
                c.CandidateId == candidateId);
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
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                name = name?.Trim();
                
                return candidatesDao.GetListByFunc(c =>
                    c.CompanyId == companyId &&
                    (status == null || c.Status == status) &&
                    (string.IsNullOrWhiteSpace(name) ||
                        (c.Name.Contains(name) ||
                        c.LastName.Contains(name) ||
                        $"{c.Name} {c.LastName}".Contains(name) ||
                        $"{c.LastName} {c.Name}".Contains(name))) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId)
                , top)
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.Name)
                    .ToList();
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
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                if (skills == null || skills.Count == 0)
                    return null;

                return candidatesDao.GetListByFunc(c =>
                    c.CompanyId == companyId && 
                    (status == null || c.Status == status) &&
                    (c.ListSkills.Select(s => s.Skill).All(s => skills.Any(sks => sks == s))) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId)
                , top)
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.Name)
                    .ToList();
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
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                name = name?.Trim();

                return candidatesDao.GetCount(c =>
                c.CompanyId == companyId &&
                (status == null || c.Status == status) &&
                (string.IsNullOrWhiteSpace(name) ||
                    (c.Name.Contains(name) ||
                    c.LastName.Contains(name) ||
                    $"{c.Name} {c.LastName}".Contains(name) ||
                    $"{c.LastName} {c.Name}".Contains(name))) &&
                (countryId == null || c.CountryId == countryId) &&
                (stateId == null || c.StateId == stateId));
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
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
        {
            try
            {
                if (skills == null || skills.Count == 0)
                    return 0;

                return candidatesDao.GetCount(c =>
                c.CompanyId == companyId &&
                (status == null || c.Status == status) &&
                (c.ListSkills.Select(s => s.Skill.Trim()).All(s => skills.Any(sks => sks == s))) &&
                (countryId == null || c.CountryId == countryId) &&
                (stateId == null || c.StateId == stateId));
            }
            catch (Exception)
            {
                //TODO loguear
                return 0;
            }
        }
    }
}