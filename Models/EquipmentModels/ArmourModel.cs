using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using DndResultsPageTests.Models;
using DndResultsPageTests.Models.UI;
using DndResultsPageTests.ViewModels;
using DndResultsPageTests.ViewModels.ResultsPageComponentModels;

namespace DndResultsPageTests.Models.EquipmentModels
{
    public class ArmourModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            ApiObjectInfo? gearCategory, List<string>? desc, string? url, Cost? cost,
            int? weight, string? updatedAt, List<(ApiObjectInfo, int)>? contents,
            List<ApiObjectInfo>? properites, string? armourCategory, ArmourClass? armourClass,
            int? strMinimum, bool? stealthDisadvange) : EquipmentModel(index, name,
            equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properites)
    {
        [JsonPropertyName("armor_category")]
        public string? ArmourCategory { get; set; } = armourCategory;

        [JsonPropertyName("armor_class")]
        public ArmourClass? ArmourClass { get; set; } = armourClass;

        [JsonPropertyName("str_minimum")]
        public int? StrMinimum { get; set; } = strMinimum;

        [JsonPropertyName("stealth_disadvantage")]
        public bool? StealthDisadvange { get; set; } = stealthDisadvange;

        public new ResultsPageViewModel ToResultsPageViewModel()
        {
            (ResultsPageHeaderViewModel, ResultsPageSectionViewModel) componentViewModels = GetResultsPageComponentViewModels();
            return new ResultsPageViewModel(componentViewModels.Item1, componentViewModels.Item2);
        }

        public (ResultsPageHeaderViewModel, ResultsPageSectionViewModel) GetResultsPageComponentViewModels()
        {
            (ResultsPageHeaderModel, ResultsPageSectionModel) componentModels = GetResultsPageComponentModels();
            return (new ResultsPageHeaderViewModel(componentModels.Item1), new ResultsPageSectionViewModel(componentModels.Item2));
        }

        public (ResultsPageHeaderModel, ResultsPageSectionModel) GetResultsPageComponentModels()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, ArmourCategory);
            ResultsPageSectionModel body = new ResultsPageSectionModel("armour", GetSections());
            return (header, body);
        }

        public new List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent attributeSection = GetArmourAttributesSection();
            SectionContent propertiesSection = GetPropertiesSection();
            sections.Add(attributeSection);
            sections.Add(propertiesSection);
            return sections;
        }

        public SectionContent GetArmourAttributesSection()
        {
            SectionContent armourAttributeSection = new SectionContent
            {
                SectionTitle = "Armour Attributes",
                ContentType = "standard",
                Content = new List<SectionItem>
                    {
                        new SectionItem
                        {
                            ItemType = "KeyValueList",
                            ItemContent = new List<Dictionary<string, string?>>
                            {
                                new Dictionary<string, string?>
                                {
                                    {"Armour Class", ArmourClass?.ToString()},
                                    {"STR Minimum", StrMinimum?.ToString()},
                                    {"Stealth Disadvantage", StealthDisadvange != null ? "True" : null}
                                }
                            }
                        }
                    }
            };
            return armourAttributeSection;
        }
    }

    public class ArmourClass
    {
        [JsonPropertyName("base")]
        public int? Base { get; set; }

        [JsonPropertyName("dex_bonus")]
        public bool? DexBonus { get; set; }

        [JsonPropertyName("max_bonus")]
        public int? MaxBonus { get; set; } = null;

        public override string ToString()
        {
            return $"{Base}{((bool)DexBonus ? $" + DEX{((MaxBonus != null) ? $", up to +{MaxBonus}" : null)}" : null)}";
        }
    }
}
