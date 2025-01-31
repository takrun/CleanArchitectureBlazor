﻿using CleanArchitecture.Application.Common.Services.Identity;
using CleanArchitecture.WebUI.Shared.Authorization;

namespace CleanArchitecture.Application.AccessControl.Commands;

public record UpdateAccessControlCommand(string RoleId, Permissions Permissions): IRequest;

public class UpdateAccessControlCommandHandler : AsyncRequestHandler<UpdateAccessControlCommand>
{
    private readonly IIdentityService _identityService;

    public UpdateAccessControlCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    protected override async Task Handle(UpdateAccessControlCommand request, CancellationToken cancellationToken)
    {
        await _identityService.UpdateRolePermissionsAsync(request.RoleId, request.Permissions);
    }
}
