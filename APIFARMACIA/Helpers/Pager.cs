using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace APIFARMACIA.Helpers;

public class Pager<T> where T : class
{
    public string Search { get; set; }
    public int PageIndex {get; set;}
    public int PageSize {get; set;}
    public int Total {get; set;}

    public List<T> Registers {get; private set;}
    public Pager() {}

     public Pager(List<T> registers, int total, int pageindex, int pagesize, string search)
    {
        Registers = registers;
        Total = total;
        PageIndex = pageindex;
        PageSize = pagesize;
        Search = search;
    }

    public int TotalPages
    {
        get { return (int)Math.Ceiling(Total / (double)PageSize);}
        set { this.TotalPages = value;}
    }

    public bool HasPreviousPage{
        get { return (PageIndex > 1);}
        set { this.HasPreviousPage = value;}
    }

    public bool HasNextPage{
        get { return (PageIndex < TotalPages);}
        set { this.HasNextPage = value;}
    }
}
