using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class CountryGetListInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }
}