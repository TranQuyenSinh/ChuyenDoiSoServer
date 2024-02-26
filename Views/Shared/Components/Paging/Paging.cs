using System;
using System.Collections;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChuyenDoiSoServer.Components
{
    public class Paging : ViewComponent
    {
        public class PagingOptions
        {
            public int TotalItem { get; set; }
            public int CurrentPage { get; set; }
            public int PageSize { get; set; } = Constants.PAGE_ITEM_COUNT;
            public Func<int?, string> GenerateUrl { get; set; }
        }

        public IViewComponentResult Invoke(PagingOptions options)
        {
            var totalPages = (int)Math.Ceiling((double)options.TotalItem / options.PageSize);

            if (options.CurrentPage > totalPages)
                options.CurrentPage = totalPages;
            if (options.CurrentPage < 1)
                options.CurrentPage = 1;

            return View(new
            {
                options.CurrentPage,
                TotalPages = totalPages,
                options.GenerateUrl
            });
        }
    }
}