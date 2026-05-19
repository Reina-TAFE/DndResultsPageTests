using DndResultsPageTests.Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models
{
    public class ClassLevelsTableModel
    {
        public List<ClassLevelsModel> Levels { get; set; }

        public SectionItem ToSectionItem()
        {
            return new SectionItem
            {
                SectionItemTitle = null,
                ItemType = "LevelTable",
                ItemContent = null,
                ItemObjects = new List<object?>
                {
                    new List<string>{Levels[0].ParentClass.Name, Levels[0].SpellSlotInfo != null ? "Spell Slots Per Spell Level" : string.Empty },
                    new List<string>{"Levels", "Ability Score Bonus", "Proficiency Bonus", "Features", "Cantrips Known", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "Class Specific"},
                    Levels
                    //Levels?.Select(level => level != null ? new List<string>{level.Level.ToString(),
                    //    level.AbilityScoreBonuses.ToString(),
                    //    level.ProfBonus.ToString(),
                    //    string.Join(", ", level.Features.Select(f => f != null ? f.Name : "")),
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.cantrips_known.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_1.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_2.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_3.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_4.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_5.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_6.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_7.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_8.ToString() : string.Empty,
                    //    level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_9.ToString() : string.Empty,
                    //} : null )
                },
            };

        }
    }
}
