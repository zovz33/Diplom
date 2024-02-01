using Diplom.ASPNET.Application.Common.Exceptions;
using Diplom.ASPNET.Application.Interfaces;
using MediatR;

namespace Diplom.ASPNET.Application.Items.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteUserCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null || entity.Id != request.Id) throw new NotFoundException(nameof(User), request.Id);

        _dbContext.Users.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}