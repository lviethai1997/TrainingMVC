using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Training.ViewModel.Catalog.OrderViewModel;

namespace Training.Service.Common
{
    public static class PrintBillExcel
    {
        public static string Css { get; set; }

        public static string Html { get; set; }

        public static async Task<List<object>> ExportExcel(OrderDetailView dataview, string filepath, Stream pathRs)
        {
            Task<byte[]> exportExcelTask = null;
            var list = new List<object>();
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

                var endRow = tableRange.End.Row + 1;
                var StartCol = tableRange.Start.Column;
                var endCol = tableRange.End.Column;
                var rowTotal = ws.Cells[endRow, StartCol, endRow, endCol];
                rowTotal.Merge = true;
                rowTotal.Style.Font.Bold = true;
                rowTotal.Style.Font.Size = 18;
                rowTotal.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                rowTotal.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowTotal.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                rowTotal.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rowTotal.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                rowTotal.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rowTotal.Value = "Tổng tiền thanh toán: " + dataview.TotalAmount.ToString("N0");

                var table = ws.Tables.GetFromRange(tableRange);
                table.ShowRowStripes = table.ShowRowStripes;
                ws.Cells.AutoFitColumns();
                //await package.SaveAsync();
                string lastAddress = ws.Dimension.Address;

                var exporter = ws.Cells[lastAddress].CreateHtmlExporter();
                //exporter.Settings.AdditionalTableClassNames.Add("epplus-table ts-dark1 ts-dark1-header ts-dark1-row-stripes table table-borderless dataTable no-footer");
                exporter.Settings.Minify = false;
                Css = await exporter.GetCssStringAsync();
                Html = await exporter.GetHtmlStringAsync();
                exportExcelTask = package.GetAsByteArrayAsync();

                list.Add(exportExcelTask);
                list.Add(Html);
                list.Add(Css);
            }

            return list;
        }
    }
}