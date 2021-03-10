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
        private readonly FilterDefinitionBuilder<CandidateModel> fd = Builders<CandidateModel>.Filter;
        public CandidatesRepository(ICandidatesDao candidatesDao)
        {
            this.candidatesDao = candidatesDao;
        }
        public async Task Insert(CandidateModel entity) => await candidatesDao.Insert(entity);

        public async Task<bool> Replace(CandidateModel entity) =>
            (await candidatesDao.Replace(fd.Where(c => c.CandidateId == entity.CandidateId), entity)) > 0;

        public async Task<bool> Delete(string id) =>
            (await candidatesDao.Delete(fd.Eq(c => c.CandidateId, id))) > 0;

        public async Task<CandidateModel> GetBy(string companyId, string candidateId) =>
            await candidatesDao.GetByFunc(fd.Where(c => c.CompanyId == companyId && c.CandidateId == candidateId));

        public async Task<PagedListModel<CandidateReduced>> GetBy(
            string companyId,
            int page,
            PageSizeEnum pageSize,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null)
        {
            var pglCandidate = await candidatesDao.GetByFunc(Filter(companyId, name, skills, countryId, stateId, status), page, pageSize);
            PagedListModel<CandidateReduced> pagedListModel = new PagedListModel<CandidateReduced>
            {
                Count = pglCandidate.Count,
                Pages = pglCandidate.Pages,
                List = pglCandidate.List.Select(
                    x => new CandidateReduced 
                    {
                        CandidateId = x.CandidateId,
                        ClientOrSearchId = x.ClientOrSearchId,
                        LastName = x.LastName,
                        Name = x.Name,
                        Photo = x.Photo,
                        Role = x.Role,
                        Seniority = x.Seniority,
                        Status = x.Status
                    }).OrderBy(x => x.LastName).ThenBy(x => x.Name).ToList()
            };
            return pagedListModel;
        }

        public async Task<long> Count(
            string companyId,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null) =>
            await candidatesDao.Count(Filter(companyId, name, skills, countryId, stateId, status));

        private FilterDefinition<CandidateModel> Filter(
            string companyId,
            string name,
            List<string> skills,
            int countryId,
            int stateId,
            StatusCandiateEnum? status = null)
        {
            name ??= string.Empty;
            name = name.Trim();
            skills ??= new List<string>();
            skills.ForEach(s => s.Trim());

            var filterDefinitions = new List<FilterDefinition<CandidateModel>>
            {
                fd.Eq(c => c.CompanyId, companyId)
            };

            if (countryId > 0)
                filterDefinitions.Add(fd.Eq(c => c.CountryId, countryId));

            if (stateId > 0)
                filterDefinitions.Add(fd.Eq(c => c.StateId, stateId));

            if (!string.IsNullOrWhiteSpace(name))
                filterDefinitions.Add(fd.Where(c => c.Name.Contains(name) || c.LastName.Contains(name)));

            if (skills.Count > 0)
                filterDefinitions.Add(fd.ElemMatch(e => e.ListSkills, Builders<SkillItem>.Filter.In(y => y.Skill, skills)));

            return fd.And(filterDefinitions);
        }
    }
}