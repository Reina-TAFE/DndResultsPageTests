using DndResultsPageTests.Models;
using DndResultsPageTests.ViewModels;
using DndResultsPageTests.ViewModels.ResultsPageComponentModels;
using DndResultsPageTests.Models.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DndResultsPageTests.Models.EquipmentModels
{
    public class WeaponModel(string index, string name, ApiObjectInfo? equipmentCategory,
        ApiObjectInfo? gearCategory, List<string>? desc, string url, Cost? cost, int? weight,
        string updatedAt, string? weaponCategory, string? categoryRange, string? weaponRangeType, WeaponDamage? damage,
        WeaponDamage? twoHandedDamage, WeaponRange? range, WeaponRange? throwRange, List<ApiObjectInfo>? properties,
        List<string>? special, List<(ApiObjectInfo, int)>? contents) : EquipmentModel(index,
        name, equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properties)
    {
        [JsonPropertyName("weapon_category")]
        public string? WeaponCategory { get; set; } = weaponCategory;

        [JsonPropertyName("category_range")]
        public string? WeaponCategoryRange { get; set; } = categoryRange;

        [JsonPropertyName("weapon_range")]
        public string? WeaponRange { get; set; } = weaponRangeType;

        [JsonPropertyName("damage")]
        public WeaponDamage? Damage { get; set; } = damage;

        [JsonPropertyName("two_handed_damage")]
        public WeaponDamage? TwoHandedDamage { get; set; } = twoHandedDamage;

        [JsonPropertyName("range")]
        public WeaponRange? Range { get; set; } = range;

        [JsonPropertyName("throw_range")]
        public WeaponRange? ThrowRange { get; set; } = throwRange;

        [JsonPropertyName("special")]
        public List<string>? Special { get; set; } = special;

        public new ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, WeaponCategory);
            ResultsPageSectionModel body = new ResultsPageSectionModel("weapon", GetSections());
            return new ResultsPageViewModel(new ResultsPageHeaderViewModel(header), new ResultsPageSectionViewModel(body));
        }

        public new List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent attributeSection = GetWeaponAttributesSection();
            SectionContent propertiesSection = GetPropertiesSection();
            sections.Add(attributeSection);
            sections.Add(propertiesSection);
            return sections;
        }

        public SectionContent GetWeaponAttributesSection()
        {
            SectionContent attributeSection = new SectionContent
            {
                SectionTitle = "Attributes",
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
                                    { "Weapon Type", WeaponCategory },
                                    { "Damage", $"1d{Damage.DamageDice} {Damage.DamageType?.Name}" },
                                    {"Two-Handed", TwoHandedDamage != null ? $"1d{TwoHandedDamage.DamageDice} {TwoHandedDamage.DamageType?.Name}" : null },
                                    { "Range", Range != null && Range.Long != null ? $"({Range.Normal}ft - {Range.Long}ft)" : $"{Range?.Normal}ft"  },
                                    { "Thrown Range", ThrowRange != null && ThrowRange.Long != null ? $"({ThrowRange.Normal}ft - {ThrowRange.Long}ft)" : $"{ThrowRange?.Normal}ft" }
                                }
                            }
                        }
                    }
            };
            return attributeSection;
        }
    }

    public class WeaponRange
    {
        [JsonPropertyName("normal")]
        public int? Normal { get; set; }

        [JsonPropertyName("long")]
        public int? Long { get; set; }
    }

    public class WeaponDamage
    {
        [JsonPropertyName("damage_dice")]
        public string? DamageDice { get; set; }

        [JsonPropertyName("damage_type")]
        public ApiObjectInfo? DamageType { get; set; }
    }

}
