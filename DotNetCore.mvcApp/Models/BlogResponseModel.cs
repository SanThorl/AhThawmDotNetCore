﻿using DotNetCore.mvcApp.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DotNetCore.mvcApp.Models
{
    public class BlogResponseModel
    {
        public int PageNo { get; set; }

        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public bool IsEndOfPage => PageNo >= PageCount;

        public List<BlogModel> Data { get; set; }
    }
}
