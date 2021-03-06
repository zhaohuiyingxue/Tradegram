using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string PriceRanges { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }
        
        public string LanguageCode { get; set; }
        
        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }
        
        public bool ShowOnHomePage { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public DateTime? PublishedOn { get; set; }
        
        public Guid? ParentCategoryId { get; set; }
        
        public Guid CategoryTemplateId { get; set; }

        public Guid PictureId { get; set; }
        
        public CategoryDto ParentCategory { get; set; }
        
        public IReadOnlyList<CategoryDto> Children { get; set; }
    }
}