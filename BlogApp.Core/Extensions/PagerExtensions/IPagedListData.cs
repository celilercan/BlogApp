using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Core.Extensions.PagerExtensions
{
    public interface IPagedList<out T> : IEnumerable<T>, IPagedListData
    {
    }

    public interface IPagedListData
    {
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
        int TotalPageCount { get; }
        int StartRecordIndex { get; }
        int EndRecordIndex { get; }
    }

    public class PagedList<T> : List<T>, IPagedListData, IPagedList<T>
    {
        public PagedList()
        {

        }

        public PagedList(IList<T> items, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            TotalItemCount = items.Count;
            TotalPageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            CurrentPageIndex = pageIndex;
            StartRecordIndex = (CurrentPageIndex - 1) * PageSize + 1;
            EndRecordIndex = TotalItemCount > pageIndex * pageSize ? pageIndex * pageSize : TotalItemCount;

            for (var i = StartRecordIndex - 1; i < EndRecordIndex; i++)
            {
                Add(items[i]);
            }
        }

        public PagedList(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount)
        {
            AddRange(items);
            TotalItemCount = totalItemCount;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
            StartRecordIndex = (pageIndex - 1) * pageSize + 1;
            EndRecordIndex = TotalItemCount > pageIndex * pageSize ? pageIndex * pageSize : totalItemCount;

        }

        public PagedList(IEnumerable<T> items)
        {
            AddRange(items);
            TotalItemCount = items.Count();
            TotalPageCount = (int)Math.Ceiling(TotalItemCount / (double)1);
            CurrentPageIndex = 1;
            PageSize = 1;
            StartRecordIndex = (1 - 1) * 1 + 1;
            EndRecordIndex = TotalItemCount > 1 * 1 ? 1 * 1 : TotalItemCount;

        }
        public ApiPagedList<T> ToApiPagedList()
        {
            return new ApiPagedList<T>
            {
                CurrentPageIndex = CurrentPageIndex,
                PageSize = PageSize,
                TotalItemCount = TotalItemCount,
                TotalPageCount = TotalPageCount,
                StartRecordIndex = StartRecordIndex,
                EndRecordIndex = EndRecordIndex,
                Items = this.ToList()
            };
        }

        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; private set; }
        public int StartRecordIndex { get; private set; }
        public int EndRecordIndex { get; private set; }
    }

    public class ApiPagedList<T>
    {
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public int StartRecordIndex { get; set; }
        public int EndRecordIndex { get; set; }
        public List<T> Items { get; set; }
    }
}
