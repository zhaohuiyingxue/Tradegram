using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.UserGroups.Dtos
{
    public class UserGroupCreateOrEditDto : EntityDto<Guid?>
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public bool IsActive { get; set; }
        
        public Guid CustomerId { get; set; }
    }
}