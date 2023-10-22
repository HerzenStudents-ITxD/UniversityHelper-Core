using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Enum;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Requests;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using HerzenHelper.Core.BrokerSupport.Helpers;
using HerzenHelper.Core.Constants;
using HerzenHelper.Core.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HerzenHelper.Core.BrokerSupport.AccessValidatorEngine;

public class AccessValidator : IAccessValidator
{
  private readonly HttpContext _httpContext;
  private readonly ILogger<AccessValidator> _logger;
  private readonly IRequestClient<ICheckUserRightsRequest> _rcCheckRights;
  private readonly IRequestClient<ICheckUserIsAdminRequest> _rcCheckAdmin;
  private readonly IRequestClient<ICheckUserAnyRightRequest> _rcCheckAnyRights;
  private readonly IRequestClient<ICheckEventManagerRequest> _rcCheckProjectManager;
  private readonly IRequestClient<ICheckCommunityManagerRequest> _rcCheckDepartmentManager;

  private async Task<bool> IsUserAdminAsync(Guid userId)
  {
    return await RequestHandler.ProcessRequest<ICheckUserIsAdminRequest, bool>(
    _rcCheckAdmin,
    ICheckUserIsAdminRequest.CreateObj(userId),
    logger: _logger);
  }

  /// <summary>
  /// Constructor.
  /// </summary>
  public AccessValidator(
    IHttpContextAccessor httpContextAccessor,
    ILogger<AccessValidator> logger,
    IRequestClient<ICheckUserRightsRequest> rcCheckRights,
    IRequestClient<ICheckUserIsAdminRequest> rcCheckAdmin,
    IRequestClient<ICheckUserAnyRightRequest> rcCheckAnyRights,
    IRequestClient<ICheckEventManagerRequest> rcCheckProjectManager,
    IRequestClient<ICheckCommunityManagerRequest> rcCheckDepartmentManager)
  {
    _rcCheckRights = rcCheckRights;
    _rcCheckAdmin = rcCheckAdmin;
    _rcCheckAnyRights = rcCheckAnyRights;
    _rcCheckProjectManager = rcCheckProjectManager;
    _rcCheckDepartmentManager = rcCheckDepartmentManager;
    _httpContext = httpContextAccessor.HttpContext;
    _logger = logger;
  }

  /// <inheritdoc/>
  public async Task<bool> HasRightsAsync(params int[] rightIds)
  {
    return await HasRightsAsync(null, true, rightIds);
  }

  /// <inheritdoc/>
  public async Task<bool> HasRightsAsync(Guid? userId, params int[] rightIds)
  {
    return await HasRightsAsync(userId, true, rightIds);
  }

  public async Task<bool> HasRightsAsync(Guid? userId, bool includeIsAdminCheck, params int[] rightIds)
  {
    if (rightIds == null || !rightIds.Any())
    {
      throw new ArgumentException("Can not check empty rights array.", nameof(rightIds));
    }

    if (!userId.HasValue)
    {
      userId = _httpContext.GetUserId();
    }

    if (includeIsAdminCheck && await IsUserAdminAsync(userId.Value))
    {
      return true;
    }

    return await RequestHandler.ProcessRequest<ICheckUserRightsRequest, bool>(
      _rcCheckRights,
      ICheckUserRightsRequest.CreateObj(userId.Value, rightIds),
      logger: _logger);
  }

  /// <inheritdoc/>
  public async Task<bool> HasAnyRightAsync(params int[] rightIds)
  {
    return await HasAnyRightAsync(null, true, rightIds);
  }

  /// <inheritdoc/>
  public async Task<bool> HasAnyRightAsync(Guid? userId, params int[] rightIds)
  {
    return await HasAnyRightAsync(userId, true, rightIds);
  }

  public async Task<bool> HasAnyRightAsync(Guid? userId, bool includeIsAdminCheck, params int[] rightIds)
  {
    if (rightIds == null || !rightIds.Any())
    {
      throw new ArgumentException("Can not check empty rights array.", nameof(rightIds));
    }

    if (!userId.HasValue)
    {
      userId = _httpContext.GetUserId();
    }

    if (includeIsAdminCheck && await IsUserAdminAsync(userId.Value))
    {
      return true;
    }

    return await RequestHandler.ProcessRequest<ICheckUserAnyRightRequest, bool>(
      _rcCheckAnyRights,
      ICheckUserAnyRightRequest.CreateObj(userId.Value, rightIds),
      logger: _logger);
  }

  /// <inheritdoc/>
  public async Task<bool> IsAdminAsync(Guid? userId = null)
  {
    if (!userId.HasValue)
    {
      userId = _httpContext.GetUserId();
    }

    return await IsUserAdminAsync(userId.Value);
  }

  public async Task<bool> IsManagerAsync(ManagerSource managerSource, Guid entityId)
  {
    Guid userId = _httpContext.GetUserId();

    switch (managerSource)
    {
      case ManagerSource.Event:
        return await RequestHandler.ProcessRequest<ICheckEventManagerRequest, bool>(
          _rcCheckProjectManager,
          ICheckEventManagerRequest.CreateObj(userId, entityId),
          logger: _logger);
      case ManagerSource.Community:
        return await RequestHandler.ProcessRequest<ICheckCommunityManagerRequest, bool>(
          _rcCheckDepartmentManager,
          ICheckCommunityManagerRequest.CreateObj(userId, entityId),
          logger: _logger);
      default:
        return false;
    }
  }
}
