using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProject.CQRS.Commands.GuideCommands;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class DeleteGuideCommandHandler : IRequestHandler<DeleteGuideCommand>
    {
        private readonly Context _context;

        public DeleteGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
        {
            var guide = _context.Guides.Find(request.Id);
            if (guide != null)
            {
                _context.Guides.Remove(guide);
                await _context.SaveChangesAsync();
            }
        }
    }
}
