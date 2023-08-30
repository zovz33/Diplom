using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories;
using PrimeTableware.WPF.ViewModels.Commands;
using PrimeTableware.WPF.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using static System.Net.WebRequestMethods;

namespace PrimeTableware.WPF.ViewModels.Services
{

    public class VKAPIService : ViewModelBase, IVKAPIService
    {
        private string redirectUrl = "https://oauth.vk.com/blank.html";
        private const int ClientID = 51699263;
        private const string Scope = "offline,email,phone";
        private const string ClientSecret = "9532f5519532f5519532f5515c96262b6e995329532f551f19814fab2ea7cbe3210a6f4"; // Сервисный ключ доступа

        private string _login = null;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password = null;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public async void VKAuth()
        {
            // Формирование URL для отправки запроса на авторизацию
            string authURL = $"https://oauth.vk.com/token?grant_type=password&client_id={ClientID}&client_secret={ClientSecret}&username={Uri.EscapeDataString(Login)}&password={Uri.EscapeDataString(Password)}&scope={Scope}";

            // Отправка HTTP-запроса для авторизации
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(authURL);

            if (response.IsSuccessStatusCode)
            {
                // Обработка успешного ответа
                string responseContent = await response.Content.ReadAsStringAsync();

                // Разбор полученного JSON-ответа и извлечение токена доступа
                var jsonResponse = JObject.Parse(responseContent);
                string accessToken = jsonResponse["access_token"].ToString();

                // Вызов метода для получения информации о пользователе
                GetUserInfo(accessToken);
            }
            else
            {
                // Обработка ошибки
                MessageBox.Show("Ошибка при авторизации");
            }
        }

        private async void GetUserInfo(string accessToken)
        {
            // Формирование URL для запроса информации о пользователе
            string userInfoURL = $"https://api.vk.com/method/users.get?access_token={accessToken}&v=5.131";

            // Отправка HTTP-запроса для получения информации о пользователе
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(userInfoURL);

            if (response.IsSuccessStatusCode)
            {
                // Обработка успешного ответа
                string responseContent = await response.Content.ReadAsStringAsync();

                // Разбор полученного JSON-ответа и извлечение информации о пользователе
                var jsonResponse = JObject.Parse(responseContent);
                var userArray = jsonResponse["response"].ToObject<JArray>();
                var userObject = userArray[0].ToObject<JObject>();
                string userName = $"{userObject["first_name"]} {userObject["last_name"]}";

                // Используйте полученную информацию о пользователе по своему усмотрению
                // Например, отобразите имя пользователя в вашем WPF приложении
                MessageBox.Show($"Авторизован пользователь: {userName}");
            }
            else
            {
                // Обработка ошибки
                MessageBox.Show("Ошибка при получении информации о пользователе");
            }
        }
    }


}