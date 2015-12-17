using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoixResto2.ViewModels
{
    public class RestaurantVoteViewModel : IValidatableObject
    {
        public List<RestaurantCheckBoxViewModel> ListeDesRestos { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ListeDesRestos.Exists(r => r.EstSelectionne == true) == false)
                yield return new ValidationResult("Vous devez choisir au moins un restaurant", new[]{"ListeDeResto"});
        }
    }
}