using Google.Apis.Drive.v3;
using GoogleAPI_Library.Exceptions.GoogleDrive;
using System;

namespace GoogleAPI_Library.GoogleDrive
{
    public class GoogleDriveManager : GoogleDriveBase
    {
        public GoogleDriveFolders Folders { get; set; }
        public DrivePermissions Permissions { get; set; }

        public GoogleDriveManager(DriveService driveService) : base(driveService)
        {
            try
            {
                Folders = new GoogleDriveFolders(Service);
                Permissions = new DrivePermissions(Service);
            }
            catch (Exception ex)
            {
                throw new GoogleDriveException(ex.Message);
            }
        }
    }
}
