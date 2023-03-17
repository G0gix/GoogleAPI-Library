# GoogleAPI-Library
This library is an add-on to the existing library from Google, which allows you to interact programmatically  with various Google services, such as Google Drive, Google Sheets

The goal of this project is to make it easier to interact with Google services, and to reduce code duplication in projects where interaction with Google is required.

## ⚠️ Not full functionality
Library functionality is added as needed. Because of this, the library does not implement all of the available functionality.

## Google services used:
1) Google Drive
2) Google Sheets

## 🚀 How to use
Currently, the library provides two classes for interfacing with Google services:
```cs
GoogleDriveManager drive = new GoogleDriveManager(DriveService);
GoogleSheetsManager sheets = new GoogleSheetsManager(SheetsService);
```

Every class that interacts with Google takes a descendant of the **BaseClientService** class in its constructor

For Drive API this is **DriveService**, for Sheets API **SheetsService**

## 🤝 Contributing
Contributions, issues and feature requests are welcome.
Feel free to check issues page if you want to contribute.



