using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models.UI
{
    public class NavBarModel
    {
        public static List<ImageButton> NavBarButtons = new List<ImageButton>()
        {
            new ImageButton()
            {
                Source = "/Assets/Icons/spellbook.png",
                GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(() => Shell.Current.GoToAsync("SearchPage", App.PageQueryOptions["SpellSearchPage"])) } },
            },
            new ImageButton()
            {
                Source = "/Assets/Icons/paladin.png",
                GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(() => Shell.Current.GoToAsync("SearchPage", App.PageQueryOptions["ClassesSearchPage"])) } },
            },
            new ImageButton()
            {
                Source = "/Assets/Icons/fighter_symbol.png",
                GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(() => Shell.Current.GoToAsync("SearchPage", App.PageQueryOptions["EquipmentSearchPage"])) } },
            },
            new ImageButton()
            {
                Source = "/Assets/Icons/scroll.png",
                GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(() => Shell.Current.GoToAsync("SearchPage", App.PageQueryOptions["SpellsSearchPage"])) } },
            }
        };
    }
}