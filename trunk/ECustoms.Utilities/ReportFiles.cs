using System;
using System.Data;
using System.Drawing;
using ReportPrinting;
using ECustoms.Utilities.Enums;

namespace ECustoms.Utilities
{
    public class ReportFiles : IReportMaker
    {
        #region IReportMaker Members

        private readonly DataTable _dt;
        private readonly string _reportName;
        private readonly ReportType _reportType;

        public void MakeDocument(ReportDocument reportDocument)
        {
            TextStyle.ResetStyles();

            TextStyle.Normal.Size = 7.5f;
            TextStyle.Heading1.Size = 16;
            TextStyle.Heading1.Bold = false;
            TextStyle.TableHeader.BackgroundBrush = Brushes.Gray;
            TextStyle.TableHeader.Brush = Brushes.White;
            TextStyle.TableHeader.MarginNear = 0.1f;
            TextStyle.TableHeader.MarginFar = 0.1f;
            TextStyle.TableHeader.MarginTop = 0.05f;
            TextStyle.TableHeader.MarginBottom = 0.05f;
            TextStyle.TableRow.MarginNear = 0.1f;
            TextStyle.TableRow.MarginFar = 0.1f;
            TextStyle.TableRow.MarginTop = 0.05f;


            ReportBuilder builder = new ReportBuilder(reportDocument);
            
            builder.StartLinearLayout(Direction.Vertical);

            Pen innerPen = new Pen(Color.Green, 0.02f);

            //DataView dv = SampleReportMaker1.GetDataView();
            DataView dv = _dt.DefaultView;
            builder.AddPageHeader("Người tạo: Đỗ Đình Vương", String.Empty, "Trang %p");
            builder.AddPageHeaderLine();
            builder.AddText(_reportName);
            builder.AddText("àd");
            builder.PageHeader.MarginRight  = 00;
            builder.PageHeader.UseFullWidth = true;

            builder.CurrentContainer.UseFullWidth = true;
            //builder.AddText("Table with lines using default lines\n");
            // Following line sets up the pen used for lins for tables
            builder.DefaultTablePen = reportDocument.ThinPen;
            builder.AddTable(dv, true);
            builder.CurrentSection.HorizontalAlignment = HorizontalAlignment.Left;
            
            foreach (DataColumn column in _dt.Columns)
            {

                //builder.AddColumn(column.ColumnName, column.ColumnName, 1.8f, true, true);
                builder.AddColumn(column.ColumnName, column.ColumnName, 1f, true, true);

            }

            builder.CurrentDocument.Body.UseFullWidth = true;
            
            builder.FinishLinearLayout();
        }

        #endregion

        public ReportFiles(DataTable dataTable, string reportName,  ReportType reportType)
        {
            _dt = dataTable;
            _reportName = reportName;
            _reportType = reportType;

        }
    }
}
