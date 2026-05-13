using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models.ResponseModels
{
    public class ClassLevelsResponseModel
    {
        public int? level { get; set; }
        public int? ability_score_bonuses { get; set; }
        public int? prof_bonus { get; set; }
        public List<ApiObjectInfo>? features { get; set; }
        public LevelSpellcastingInfo? spellcasting { get; set; }
        public ClassSpecific? class_specific { get; set; }
        public string? index { get; set; }
        public ApiObjectInfo? @class { get; set; }
        public string? url { get; set; }
        public DateTime updated_at { get; set; }

        public ClassLevelsModel ToModel()
        {
            return new ClassLevelsModel(
                level, 
                ability_score_bonuses, 
                prof_bonus,
                features,
                spellcasting,
                class_specific,
                index, 
                @class, 
                url, 
                updated_at);
        }
    }

    public class ClassSpecific
    {
        public int channel_divinity_charges { get; set; }
        public double destroy_undead_cr { get; set; }
    }

    public class LevelSpellcastingInfo
    {
        public int cantrips_known { get; set; }
        public int spell_slots_level_1 { get; set; }
        public int spell_slots_level_2 { get; set; }
        public int spell_slots_level_3 { get; set; }
        public int spell_slots_level_4 { get; set; }
        public int spell_slots_level_5 { get; set; }
        public int spell_slots_level_6 { get; set; }
        public int spell_slots_level_7 { get; set; }
        public int spell_slots_level_8 { get; set; }
        public int spell_slots_level_9 { get; set; }
    }
}
