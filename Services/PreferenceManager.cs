using System;
using System.Collections.Generic;
using System.Text;
using DndResultsPageTests.Models;
using DndResultsPageTests.Models.UI;

namespace DndResultsPageTests.Services
{
    /// <summary>
    /// Provides methods for getting and setting user preferences in the app's preferences, 
    /// as well as updating the backing fields for the elements associated with those preferences in the app's resource dictionary.
    /// </summary>
    public static class PreferenceManager
    {
        public static List<string> ValidThemeNames = new List<string>() // List of valid theme names
        {
            "Light Mode",
            "Dark Mode"
        };

        /// <summary>
        /// Sets the name of the current theme in the app's preferences.
        /// </summary>
        /// <param name="themeName">The name of the theme to be set</param>
        public static void SetCurrentTheme(string themeName)
        {
            if (ValidThemeNames.Contains(themeName)) // check if themeName is a valid theme name
            {
                Preferences.Set("CurrentTheme", themeName); // set the current theme in the app's preferences
                UpdateResourceColours(); // update the current element colour backing fields in app resource dictionary to the new theme's colours
            }
        }

        /// <summary>
        /// Returns the name of the theme currently selected in the App's Preferences.
        /// </summary>
        /// <returns>A string containing the name of the currently selected theme. Defaults to Light Mode if np theme is set</returns>
        public static string GetCurrentTheme()
        {
            return Preferences.Get("CurrentTheme", "Light Mode");
        }

        /// <summary>
        /// Updates the current colours of elements in app resource dictionary to the current theme selected in the app's preferences.
        /// </summary>
        public static void UpdateResourceColours()
        {
            string currentTheme = Preferences.Get("CurrentTheme", "Light Mode");
            if (currentTheme == "Light Mode") // update current element colours to light mode colours
            {
                Application.Current.Resources["CurrentBackgroundColour"] = Application.Current.Resources["LightBackground"];
                Application.Current.Resources["CurrentSectionColour"] = Application.Current.Resources["LightSection"];
                Application.Current.Resources["CurrentButtonColour"] = Application.Current.Resources["LightButton"];
                Application.Current.Resources["CurrentButtonTextColour"] = Application.Current.Resources["LightButtonText"];
                Application.Current.Resources["CurrentTextColour"] = Application.Current.Resources["LightText"];
                Application.Current.Resources["CurrentTitleColour"] = Application.Current.Resources["LightTitle"];
                Application.Current.Resources["CurrentNavColour"] = Application.Current.Resources["LightNav"];
            }
            else if (currentTheme == "Dark Mode") // update current element colours to dark mode colours
            {
                Application.Current.Resources["CurrentBackgroundColour"] = Application.Current.Resources["DarkBackground"];
                Application.Current.Resources["CurrentSectionColour"] = Application.Current.Resources["DarkSection"];
                Application.Current.Resources["CurrentButtonColour"] = Application.Current.Resources["DarkButton"];
                Application.Current.Resources["CurrentButtonTextColour"] = Application.Current.Resources["DarkButtonText"];
                Application.Current.Resources["CurrentTextColour"] = Application.Current.Resources["DarkText"];
                Application.Current.Resources["CurrentTitleColour"] = Application.Current.Resources["DarkTitle"];
                Application.Current.Resources["CurrentNavColour"] = Application.Current.Resources["DarkNav"];
            }
        }


    }
}
