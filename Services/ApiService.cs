using DndResultsPageTests.Models;
using DndResultsPageTests.Models.EquipmentModels;
using DndResultsPageTests.Models.ResponseModels;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DndResultsPageTests.Services
{
    /// <summary>
    /// A class for handling all API interactions such as making API requests and deserializing the responses.
    /// </summary>
    public class ApiService
    {
        private string _baseUrl = "https://www.dnd5eapi.co";
        public string BaseUrl
        {
            get {  return _baseUrl; }
        }
        public static HttpClient client = new HttpClient();
        public ApiService() { }

        public async Task<object?> GetApiResponse(SearchCategory searchItem)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(searchItem.Url);
                return await response.Content.ReadFromJsonAsync<object?>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static async Task<SpellModel>? GetSpellAsync(string index)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/spells/{index}");
                SpellResponseModel spellResponseModel = await response.Content.ReadFromJsonAsync<SpellResponseModel>();
                SpellModel spell = spellResponseModel.ToModel();
                return spell;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static async Task<ClassModel>? GetClassAsync(string index)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/classes/{index}");
                response.EnsureSuccessStatusCode();
                ClassResponseModel classResponseObj = await response.Content.ReadFromJsonAsync<ClassResponseModel>();
                return classResponseObj.ToModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Makes an api request and deserializes the response into the correct equipment model type based on the equipment category.
        /// If the equipment Category is not a weapon, armor, or vehicle, it will be deserialized into a generic equipment model object.
        /// </summary>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static async Task<EquipmentModel>? GetEquipmentAsync(SearchCategory searchOption)
        {
            HttpResponseMessage response = await client.GetAsync(searchOption.Url);
            response.EnsureSuccessStatusCode();
            try 
            {           
                UniversalEquipmentResponseModel responseObj = await response.Content.ReadFromJsonAsync<UniversalEquipmentResponseModel>(); 
            

                if (responseObj.equipment_category != null) // try to access 'equipment_category' field of the Json response
                {

                    if (responseObj.equipment_category.Name == "Weapon")// try to access 'name' property of the 'equipment_category' json object
                    {
                        return responseObj.ToWeaponModel();
                    }
                    else if (responseObj.equipment_category.Name == "Armor")
                    {
                        return responseObj.ToArmourModel();
                    }
                    else if (responseObj.equipment_category.Name == "Mounts and Vehicles")
                    {
                        return responseObj.ToVehicleModel();
                    }
                    else
                    {
                        return responseObj.ToEquipmentModel();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// Generic method for making an api request and deserializing the response into a model object of the provided type.
        /// Model type must be a subclass of ApiObjectInfo and the endpoint provided must return a response that can be deserialized into the provided model type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static async Task<T> GetResourcesForEndpointAsync<T>(SearchCategory endpoint)
        {
            try{
                HttpResponseMessage response = await client.GetAsync(endpoint.Url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch { throw new NotImplementedException(); }
        }

        public static async Task<T> GetResourceListForEndpointAsync<T>(SearchCategory endpoint)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint.Url);
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch { throw new NotImplementedException(); }
        }


        //public static async Task<CategoryList>? GetCategoryListForEndpoint(SearchCategory endpoint)
        //{
        //    try{ 
        //        HttpResponseMessage response = await client.GetAsync(endpoint.Url);

        //    }
        //    catch { throw new NotImplementedException(); }
        //}

    }
}
