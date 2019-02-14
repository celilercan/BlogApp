using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.Common
{
    public class BaseFilterDto
    {
        private int _pageIndex { get; set; }
        private int _pageSize { get; set; }
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value <= default(int) ? 1 : value;
            }
        }
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageIndex = value <= default(int) ? 20 : value;
            }
        }
    }
}
