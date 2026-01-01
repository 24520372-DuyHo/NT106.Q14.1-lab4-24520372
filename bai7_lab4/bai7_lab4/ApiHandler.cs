using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai7_lab4
{
    public class ApiHandler
    {

        private readonly HttpClient _client;
        public Token CurrentToken { get; private set; }
        public User CurrentUser { get; set; }

        private const string BASE_URL = "https://nt106.uitiot.vn/api/v1";
        private const string LOGIN_ENDPOINT = "/auth/token";
        private const string USER_ME_ENDPOINT = "/user/me";
        private const string DISHES_ALL_ENDPOINT = "/monan/all";
        private const string DISHES_MINE_ENDPOINT = "/monan/my-dishes";
        private const string DISHES_ENDPOINT = "/monan";
        private const string DISHES_ADD_ENDPOINT = "/monan/add";

        public bool IsLoggedIn => CurrentToken != null && !string.IsNullOrEmpty(CurrentToken.AccessToken);

        public ApiHandler()
        {
            _client = new HttpClient();
        }

        public HttpClient GetClient()
        {
            if (CurrentToken != null && !string.IsNullOrEmpty(CurrentToken.AccessToken))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(CurrentToken.TokenType, CurrentToken.AccessToken);
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = null;
            }
            return _client;
        }

        public void SetToken(string accessToken, string tokenType)
        {
            CurrentToken = new Token { AccessToken = accessToken, TokenType = tokenType };
        }

        public void Logout()
        {
            CurrentToken = null;
            CurrentUser = null;
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            if (!IsLoggedIn) return null;

            try
            {
                HttpClient client = GetClient();
                HttpResponseMessage response = await client.GetAsync(BASE_URL + USER_ME_ENDPOINT);

                if (response.IsSuccessStatusCode)
                {
                    string userString = await response.Content.ReadAsStringAsync();
                    CurrentUser = JsonConvert.DeserializeObject<User>(userString);
                    return CurrentUser;
                }
            }
            catch (Exception)
            {

            }
            return null;
        }


        public async Task<List<Dish>> GetDishesAsync(bool allDishes, int page, int pageSize)
        {
            string endpoint = allDishes ? DISHES_ALL_ENDPOINT : DISHES_MINE_ENDPOINT;
            string url = BASE_URL + endpoint;

            if (!allDishes && !IsLoggedIn)
            {
                return new List<Dish>();
            }

            try
            {
                HttpClient client = GetClient();

                var pagingData = new
                {
                    current = page,
                    pageSize = pageSize
                };

                string jsonContent = JsonConvert.SerializeObject(pagingData);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(json);
                    JToken dataToken = jsonObject["data"];

                    if (dataToken == null)
                    {
                        System.Diagnostics.Debug.WriteLine("Phản hồi thành công nhưng thiếu trường 'data'.");
                        return new List<Dish>();
                    }

                    List<Dish> dishes = dataToken.ToObject<List<Dish>>();
                    return dishes;
                }
                else
                {
                    string errorString = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        Logout();
                    }
                    return new List<Dish>();
                }
            }
            catch (JsonReaderException)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi Deserialization! Vui lòng kiểm tra lại Dish.cs.", "LỖI DỮ LIỆU");
                return new List<Dish>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi hệ thống khi tải món ăn: {ex.Message}");
                return new List<Dish>();
            }
        }

        public async Task<bool> AddDishAsync(object dataToSend)
        {
            if (!IsLoggedIn) return false;

            try
            {
                string url = BASE_URL + DISHES_ADD_ENDPOINT;
                HttpClient client = GetClient();

                string jsonContent = JsonConvert.SerializeObject(dataToSend);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDishAsync(string dishId)
        {
            if (!IsLoggedIn) return false;

            try
            {
                HttpClient client = GetClient();
                string url = $"{BASE_URL}{DISHES_ENDPOINT}/{dishId}";

                HttpResponseMessage response = await client.DeleteAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Dish> GetRandomDishAsync(bool allDishes)
        {
            string endpoint = allDishes ? DISHES_ALL_ENDPOINT : DISHES_MINE_ENDPOINT;

            if (!allDishes && !IsLoggedIn) return null;

            try
            {

                List<Dish> dishes = await GetDishesAsync(allDishes, 1, 100);

                if (dishes != null && dishes.Any())
                {
                    Random rand = new Random();
                    int index = rand.Next(dishes.Count);

                    System.Diagnostics.Debug.WriteLine($"Chọn ngẫu nhiên món: {dishes[index].Name}");

                    return dishes[index];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi hệ thống khi chọn món ngẫu nhiên: {ex.Message}");
            }

            return null;
        }
    }
}
