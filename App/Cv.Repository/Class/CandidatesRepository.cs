using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Repository.Interface;
using MongoDB.Driver;
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
        public void Insert(CandidateModel entity) => candidatesDao.Insert(entity);

        public bool Replace(CandidateModel entity) =>
            candidatesDao.Replace(c => c.CandidateId == entity.CandidateId, entity) > 0;

        public bool Delete(string id) => 
            candidatesDao.Delete(c => c.CandidateId == id) > 0;

        public CandidateModel GetBy(string companyId, string candidateId) => 
            candidatesDao.GetOneByFunc(c => c.CompanyId == companyId && c.CandidateId == candidateId);

        public List<CandidateModel> GetBy(string companyId,
            LinesEnum lines,
            string name = null,
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
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
                , lines)
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.Name)
                    .ToList();
        }
        public List<CandidateModel> GetBy(
            string companyId,
            LinesEnum lines,
            List<string> skills,
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
        {
                if (skills == null || skills.Count == 0)
                    return null;

                return candidatesDao.GetListByFunc(c =>
                    c.CompanyId == companyId && 
                    (status == null || c.Status == status) &&
                    (c.ListSkills.Select(s => s.Skill).All(s => skills.Any(sks => sks == s))) &&
                    (countryId == null || c.CountryId == countryId) &&
                    (stateId == null || c.StateId == stateId)
                , lines)
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.Name)
                    .ToList();
        }

        public long GetCount(
            string companyId,
            string name = null,
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
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
        public long GetCount(
            string companyId,
            List<string> skills,
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
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
    }
}