using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using GoogleAPI_Library.Exceptions.GoogleSheets;
using GoogleAPI_Library.Models.GoogleSheet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleAPI_Library
{
    /// <summary>
    /// Allows you to perform basic operations with Google Spreadsheet.
    /// The call to the InitializeAsync method is required
    /// </summary>
    public class GoogleSheetsManager
    {
        private SheetsService Service;

        public GoogleSheetsManager(SheetsService service)
        {
            Service = service;
        }

        /// <summary>
        /// Allows to insert data from the table according to the specified settings.
        /// API key is not supported as a credential for this method
        /// </summary>
        /// <param name="writeOptions">Data insertion settings</param>
        /// <param name="dataToInsert">Data to insert</param>
        /// <returns></returns>
        /// <exception cref="GoogleSheetsException">Represents errors that occur during request to Google sheets.</exception>
        public async Task WriteAsync(GoogleSheetOptions writeOptions, IList<IList<object>> dataToInsert)
        {
            try
            {
                if (dataToInsert.Count == 0 || dataToInsert == null)
                {
                    return;
                }

                ValueRange valueRange = new ValueRange();
                valueRange.Values = dataToInsert;

                var appendRequest = Service.Spreadsheets.Values.Append(valueRange, writeOptions.SheetId, writeOptions.SheetRange);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                await appendRequest.ExecuteAsync();
            }
            catch (Exception ex)
            {
                throw new GoogleSheetsException(ex.Message);
            }
        }

        /// <summary>
        /// Allows to get data from the table according to the specified settings.
        /// </summary>
        /// <param name="readOptions"></param>
        /// <returns></returns>
        /// <exception cref="GoogleSheetsException"></exception>
        public async Task<IList<IList<Object>>> ReadAsync(GoogleSheetOptions readOptions)
        {
            try
            {
                var request = Service.Spreadsheets.Values.Get(readOptions.SheetId, readOptions.SheetRange);
                ValueRange response = await request.ExecuteAsync();

                IList<IList<Object>> values = response.Values;
                return values;
            }
            catch (Exception e)
            {
                throw new GoogleSheetsException(e.Message);
            }
        }
    }
}
