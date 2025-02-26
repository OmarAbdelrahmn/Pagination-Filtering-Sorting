using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Filtering_Sorting.Abstractions;
public class PaginatiedList<T>(List<T> items, int pageNumber, int count, int pageSize)
{
    public List<T> Items { get; private set; } = items;
    public int PageNumber { get; private set; } = pageNumber;
    public int TotalPages { get; private set; } = (int)Math.Ceiling(count / (double)pageSize);
    public bool HavePreviesPage => PageNumber > 1;
    public bool HaveNextPage => PageNumber < TotalPages;

    public static async Task<PaginatiedList<T>> Create(IQueryable<T> Source, int pageNumber, int pageSize)
    {
        var COunt = await Source.CountAsync();

        //( PageNumber - 1 ) * PageSize                for ex pagesize = 10
        var items = await Source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatiedList<T>(items, pageNumber, COunt, pageSize);
    }


    //adding update 
}
