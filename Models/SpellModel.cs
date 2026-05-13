using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using DndResultsPageTests.Models;
using DndResultsPageTests.ViewModels;
using DndResultsPageTests.ViewModels.ResultsPageComponentModels;
using DndResultsPageTests.Models.ResponseModels;
using DndResultsPageTests.Models.UI;
using DndResultsPageTests.Pages;

namespace DndResultsPageTests.Models 
{ 
    public class SpellModel : ApiObjectInfo
    {
        public string? UpdatedAt { get; set; } = null;
        public List<string>? Description { get; set; } = null;
        public int? Level { get; set; } = null;
        public List<string>? HigherLevel { get; set; } = null;
        public ApiObjectInfo? School { get; set; } = null;
        public string? CastTime { get; set; } = null;
        public string? Range { get; set; } = null;
        public AreaOfEffect? AreaOfAffect { get; set; } = null;
        public string? Duration { get; set; } = null;
        public List<string>? Components { get; set; } = null;
        public string? Materials { get; set; } = null;
        public bool? Ritual { get; set; } = null;
        public bool? Concentration { get; set; } = null;
        //public string? AttackType { get; set; }
        public Damage? Damage { get; set; } = null;
        public Dc? Dc { get; set; } = null;
        public List<ApiObjectInfo>? Classes { get; set; } = null;
        public List<ApiObjectInfo>? SubClasses { get; set; } = null;



        public SpellModel(string index, string name, string url, List<string> desc, int level, List<string> highLevel,
            ApiObjectInfo school, string castTime, string range, AreaOfEffect AoE, string duration, List<string> components,
            string materials, bool ritual, bool concentration, Damage damage, Dc dc, List<ApiObjectInfo> classes, List<ApiObjectInfo> subclasses)
            : base(index, name, url)
        {
            Description = desc;
            Level = level;
            HigherLevel = highLevel;
            School = school;
            CastTime = castTime;
            Range = range;
            AreaOfAffect = AoE;
            Duration = duration;
            Components = components;
            Materials = materials;
            Ritual = ritual;
            Concentration = concentration;
            Damage = damage;
            Dc = dc;
            Classes = classes;
            SubClasses = subclasses;
        }

