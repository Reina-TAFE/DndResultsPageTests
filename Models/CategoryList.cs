using System;
using System.Collections.Generic;
using System.Text;
using DndResultsPageTests.Models;

namespace DndResultsPageTests.Models
{
    public class CategoryList(int count, List<SearchCategory>? categories) : ApiObjectInfo(null, null, null)
    {
        public int Count { get; set; } = count;
        public List<SearchCategory>? Categories {get; set;} = categories;
    }
}
