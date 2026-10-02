using BlazorWebAssemblyApp.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.ViewModels
{
    public class MarquesViewModel
    {
        private readonly HttpClient _httpClient;

        public MarquesViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<MarqueDto> Marques { get; private set; } = new();
        public bool IsLoading { get; private set; }

        public event Action? OnStateChange;

        public async Task ChargerMarquesAsync()
        {
            IsLoading = true;
            NotifyStateChanged();

            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<MarqueDto>>("api/Marques");
                if (result != null)
                {
                    Marques = result;
                }
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}

