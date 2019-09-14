namespace CSharpDesignPatterns.Common.Model
{
    public interface IRepository<TId, TType>
    {
        TId   Create(TType x);
        void  Delete(TId   id);
        TType Read(TId     id);
        void  Update(TId   id, TType x);
    }
}