namespace BlazorWebAssemblyApp.Models
{
    public class ProduitDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Type { get; set; }
        public string? Marque { get; set; }
    }

    public class ProduitDetailDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Type { get; set; }
        public string? Marque { get; set; }
        public string? Description { get; set; }
        public string? Nomphoto { get; set; }
        public string? Uriphoto { get; set; }
        public int? Stock { get; set; }
        public int StockReel { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int IdTypeProduit { get; set; }
        public int IdMarque { get; set; }
        public bool EnReappro { get; set; }
    }

    public class MarqueDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public int NbProduits { get; set; }
    }

    public class ProduitCreateDto
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Le nom est requis")]
        public string? NomProduit { get; set; }

        public string? Description { get; set; }
        public string? NomPhoto { get; set; }
        public string? UriPhoto { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Veuillez sélectionner un type de produit")]
        public int IdTypeProduit { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Veuillez sélectionner une marque")]
        public int IdMarque { get; set; }

        public int StockReel { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
    }
    public class ProduitUpdateDto : ProduitCreateDto
    {
        public int IdProduit { get; set; }
    }
}

