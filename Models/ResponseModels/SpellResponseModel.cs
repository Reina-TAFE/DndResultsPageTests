using DndResultsPageTests.Models.EquipmentModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace DndResultsPageTests.Models.ResponseModels
{
    public class SpellResponseModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public List<string> desc { get; set; }
        public List<string> higher_level { get; set; }
        public string range { get; set; }
        public List<string> components { get; set; }
        public string material { get; set; }
        public bool ritual { get; set; }
        public string duration { get; set; }
        public bool concentration { get; set; }
        public string casting_time { get; set; }
        public int level { get; set; }
        public Damage damage { get; set; }
        public Dc dc { get; set; }
        public AreaOfEffect area_of_effect { get; set; }
        public ApiObjectInfo school { get; set; }
        public List<ApiObjectInfo> classes { get; set; }
        public List<ApiObjectInfo> subclasses { get; set; }
        public string url { get; set; }
        public DateTime updated_at { get; set; }

        public SpellModel ToModel()
        {
            return new SpellModel(
                index,
                name,
                url,
                desc,
                level,
                higher_level,
                school,
                casting_time,
                range,
                area_of_effect,
                duration,
                components,
                material,
                ritual,
                concentration,
                damage,
                dc,
                classes,
                subclasses
            );
        }
    }
}
