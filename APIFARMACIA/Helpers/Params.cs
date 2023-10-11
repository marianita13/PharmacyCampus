using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFARMACIA.Helpers;

public class Params
{
    private int _PageSize = 5;
    private const int MaxPageSize = 50;
    private int _pageIndex = 1;
    private int _pageSize = 1;
    private string _search;
    public int PageSize{
        get => _PageSize;
        set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public int PageIndex{
        get => _pageIndex;
        set => _pageIndex = (value <= 0) ? 1 : value;
    }
    public string Search{
        get => _search;
        set => _search = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
}
