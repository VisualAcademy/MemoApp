using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoApp.Models
{
    /// <summary>
    /// [3] Repository Interface, Provider Interface
    /// </summary>
    public interface IMemoRepository : IMemoCrudRepository<Memo>
    {
        // PM> Install-Package Dul

        Task<Tuple<int, int>> GetStatus(int parentId);
        Task<bool> DeleteAllByParentId(int parentId);
        Task<SortedList<int, double>> GetMonthlyCreateCountAsync();
    }
}
