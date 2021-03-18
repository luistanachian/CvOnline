using Cv.Dao.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Models.Search;
using Cv.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
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

        public async Task<bool> Delete(string companyId, string candidateId) =>
            (await candidatesDao.Delete(fd.Where(c => c.CompanyId == companyId && c.CandidateId == candidateId))) > 0;

        public async Task<CandidateModel> GetBy(string companyId, string candidateId) =>
            await candidatesDao.GetByFunc(fd.Where(c => c.CompanyId == companyId && c.CandidateId == candidateId));

        public async Task<PagedListModel<CandidateModel>> GetBy(CandidateSearch candidateSearch) => 
            await candidatesDao.GetByFunc(Filter(candidateSearch), candidateSearch.Page, candidateSearch.PageSize);


        public async Task<long> Count(CandidateSearch candidateSearch) =>
            await candidatesDao.Count(Filter(candidateSearch));

        private FilterDefinition<CandidateModel> Filter(CandidateSearch candidateSearch)
        {
            candidateSearch.Name ??= string.Empty;
            candidateSearch.Name = candidateSearch.Name.Trim();
            candidateSearch.Skills ??= new List<string>();
            candidateSearch.Skills.ForEach(s => s.Trim());

            var filterDefinitions = new List<FilterDefinition<CandidateModel>>
            {
                fd.Eq(c => c.CompanyId, candidateSearch.CompanyId)
            };

            if (candidateSearch.CountryId > 0)
                filterDefinitions.Add(fd.Eq(c => c.CountryId, candidateSearch.CountryId));

            if (candidateSearch.StateId > 0)
                filterDefinitions.Add(fd.Eq(c => c.StateId, candidateSearch.StateId));

            if (!string.IsNullOrWhiteSpace(candidateSearch.Name))
                filterDefinitions.Add(fd.Where(c => c.FullName.Contains(candidateSearch.Name)));

            if (candidateSearch.Skills.Count > 0)
                filterDefinitions.Add(fd.ElemMatch(e => e.Skills, Builders<SkillItem>.Filter.In(y => y.Skill, candidateSearch.Skills)));

            return fd.And(filterDefinitions);
        }
    }
}