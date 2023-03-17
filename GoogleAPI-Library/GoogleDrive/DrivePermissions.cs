using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using GoogleAPI_Library.Exceptions.GoogleDrive;
using GoogleAPI_Library.Models.GoogleDrive.Permissions;
using System;
using System.Threading.Tasks;

namespace GoogleAPI_Library.GoogleDrive
{
    public class DrivePermissions : GoogleDriveBase
    {
        public DrivePermissions(DriveService driveService) : base(driveService) { }

        public async Task AddUserToFile(PermissionRole role, PermissionsType type, string userEmail, string driveItemId, bool sendNotificationEmail)
        {
            try
            {
                Permission newPermission = new Permission(); 
                        
                newPermission.Type = type.ToString();
                newPermission.EmailAddress = userEmail;
                newPermission.Role = role.ToString();

                PermissionsResource.CreateRequest request = Service.Permissions.Create(newPermission, driveItemId);
                request.SendNotificationEmail = sendNotificationEmail;

                await request.ExecuteAsync();
            }
            catch (Exception ex)
            {
                throw new GoogleDriveException(ex.Message);
            }
        }
    }
}
