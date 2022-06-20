using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRS.Handlers
{
    public class RemoveStudentCommandHandler:IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _context;

        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var deleteEntity = _context.Students.Find(command.Id);
            _context.Students.Remove(deleteEntity);
            _context.SaveChanges();
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deleteEntity = _context.Students.Find(request.Id);
            _context.Students.Remove(deleteEntity);
           await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
