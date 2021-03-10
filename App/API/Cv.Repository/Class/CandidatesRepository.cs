using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
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
            (await candidatesDao.Replace(Builders<CandidateModel>.Filter.Where(c => c.CandidateId == entity.CandidateId), entity)) > 0;

        public async Task<bool> Delete(string id) =>
            (await candidatesDao.Delete(Builders<CandidateModel>.Filter.Eq(c => c.CandidateId, id))) > 0;

        public async Task<CandidateModel> GetBy(string companyId, string candidateId) =>
            await candidatesDao.GetByFunc(Builders<CandidateModel>.Filter.Where(c => c.CompanyId == companyId && c.CandidateId == candidateId));

        public async Task<PagedListModel<CandidateModel>> GetBy(
            string companyId,
            int page,
            PageSizeEnum pageSize,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null)
        {
            return await candidatesDao.GetByFunc(Filter(companyId, name, skills, countryId, stateId, status), page, pageSize);
        }

        public async Task<long> Count(
            string companyId,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null) =>
            await candidatesDao.Count(Filter(companyId, name, skills, countryId, stateId, status));

        public FilterDefinition<CandidateModel> Filter(
            string companyId,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null)
        {
            name ??= string.Empty;
            skills ??= new List<string>();

            var b = Builders<CandidateModel>.Filter;
            var filter = b.Where(c => c.CompanyId == companyId && (countryId < 1 || c.CountryId == countryId) && (stateId < 1 || c.StateId == stateId))
                & b.Where(c => c.Name.Contains(name) || c.LastName.Contains(name));
            // | (c.Name + " " + c.LastName).Contains(name) | (c.LastName + " " + c.Name).Contains(name));

            if (skills.Count > 0)
                filter = b.Where(c => c.CompanyId == companyId && (countryId < 1 || c.CountryId == countryId) && (stateId < 1 || c.StateId == stateId))
                    & b.ElemMatch(e => e.ListSkills, Builders<SkillItem>.Filter.In(y => y.Skill, skills));


            return filter;
        }
    }
}