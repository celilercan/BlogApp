using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.Common
{
    public class BaseFilterDto
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public int GetPageIndex
        {
            get
            {
                return PageIndex ?? 1;
            }
        }

        public int GetPageSize
        {
            get
            {
                return PageSize ?? 20;
            }
        }
    }
}
