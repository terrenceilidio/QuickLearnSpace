using Abp.Application.Services.Dto;

namespace QuickLearnSpace.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

