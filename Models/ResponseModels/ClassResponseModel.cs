using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using DndResultsPageTests.Models;

namespace DndResultsPageTests.Models.ResponseModels
{
    public class ClassResponseModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public int hit_die { get; set; }
        public List<OptionSet> proficiency_choices { get; set; }
        public List<ApiObjectInfo> proficiencies { get; set; }
        public List<ApiObjectInfo> saving_throws { get; set; }
        public List<StartingEquipment> starting_equipment { get; set; }
        public List<OptionSet> starting_equipment_options { get; set; }
        public string class_levels { get; set; }
        public MultiClassing multi_classing { get; set; }
        public List<ApiObjectInfo> subclasses { get; set; }
        public string url { get; set; }
        public DateTime updated_at { get; set; }


        public ClassModel ToModel()
        {
            return new ClassModel(
                index,
                name,
                url,
                hit_die,
                class_levels,
                multi_classing,
                starting_equipment,
                starting_equipment_options,
                proficiency_choices,
                proficiencies,
                saving_throws,
                subclasses
            );
        }
    }
}