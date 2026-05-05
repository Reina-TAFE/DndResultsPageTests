using DndResultsPageTests.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DndResultsPageTests
{
    public partial class App : Application
    {

        private static List<SearchCategory> _spellLevelList = default!;


        public static List<SearchCategory> SpellLevelList
        {
            get
            {
                var levelList = from number in Enumerable.Range(1, 9) select new SearchCategory($"Level {number}", $"Spells", $"level={number}", $"/api/2014/spells?level={number}");
                List<SearchCategory> SpellLevels = levelList.ToList();
                SpellLevels.Insert(0, new SearchCategory("Cantrips", "Spells", "level=0", $"/api/2014/spells?level=0"));
                _spellLevelList = SpellLevels;
                return SpellLevels;
            }
        }
        public static Dictionary<String, Dictionary<string, object>> PageQueryOptions = new Dictionary<String, Dictionary<string, object>>
        {
            {"SpellSearchPage", new Dictionary<string, object>
                {
                    {"PageName", "Spells" },
                    {"CategoryType", "Levels" },
                    {"CategoryOptions", SpellLevelList },
                }
            },
            {"ClassesSearchPage", new Dictionary<string, object>
                {
                    {"PageName", "Classes" },
                    {"CategoryType", "Class Types" },
                    {"CategoryOptions", SpellLevelList},
                }
            },
            {"EquipmentSearchPage", new Dictionary<string, object>
                {
                    {"PageName", "Equipment" },
                    {"CategoryType", "Equipment Types" },
                    {"CategoryOptions", SpellLevelList},
                }
            }
        };
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}