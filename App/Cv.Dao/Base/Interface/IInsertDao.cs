namespace Cv.Dao.Base.Interface
{
    public interface IInsertDao<T> where T : class
    {
        void Insert(T entity);
    }
}
