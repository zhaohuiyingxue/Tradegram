using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerDto : EntityDto<Guid>
    {
        public Guid? TenantId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}