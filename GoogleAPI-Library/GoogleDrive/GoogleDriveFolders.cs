using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using GoogleAPI_Library.Exceptions.GoogleDrive;
using GoogleAPI_Library.Models.GoogleDrive;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleAPI_Library.GoogleDrive
{
    public class GoogleDriveFolders : GoogleDriveBase
    {
        public GoogleDriveFolders(DriveService driveService) : base(driveService) { }

        public async Task<List<FolderModel>> GetFolders(string mainFolderId)
        {
            try
            {
                List<FolderModel> folders = new List<FolderModel>();

                FilesResource.ListRequest listRequest = Service.Files.List();
                listRequest.IncludeTeamDriveItems = true;
                listRequest.SupportsTeamDrives = true;
                listRequest.OrderBy = "name";
                listRequest.PageSize = 100;
                listRequest.Q = $"parents in '{mainFolderId}'";

                FileList files = await listRequest.ExecuteAsync();

                foreach (File file in files.Files)
                {
                    folders.Add(new FolderModel
                    {
                        Name = file.Name,
                        Id = file.Id,
                    });
                }

                return folders;
            }
            catch (Exception ex)
            {
                throw new GoogleDriveException(ex.Message);
            }
        }
    }
}