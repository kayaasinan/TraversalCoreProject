using MediatR;

namespace TraversalCoreProject.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand : IRequest
    {

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? XUrl { get; set; }
        public string? InstagramUrl { get; set; }
    }
}
