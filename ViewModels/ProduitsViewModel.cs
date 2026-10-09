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

        public async Task<bool> AjouterProduitAsync(ProduitCreateDto nouveauProduit)
        {
            IsLoading = true;
            NotifyStateChanged();

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Produits", nouveauProduit);
                if (response.IsSuccessStatusCode)
                {
                    await ChargerProduitsAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        public async Task<bool> ModifierProduitAsync(ProduitUpdateDto produit)
        {
            IsLoading = true;
            NotifyStateChanged();

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Produits/{produit.IdProduit}", produit);
                if (response.IsSuccessStatusCode)
                {
                    await ChargerProduitsAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        public async Task<bool> SupprimerProduitAsync(int id)
        {
            IsLoading = true;
            NotifyStateChanged();

            try
            {
                var response = await _httpClient.DeleteAsync($"api/Produits/{id}");
                if (response.IsSuccessStatusCode)
                {
                    await ChargerProduitsAsync();
                    if (ProduitSelectionne?.Id == id) ReinitialiserSelection();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
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

