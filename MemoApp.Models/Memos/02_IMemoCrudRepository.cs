using Dul.Articles;
using Dul.Domain.Common;
using System.Threading.Tasks;

namespace MemoApp.Models
{
    /// <summary>
    /// [2] Generic Repository Interface => ICrudRepositoryBase.cs 
    /// </summary>
    public interface IMemoCrudRepository<T> : ICrudRepositoryBase<T, int>
    {
        // PM> Install-Package Dul

        Task<bool> EditAsync(T model); // 수정
        Task<T> AddAsync(
            T model,
            int parentRef,
            int parentStep,
            int parentRefOrder); // 답변(기본: ReplyApp)
        Task<T> AddAsync(
            T model,
            int parentId); // 답변(고급: MemoApp)

        // 페이징
        Task<PagingResult<T>> GetAllAsync(
            int pageIndex,
            int pageSize);

        // 부모 Id
        Task<PagingResult<T>> GetAllByParentIdAsync(
            int pageIndex,
            int pageSize,
            int parentId);

        // 부모 Key
        Task<PagingResult<T>> GetAllByParentKeyAsync(
            int pageIndex,
            int pageSize,
            string parentKey);

        // 검색
        Task<PagingResult<T>> SearchAllAsync(
            int pageIndex,
            int pageSize,
            string searchQuery);

        // 검색 + 부모 Id
        Task<PagingResult<T>> SearchAllByParentIdAsync(
            int pageIndex,
            int pageSize,
            string searchQuery,
            int parentId);

        // 검색 + 부모 Key
        Task<PagingResult<T>> SearchAllByParentKeyAsync(
            int pageIndex,
            int pageSize,
            string searchQuery,
            string parentKey);
    }
}
