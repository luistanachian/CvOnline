namespace Cv.Business.Class
{
    public class CompaniesBusiness //: ICompaniesBusiness
    {

        ////private readonly ICompaniesRepository companiesRepository;
        ////public CompaniesBusiness(ICompaniesRepository companiesRepository)
        ////{
        ////    this.companiesRepository = companiesRepository;
        ////}
        ////public async Task<ResultBus> Insert(CompanyModel entity)
        ////{
        ////    var result = new ResultBus();
        ////    try
        ////    {
        ////        await companiesRepository.Insert(entity);
        ////        result.Result = true;
        ////    }
        ////    catch (Exception)
        ////    {
        ////        result.AddError("Error");
        ////    }
        ////    return result;
        ////}

        ////public async Task<bool> Replace(CompanyModel entity) =>
        ////    (await companiesDao.Replace(fd.Eq(c => c.CompanyId, entity.CompanyId), entity)) > 0;

        ////public async Task<bool> Delete(string id) =>
        ////    (await companiesDao.Delete(fd.Eq(c => c.CompanyId, id))) > 0;

        ////public async Task<CompanyModel> GetBy(string id) =>
        ////    await companiesDao.GetByFunc(fd.Eq(c => c.CompanyId, id));
    }
}
