using BS.Application.Menus.Commands.CreateMenu;
using BS.Contracts.Menus;
using BS.Domain.MenuAggregates;

using Mapster;

using MenuSection = BS.Domain.MenuAggregates.Entities.MenuSection;
using MenuItem = BS.Domain.MenuAggregates.Entities.MenuSection;

namespace BS.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                 .Map(dest => dest.HostId, src => src.HostId)
                 .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating, src => src.AverageRating)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(i=>i.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(i => i.Value))
                ;


            config.NewConfig<MenuSection, MenuSectionResponse>()
             .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
