using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Threading.Tasks;
using Training.ViewModel.Catalog.OrderViewModel;

namespace Training.Service.Common
{
    public static class PrintBillExcel
    {
        public static async Task<byte[]> ExportExcel(OrderDetailView dataview, string filepath, Stream pathRs)
        {
            Task<byte[]> exportExcelTask = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filepath)))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add(nameof(dataview));

                var pic = ws.Drawings.AddPicture("epplogo", pathRs, OfficeOpenXml.Drawing.ePictureType.Png);
                pic.SetSize(80);
                pic.SetPosition(0, 10, 0, 5);

                ws.Cells["A2"].Value = "Tên khác hàng: " + dataview.CustommerName;
                ws.Cells["A3"].Value = "Địa chỉ: " + dataview.CustommerAddress;
                ws.Cells["A4"].Value = "Email: " + dataview.CustommerEmail;
                ws.Cells["A5"].Value = "Số điện thoại: " + dataview.CustommerPhone;
                ws.Cells["A7"].Value = "Tổng số sản phẩm: " + dataview.TotalQty;
                ws.Cells["A8"].Value = "Trị giá đơn hàng: " + dataview.TotalAmount.ToString("N0");

                ws.Cells["A2:E8"].Style.Font.Bold = true;
                ws.Cells["A2:E8"].Style.Font.Size = 18;

                ws.Cells["A2:E2"].Merge = true;
                ws.Cells["A3:E3"].Merge = true;
                ws.Cells["A4:E4"].Merge = true;
                ws.Cells["A5:E5"].Merge = true;
                ws.Cells["A7:E7"].Merge = true;
                ws.Cells["A8:E8"].Merge = true;

                var tableRange = ws.Cells["A10"].LoadFromCollection(dataview.ListProducts, true, OfficeOpenXml.Table.TableStyles.Dark1);

                //ws.Cells[tableRange.Start.Row + 1, 4, tableRange.End.Row, 4].Style.Numberformat.Format = "yyyy-MM-dd";
                ws.Cells[tableRange.Start.Row, tableRange.Start.Column, tableRange.End.Row, tableRange.End.Column].Style.Numberformat.Format = "@";
                ws.Cells[tableRange.Start.Row, tableRange.Start.Column, tableRange.End.Row, tableRange.End.Column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[tableRange.Start.Row, tableRange.Start.Column, tableRange.End.Row, tableRange.End.Column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[tableRange.Start.Row, tableRange.Start.Column, tableRange.End.Row, tableRange.End.Column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[tableRange.Start.Row, tableRange.Start.Column, tableRange.End.Row, tableRange.End.Column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                var table = ws.Tables.GetFromRange(tableRange);
                table.ShowRowStripes = table.ShowRowStripes;
                ws.Cells.AutoFitColumns();

                await package.SaveAsync();

                exportExcelTask = package.GetAsByteArrayAsync();
            }
            return await exportExcelTask;
        }
    }
}