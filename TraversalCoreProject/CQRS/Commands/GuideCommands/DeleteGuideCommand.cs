using MediatR;

namespace TraversalCoreProject.CQRS.Commands.GuideCommands
{
    public class DeleteGuideCommand : IRequest
    {
        public DeleteGuideCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
