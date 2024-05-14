using BS.Application.Persistence;
using BS.Domain.Host.ValueObjects;
using BS.Domain.MenuAggregates;

using ErrorOr;

using MediatR;

namespace BS.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<BS.Domain.MenuAggregates.Menu>>
    {
        private readonly IMenuRepository _menuRepository;
        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<BS.Domain.MenuAggregates.Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // Create MenuAggregates
            var menu = BS.Domain.MenuAggregates.Menu.Create(
            hostId: HostId.Create( Guid.Parse( request.HostId)),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(sections => BS.Domain.MenuAggregates.Entities.MenuSection.Create(
                name: sections.Name,
                description: sections.Description,
                items: sections.Items.ConvertAll(items => BS.Domain.MenuAggregates.ValueObjects.MenuItem.Create(
                name: items.Name,
                    description: items.Description)))));

            _menuRepository.Add(menu);
            // Persist MenuAggregates
            // Return MenuAggregates
            return menu;
        }
    }
}
