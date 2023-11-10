namespace UniversityHelper.Core.Constants;

/// <summary>
/// Rights give access to admin rights to the corresponding services or blocks
/// Admin, Feedback, Email, create/update Roles only work with admin rights
/// </summary>
/// Admin rights
/// <value name="AddGetEditRemoveUsers">Right grants admin rights to user</value>
/// <value name="AddGetEditRemoveLocationPositions">Right grants admin rights to location positions</value>
/// <value name="AddGetEditRemoveLocationAddictions">Right grants admin rights to location addictions</value>
/// <value name="AddGetEditRemoveCommunities">Right grants admin rights to communities</value>
/// <value name="AddGetEditRemoveEvents">Right grants admin rights to events</value>
/// <value name="AddGetEditRemoveUserRoles">Right grants admin rights to user roles</value>
/// Sugges
/// <value name="SuggestLocations">Right grants rights to suggest locations</value>
/// <value name="SuggestCommunities">Right grants rights to suggest communities</value>
/// <value name="SuggestEvents">Right grants rights to suggest events</value>
public static class Rights
{
  //Admin rights
  public const int AddGetEditRemoveUsers = 1;
  public const int AddGetEditRemoveLocationPositions = 2;
  public const int AddGetEditRemoveLocationAddictions = 3;
  public const int AddGetEditRemoveCommunities = 4;
  public const int AddGetEditRemoveEvents = 5;
  public const int AddGetEditRemoveUserRoles = 6;

  //Rights
  public const int SuggestLocations = 100;
  public const int SuggestCommunities = 101;
  public const int SuggestEvents = 102;
}
