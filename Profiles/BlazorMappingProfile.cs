using AutoMapper;
using BlazorWebAssemblyApp.Models;

namespace BlazorWebAssemblyApp.Profiles
{
    public class BlazorMappingProfile : Profile
    {
        public BlazorMappingProfile()
        {
            // Exemple d'utilisation d'AutoMapper côté client : 
            // CreateMap<ProduitDto, ProduitLocalModel>();
            
            // Si vous créez des modèles spécifiques pour le client (formulaires, états), 
            // configurez vos mappings ici.
        }
    }
}

