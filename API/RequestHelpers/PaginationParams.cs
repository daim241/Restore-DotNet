using System;

namespace API.RequestHelpers;

public class PaginationParams
{
    private const int MaxPageSize = 30;  // value change accordingly on how many products wants to be in a page
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 8;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
    
}