        public ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, $"Level {Level} {School}");
            ResultsPageSectionModel body = new ResultsPageSectionModel("spell", GetSections());
            return new ResultsPageViewModel(new ResultsPageHeaderViewModel(header), new ResultsPageSectionViewModel(body));
        }

        public (ResultsPageHeaderModel, ResultsPageSectionModel) ToResultsPageComponentModels()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, $"Level {Level} {School}");
            ResultsPageSectionModel body = new ResultsPageSectionModel("spell", GetSections());
            return (header, body);
        }

        /// <summary>
        /// Returns list of page sections. Each section contains a list of sub-sections (SectionItems), which contain each content group to be rendered on the page.
        /// </summary>
        /// <returns></returns>
        public List<SectionContent> GetSections() 
        {
            SectionContent requirementsSection = this.GetRequirementsSection(); // Requirements Section includes the following sub-sections: Level, School, Cast Time, Range, Duration, Components, Materials, Ritual, Concentration
            //SectionContent requirementsSection2 = this.GetRequirementsSection(); // Requirements Section includes the following sub-sections: Level, School, Cast Time, Range, Duration, Components, Materials, Ritual, Concentration
            SectionContent usageSection = this.GetUsageSection(); // Usage Section includes the following sub-sections: Description, Materials, Higher Level (if applicable)
            List<SectionContent> sections = new List<SectionContent>();
            sections.Add( requirementsSection );
            //sections.Add( requirementsSection2 );
            sections.Add( usageSection );

            return sections;
        }

        /// <summary>
        /// Formats SpellModel properties to a page section (SectionContent) representing the requirements section of the spell.
        /// </summary>
        /// <returns>A SectionContent object representing the requirements section of the spell.</returns>
        public SectionContent GetRequirementsSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = "Requirements",
                ContentType = "SpellRequirements",
                Content = new List<SectionItem>
                    {
                        new SectionItem
                        {
                            SectionItemTitle = null,
                            ItemType = "KeyValueList",
                            ItemContent = new List<Dictionary<string, string?>>
                            {
                                {
                                    new Dictionary<string, string?>
                                    {
                                        { "Level", (Level != null) ? Level.ToString() : string.Empty },
                                        { "School", (School != null) ? School.Name : string.Empty },
                                        { "Cast Time", CastTime ?? string.Empty },
                                        { "Range", Range ?? string.Empty },
                                        { "Duration", Duration ?? string.Empty },
                                        { "Components", (Components != null) ? string.Join(", ", Components) : string.Empty },
                                        { "Materials", Materials ?? string.Empty },
                                        { "Ritual", (Ritual != null) ? Ritual.ToString() : string.Empty },
                                        { "Concentration", (Concentration != null) ? Concentration.ToString() : string.Empty }
                                    }
                                }
                            }
                        }
                    }
            };
            return section;

        }

        /// <summary>
        /// Formats SpellModel properties to a page section (SectionContent) representing the usage section of the spell.
        /// </summary>
        /// <returns>A SectionContent object representing the usage section of the spell.</returns>
        public SectionContent GetUsageSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = "Usage",
                ContentType = "SpellUsage",
                Content = new List<SectionItem>
                    {
                        new SectionItem
                        {
                            SectionItemTitle = "Materials",
                            ItemType = "text",
                            ItemContent = new List<Dictionary<string, string?>>
                            {
                                {
                                    new Dictionary<string, string?>
                                    {
                                        { "text", (Materials != null) ? Materials.ToString() : string.Empty }
                                    }
                                }
                            }
                        },
                        //new SectionItem
                        //{
                        //    SectionItemTitle = "Description",
                        //    ItemType = "KeyValueList",
                        //    ItemContent = new List<Dictionary<string, string?>>
                        //    {
                        //        {
                        //            new Dictionary<string, string?>
                        //            {
                        //                { "text", (Description?[0] != null) ? Description?[0]?.ToString() :string.Empty }
                        //            }
                        //        },
                        //        {
                        //            new Dictionary<string, string?>
                        //            {
                        //                { "At Higher Levels", (HigherLevel != null && HigherLevel.Count > 0) ? $"At Higher Levels: {string.Join("\n", HigherLevel)}" : string.Empty }
                        //            }
                        //        }
                        //    }
                        //}
                    }
            };
            return section;

        }
    }
                    
                
            


    public class AreaOfEffect
    {
        public string type { get; set; }
        public int size { get; set; }
    }

    public class Damage
    {
        public ApiObjectInfo damage_type { get; set; }
        public DamageAtSlotLevel damage_at_slot_level { get; set; }
    }

    public class Dc
    {
        public ApiObjectInfo dc_type { get; set; }
        public string dc_success { get; set; }
    }

    public class DamageAtSlotLevel
    {
        [JsonPropertyName("0")]
        public string? Lvl0 { get; set; }

        [JsonPropertyName("1")]
        public string? Lvl1 { get; set; }

        [JsonPropertyName("2")]
        public string? Lvl2 { get; set; }

        [JsonPropertyName("3")]
        public string? Lvl3 { get; set; }

        [JsonPropertyName("4")]
        public string? Lvl4 { get; set; }

        [JsonPropertyName("5")]
        public string? Lvl5 { get; set; }

        [JsonPropertyName("6")]
        public string? Lvl6 { get; set; }

        [JsonPropertyName("7")]
        public string? Lvl7 { get; set; }

        [JsonPropertyName("8")]
        public string? Lvl8 { get; set; }

        [JsonPropertyName("9")]
        public string? Lvl9 { get; set; }

        public Dictionary<string, string> ToDict()
        {
            return new Dictionary<string, string>
            {
                {"0", (Lvl0 != null) ? Lvl0 : string.Empty },
                {"1", (Lvl1 != null) ? Lvl1 : string.Empty },
                {"2", (Lvl2 != null) ? Lvl2 : string.Empty },
                {"3", (Lvl3 != null) ? Lvl3 : string.Empty },
                {"4", (Lvl4 != null) ? Lvl4 : string.Empty },
                {"5", (Lvl5 != null) ? Lvl5 : string.Empty },
                {"6", (Lvl6 != null) ? Lvl6 : string.Empty },
                {"7", (Lvl7 != null) ? Lvl7 : string.Empty },
                {"8", (Lvl8 != null) ? Lvl8 : string.Empty },
                {"9", (Lvl9 != null) ? Lvl9 : string.Empty },
            };
        }
    }
}
