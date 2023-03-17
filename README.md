# GoogleAPI-Library
This library is an add-on to the existing library from Google, which allows you to interact programmatically  with various Google services, such as Google Drive, Google Sheets

The goal of this project is to make it easier to interact with Google services, and to reduce code duplication in projects where interaction with Google is required.

## ⚠️ Not full functionality
Library functionality is added as needed. Because of this, the library does not implement all of the available functionality.

## Google services used:
1) Google Drive
2) Google Sheets

<br/>

## 🚀 How to use
Currently, the library provides two classes for interfacing with Google services:
```cs
GoogleDriveManager drive = new GoogleDriveManager(DriveService);
GoogleSheetsManager sheets = new GoogleSheetsManager(SheetsService);
```

Every class that interacts with Google takes a descendant of the **BaseClientService** class in its constructor

For Drive API this is **DriveService**, for Sheets API **SheetsService**

## Google Sheets
```cs
GoogleSheetOptions options = new GoogleSheetOptions
{
  SheetId = "Your Sheet id",
  SheetRange = "Your Sheet Name"
};

// Reading data from Google Sheet
GoogleSheetsManager googleSheetsManager = new GoogleSheetsManager(SheetsService);
var data = await googleSheetsManager.ReadAsync(options);

// Writing data into Google Sheets
var dataToInsert = new List<IList<object>> { new object[] { "data", "data2", "data3" } };
await googleSheetsManager.WriteAsync(options, dataToInsert);
```

## Google Drive
### Get subfolders in the main folder:
```cs
string mainFolderId = "Your main folder ID";
GoogleDriveManager manager = new GoogleDriveManager(DriveService);
List<FolderModel> folders = await manager.Folders.GetFolders(mainFolderId);
 
foreach (FolderModel folder in folders)
{
  Console.WriteLine($"name {folder.Name} id: {folder.Id}");
}
```

### Add Permissions to Folder:
```cs
GoogleDriveManager manager = new GoogleDriveManager(DriveService);
await manager.Permissions.AddUserToFile(PermissionRole.writer, PermissionsType.user, "mail@gmail.com", "Folder ID", false);
```
### To use the Service account for Google Drive:
```cs
GoogleCredential credential = GoogleCredential.FromFile(SecretPath).CreateScoped(DriveService.ScopeConstants.Drive);

DriveService service = new DriveService(new BaseClientService.Initializer()
{
  HttpClientInitializer = credential,
  ApplicationName = AppName
});
```

<br/>

## 🤝 Contributing
Contributions, issues and feature requests are welcome.
Feel free to check issues page if you want to contribute.
