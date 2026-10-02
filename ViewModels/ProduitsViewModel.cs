using BlazorWebAssemblyApp.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.ViewModels
{
    public class ProduitsViewModel
    {
        private readonly HttpClient _httpClient;

        public ProduitsViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ProduitDto> Produits { get; private set; } = new();
        public ProduitDetailDto? ProduitSelectionne { get; private set; }
        
        public bool IsLoading { get; private set; }

        public event Action? OnStateChange;

        public async Task ChargerProduitsAsync()
        {
            IsLoading = true;
            NotifyStateChanged();

            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<ProduitDto>>("api/Produits");
                if (result != null)
                {
                    Produits = result;
                }
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        public async Task ChargerDetailsProduitAsync(int id)
        {
            IsLoading = true;
            NotifyStateChanged();

            try
            {
                var result = await _httpClient.GetFromJsonAsync<ProduitDetailDto>($"api/Produits/{id}");
                ProduitSelectionne = result;
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        public void ReinitialiserSelection()
        {
            ProduitSelectionne = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
