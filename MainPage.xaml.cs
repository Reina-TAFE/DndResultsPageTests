using DndResultsPageTests.Models;
using DndResultsPageTests.Models.EquipmentModels;
using DndResultsPageTests.Models.ResponseModels;
using DndResultsPageTests.Services;
using DndResultsPageTests.ViewModels;

namespace DndResultsPageTests
{
    public partial class MainPage : ContentPage
    {
        public SearchCategory Fireball = new SearchCategory("Fireball", "Spell", "fireball", "/api/2014/spells/fireball");
        public SearchCategory Abacus = new SearchCategory("Fireball", null, "abacus", "/api/2014/equipment/abacus");
        public SearchCategory Greataxe = new SearchCategory("Greataxe", null, "greataxe", "/api/2014/equipment/greataxe");
        public SearchCategory Mule = new SearchCategory("Mule", null, "mule", "/api/2014/equipment/mule");
        public SearchCategory PaddedArmour = new SearchCategory("Padded Armour", null, "padded-armour", "/api/2014/equipment/padded-armor");

        public MainPage()
        {
            InitializeComponent();
        }

        private async void FireBallBtnClicked(object? sender, EventArgs e)
        {
            SearchCategory searchOption = Fireball;
            SpellResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<SpellResponseModel>(searchOption);
            SpellModel spell = responseObj.ToModel();
            ResultsPageViewModel viewModel = spell.ToResultsPageViewModel();
            IDictionary<string, object> queryOptions = new Dictionary<string, object>
            {
                {  "ViewModel", viewModel   }
            };
            await Shell.Current.GoToAsync("ResultsPage", queryOptions);
        }

        private async void AbacusBtnClicked(object? sender, EventArgs e)
        {
            SearchCategory searchOption = Abacus;
            UniversalEquipmentResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<UniversalEquipmentResponseModel>(searchOption);
            EquipmentModel abacus = responseObj.ToEquipmentModel();
            ResultsPageViewModel viewModel = abacus.ToResultsPageViewModel();
            IDictionary<string, object> queryOptions = new Dictionary<string, object>
            {
                {  "ViewModel", viewModel   }
            };
            await Shell.Current.GoToAsync("ResultsPage", queryOptions);
        }

        private async void GreataxeBtnClicked(object? sender, EventArgs e)
        {
            SearchCategory searchOption = Greataxe;
            UniversalEquipmentResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<UniversalEquipmentResponseModel>(searchOption);
            WeaponModel greataxe = responseObj.ToWeaponModel();
            ResultsPageViewModel viewModel = greataxe.ToResultsPageViewModel();
            IDictionary<string, object> queryOptions = new Dictionary<string, object>
            {
                {  "ViewModel", viewModel   }
            };
            await Shell.Current.GoToAsync("ResultsPage", queryOptions);
        }

        private async void MuleBtnClicked(object? sender, EventArgs e)
        {
            SearchCategory searchOption = Mule;
            UniversalEquipmentResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<UniversalEquipmentResponseModel>(searchOption);
            VehicleModel mule = responseObj.ToVehicleModel();
            ResultsPageViewModel viewModel = mule.ToResultsPageViewModel();
            IDictionary<string, object> queryOptions = new Dictionary<string, object>
            {
                {  "ViewModel", viewModel   }
            };
            await Shell.Current.GoToAsync("ResultsPage", queryOptions);
        }

        private async void PaddedArmourBtnClicked(object? sender, EventArgs e)
        {
            SearchCategory searchOption = PaddedArmour;
            UniversalEquipmentResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<UniversalEquipmentResponseModel>(searchOption);
            ArmourModel paddedArmour = responseObj.ToArmourModel();
            ResultsPageViewModel viewModel = paddedArmour.ToResultsPageViewModel();
            IDictionary<string, object> queryOptions = new Dictionary<string, object>
            {
                {  "ViewModel", viewModel   }
            };
            await Shell.Current.GoToAsync("ResultsPage", queryOptions);
        }
    }
}
