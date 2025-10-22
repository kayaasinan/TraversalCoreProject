using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProject.CQRS.Commands.GuideCommands;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideCommandHandler : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var guide = _context.Guides.Find(request.GuideId);
            if (guide != null)
            {
                guide.Name = request.Name;
                guide.Description = request.Description;
                guide.Status = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
