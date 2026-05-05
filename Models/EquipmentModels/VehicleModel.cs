using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DndResultsPageTests.Models;
using DndResultsPageTests.Models.UI;
using DndResultsPageTests.ViewModels;
using DndResultsPageTests.ViewModels.ResultsPageComponentModels;

namespace DndResultsPageTests.Models.EquipmentModels
{
    public class VehicleModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            ApiObjectInfo? gearCategory, List<string>? desc, string? url, Cost? cost, int? weight,
            string? updatedAt, List<(ApiObjectInfo, int)>? contents, List<ApiObjectInfo>? properties,
            string? vehicleCategory, Speed? speed, string? capacity) : EquipmentModel(index, name,
            equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properties)
    {
        [JsonPropertyName("vehicle_category")]
        public string? VehicleCategory { get; set; } = vehicleCategory;

        [JsonPropertyName("speed")]
        public Speed? VehicleSpeed { get; set; } = speed;

        [JsonPropertyName("capacity")]
        public string? VehicleCapacity { get; set; } = capacity;

        public new ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, VehicleCategory);
            ResultsPageSectionModel body = new ResultsPageSectionModel("vehicle", GetSections());
            return new ResultsPageViewModel(new ResultsPageHeaderViewModel(header), new ResultsPageSectionViewModel(body));
        }

        public new List<SectionContent> GetSections()
            {
                List<SectionContent> sections = new List<SectionContent>();
                SectionContent attributeSection = GetVehicleAttributesSection();
                SectionContent propertiesSection = GetPropertiesSection();
                sections.Add(attributeSection);
                sections.Add(propertiesSection);
                return sections;
        }

        public SectionContent GetVehicleAttributesSection()
        {
            SectionContent vehicleAttributeSection = new SectionContent
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
                                    { "Speed", VehicleSpeed?.ToString() },
                                    { "Capacity", VehicleCapacity },
                                }
                            }
                        }
                    }
            };
            return vehicleAttributeSection;
        }
    }

    public class Speed
    {
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }

        public override string ToString()
        {
            return $"{Quantity}{Unit}";
        }
    }
}
