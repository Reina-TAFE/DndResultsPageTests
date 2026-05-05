using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DndResultsPageTests.Models;

namespace DndResultsPageTests.Models.ResponseModels
{
    public class SpellCategoryResponseModel
    {
        public int count {  get; set; }
        public List<Result> results { get; set; }

        public CategoryList ToModel()
        {
            List<SearchCategory> newCategories = results.Select(r => new SearchCategory(r.name, $"level {r.level} spells", r.index, r.url)).ToList();
            return new CategoryList(count, newCategories);
        }
    }

    public class Result
    {
        public string index { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public string url { get; set; }
    }
}
