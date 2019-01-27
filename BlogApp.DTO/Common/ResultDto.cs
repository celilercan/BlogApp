using BlogApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.Common
{
    public class ResultDto<T> where T : class
    {
        public ResultDto()
        {
            ErrorType = ErrorType.None;
        }
        public T Result { get; set; }
        public ErrorType ErrorType { get; set; }
        public bool IsSuccess { get { return ErrorType == ErrorType.None; } }
    }
}
