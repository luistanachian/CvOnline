using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Repository.Class
{
    public sealed class CandidatesRepository : ICandidatesRepository
    {
        private readonly ICandidatesDao candidatesDao;
        public CandidatesRepository(ICandidatesDao candidatesDao)
        {
            this.candidatesDao = candidatesDao;
        }
        public async Task Insert(CandidateModel entity) => await candidatesDao.Insert(entity);

        public async Task<bool> Replace(CandidateModel entity) =>
            (await candidatesDao.Replace(c => c.CandidateId == entity.CandidateId, entity)) > 0;

        public async Task<bool> Delete(string id) =>
            (await candidatesDao.Delete(c => c.CandidateId == id)) > 0;

        public async Task<CandidateModel> GetBy(string companyId, string candidateId) =>
            await candidatesDao.GetByFunc(c => c.CompanyId == companyId && c.CandidateId == candidateId);

        public async Task<PagedListModel<CandidateModel>> GetBy(string companyId,
            int page,
            PageSizeEnum pageSize,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null)
        {
            name = name?.Trim();

            return await candidatesDao.GetByFunc(c =>
                c.CompanyId == companyId &&
                (status == null || c.Status == status) &&
                (skills == null || skills.Count == 0 || c.ListSkills.Select(s => s.Skill).All(s => skills.Any(sks => sks == s))) &&
                (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name) || c.LastName.Contains(name) ||
                    $"{c.Name} {c.LastName}".Contains(name) || $"{c.LastName} {c.Name}".Contains(name)) &&
                (countryId < 1 || c.CountryId == countryId) &&
                (stateId < 1 || c.StateId == stateId),
                page,
                pageSize);
        }

        public async Task<long> Count(
            string companyId,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null)
        {
            return await candidatesDao.Count(c =>
            c.CompanyId == companyId &&
            (status == null || c.Status == status) &&
            (skills == null || skills.Count == 0 || c.ListSkills.Select(s => s.Skill).All(s => skills.Any(sks => sks == s))) &&
            (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name) || c.LastName.Contains(name) ||
                $"{c.Name} {c.LastName}".Contains(name) || $"{c.LastName} {c.Name}".Contains(name)) &&
            (countryId < 1 || c.CountryId == countryId) &&
            (stateId < 1 || c.StateId == stateId));
        }
    }
}