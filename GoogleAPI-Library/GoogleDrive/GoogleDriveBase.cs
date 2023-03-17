using Google.Apis.Drive.v3;

namespace GoogleAPI_Library.GoogleDrive
{
    public abstract class GoogleDriveBase
    {
        protected DriveService Service;

        public GoogleDriveBase(DriveService driveService)
        {
            Service = driveService;
        }
    }
}
