using DndResultsPageTests.Models;
using DndResultsPageTests.Models.EquipmentModels;
using DndResultsPageTests.Models.UI;
using DndResultsPageTests.ViewModels;
using DndResultsPageTests.ViewModels.ResultsPageComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models
{
    public class ClassModel : ApiObjectInfo
    {
        public string? UpdatedAt { get; set; }
        public int? HitDie { get; set; }
        public string? ClassLevelsResourceUrl { get; set; }
        public MultiClassing? MultiClassing { get; set; }
        public SpellCasting? SpellCasting { get; set; } = null;
        public string? SpellsListResourceUrl { get; set; } = null;
        public List<StartingEquipment>? StartingEquipment { get; set; }
        public List<OptionSet>? StartingEquipmentOptions { get; set; }
        public List<OptionSet>? ProficiencyChoices { get; set; }
        public List<Proficiency>? Proficiencies { get; set; }
        public List<ApiObjectInfo>? SavingThrows { get; set; }
        public List<ApiObjectInfo>? Subclasses { get; set; }

        public ClassModel(string index, string name, string url, int hitDie, string classLevelResourceUrl,
            MultiClassing multiClassing, List<StartingEquipment> startingEquipment, List<OptionSet> startingEquipmentOptions,
            List<OptionSet> proficiencyChoices, List<ApiObjectInfo> proficiencies, List<ApiObjectInfo> savingThrows,
            List<ApiObjectInfo> subclasses, SpellCasting? spellCasting = null, string? spellsListResourceUrl = null)
            : base(index, name, url)
        {
            HitDie = hitDie;
            ClassLevelsResourceUrl = classLevelResourceUrl;
            MultiClassing = multiClassing;
            SpellCasting = spellCasting;
            SpellsListResourceUrl = spellsListResourceUrl;
            StartingEquipment = startingEquipment;
            StartingEquipmentOptions = startingEquipmentOptions;
            ProficiencyChoices = proficiencyChoices;
            Proficiencies = proficiencies.Select(p => new Proficiency(p)) as List<Proficiency>;
            SavingThrows = savingThrows;
            Subclasses = subclasses;
            SpellCasting = spellCasting;
            SpellsListResourceUrl = spellsListResourceUrl;
        }

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
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, "DnD 5e (2014)", GetClassIcon());
            ResultsPageSectionModel body = new ResultsPageSectionModel("class", GetSections());
            return (header, body);
        }

        public new List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent attributeSection = GetStatsSection();
            SectionContent propertiesSection = GetStartingEquipmentSection();
            SectionContent levelsSection = GetLevelsSection();
            sections.Add(attributeSection);
            sections.Add(propertiesSection);
            sections.Add(levelsSection);
            return sections;
        }

        public Image? GetClassIcon()
        {
            Image? icon = null;
            try
            {
                icon = new Image { Source = ImageSource.FromFile($"{this.Index}.png") };
            }
            catch 
            {
                throw new FileNotFoundException();
            }
            return icon;
        }

        public SectionContent GetStatsSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = null,
                ContentType = "standard",
                Content = new List<SectionItem>
                    {
                        new SectionItem
                        {
                            SectionItemTitle = "Hit Points",
                            ItemType = "KeyValueList",
                            ItemContent = new List<Dictionary<string, string?>>
                            {
                                new Dictionary<string, string?>
                                {
                                    {"Hit Dice", HitDie != null ? $"1d{HitDie.ToString()} per {Name} level": null},
                                    {"Saving Throws", SavingThrows != null ? string.Join(",", SavingThrows?.Select(st => st.ToString())) : null},
                                    {"Spell Casting Modifier", SpellCasting != null ? SpellCasting?.SpellCastingAbility?.ToString() : null}
                                }
                            }
                        },
                        new SectionItem
                        {
                            SectionItemTitle = "Proficiencies",
                            ItemType = "KeyValueList",
                            ItemContent = new List<Dictionary<string, string?>>
                            {
                                new Dictionary<string, string?>
                                {
                                    {"Armour", Proficiencies != null ? string.Join(",", Proficiencies.Select(p => p.ProficiencyType == "armour" ? p.ToString() : null)) : null},
                                    {"Equipment", Proficiencies != null ? string.Join(",", Proficiencies.Select(p => p.ProficiencyType == "weapon" ? p.ToString() : null)) : null},
                                    {"Saving Throws", Proficiencies != null ? string.Join(",", Proficiencies.Select(p => p.ProficiencyType == "savingThrows" ? p.ToString() : null)) : null},
                                },
                                new Dictionary<string, string?>
                                {
                                    {"Skill Proficiencies", ProficiencyChoices != null ? string.Join("", ProficiencyChoices.Select(pc => pc.desc)) : null},
                                }

                            },
                        }
                    }
            };
            return section;
        }

        public SectionContent GetStartingEquipmentSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = null,
                ContentType = "standard",
                Content = new List<SectionItem>
                {
                    new SectionItem
                    {
                        SectionItemTitle = "Starting Equipment",
                        ItemType = "KeyValueList",
                        ItemContent = new List<Dictionary<string, string?>>
                        {
                            new Dictionary<string, string?>
                            {
                                {"Starting Equipment", StartingEquipment != null ? string.Join(",", StartingEquipment.Select(i => $"{i.quantity}x {i.equipment?.Name}")) : null },
                                {"Options", StartingEquipmentOptions != null ? string.Join("\n", StartingEquipmentOptions.Select(i => i.desc)) : null },
                            }
                        }
                    }
                }
            };
            return section;
        }

        public SectionContent GetLevelsSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = null,
                ContentType = "Levels",
                Content = new List<SectionItem>
                {
                    new SectionItem
                    {
                        SectionItemTitle = "Levels",
                        //ItemType = "LevelTable",
                        ItemType = "KeyValueList",
                        ItemContent = new List<Dictionary<string, string?>>
                        {
                            new Dictionary<string, string?>
                            {
                                {"Level Table URL", ClassLevelsResourceUrl != null ? ClassLevelsResourceUrl : null },
                            }
                        }
                    },
                     new SectionItem
                    {
                        SectionItemTitle = "SubClasses",
                        ItemType = "CategoryList",
                        ItemObjects = Subclasses?.Select(sc => sc != null ? new SearchCategory(sc.Index, "Subclass", sc.Index, sc.Url) as object : null).ToList()
                        //ItemObjects = new List<object?>
                        //{
                        //    Subclasses?.Select(sc => sc != null ? new SearchCategory(sc.Index, "Subclass", sc.Index, sc.Url): null).ToList()
                        //}
                    }
                }
            };
            return section;
        }
    }

    public class Proficiency : ApiObjectInfo
    {
        public string? ProficiencyType { get; set; } = null;

        public Proficiency(ApiObjectInfo proficiencyInfo): 
            base(proficiencyInfo.Index, proficiencyInfo.Name, proficiencyInfo.Url)
        {
            GetProficiencyType();
        }

        public void GetProficiencyType()
        {
            if( Index != null)
            {
                if (Index.Contains("armor")) { ProficiencyType = "armour"; }
                else if(Index.Contains("weapons") || Index.Contains("shields")) { ProficiencyType = "weapon"; }
                else if(Index.Contains("saving-throw")) { ProficiencyType = "savingThrow"; }
            }
        }
    }

    public class SpellCasting
    {
        public int? Level { get; set; }
        public ApiObjectInfo? SpellCastingAbility { get; set; }
        public List<Info>? SpellCastingInfo { get; set; }
    }

    public class Info
    {
        public string? Name { get; set; }
        public List<string>? Desc { get; set; }
    }

    public class MultiClassing
    {
        public List<Prerequisite>? prerequisites { get; set; }
        public List<ApiObjectInfo>? proficiencies { get; set; }
    }

    public class Prerequisite
    {
        public ApiObjectInfo? ability_score { get; set; }
        public int? minimum_score { get; set; }
    }

    public class StartingEquipment 
    {
        public ApiObjectInfo? equipment { get; set; }
        public int? quantity { get; set; }
    }

    public class OptionSet
    {
        public string? desc { get; set; }
        public int? choose { get; set; }
        public string? type { get; set; }
        public From? from { get; set; }
    }

    public class From
    {
        public string? option_set_type { get; set; }
        public List<Option>? options { get; set; }
        public ApiObjectInfo? equipment_category { get; set; }
    }

    public class Option
    {
        public string? option_type { get; set; }
        public ApiObjectInfo? item { get; set; }
        public OptionSet? choice { get; set; }
        public int? count { get; set; }
        public ApiObjectInfo? of { get; set; }
    }
}