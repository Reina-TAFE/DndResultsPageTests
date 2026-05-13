using DndResultsPageTests.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models
{
    public class ClassLevelsModel : ApiObjectInfo
    {
        public int? Level { get; set; }
        public int? AbilityScoreBonuses { get; set; }
        public int? ProfBonus { get; set; }
        public List<ApiObjectInfo>? Features { get; set; }
        public LevelSpellcastingInfo? SpellSlotInfo { get; set; } = null;
        public ClassSpecific? ClassSpecific { get; set; }
        public ApiObjectInfo? ParentClass { get; set; }


        public ClassLevelsModel(int? level, int? ability_score_bonus,  int? prof_bonus, List<ApiObjectInfo>? features,
            LevelSpellcastingInfo? spellcastingInfo, ClassSpecific? classSpecific, string? index, ApiObjectInfo? parentClass,
            string? url, DateTime? updatedAt)
            : base (index, $"{parentClass?.Name} Lvl{level.ToString()}", url)
        {
            Level = level;
            AbilityScoreBonuses = ability_score_bonus;
            ProfBonus = prof_bonus;
            Features = features;
            SpellSlotInfo = spellcastingInfo;
            ClassSpecific = classSpecific;
            ParentClass = parentClass;
        }

    }
}
