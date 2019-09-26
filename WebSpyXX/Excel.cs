using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HPSF;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebSpyXX
{
    class Excel
    {
        private HSSFWorkbook _hssfWorkbook;

        public Excel() { }

        #region 一、基本操作

        //新建一个工作薄
        public void Create()
        {
            _hssfWorkbook = new HSSFWorkbook();
        }

        public void Close()
        {
            _hssfWorkbook.Close();
        }

        //创建表  提示：工作薄中至少要创建一个表
        public HSSFSheet CreateSheet(string sheetName)
        {
            return _hssfWorkbook.CreateSheet(sheetName) as HSSFSheet;
        }

        //演示用的模板，后面单元格边框问题介绍使用
        public void CreateTemplate(HSSFSheet sheet, int rowCount, int colCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                //npoi中每行以及每个需要用到的单元格都要去创建，不创建就无法使用，当然，不用的单元格可以不用创建
                HSSFRow row = sheet.CreateRow(i) as HSSFRow;
                for (int j = 0; j < colCount; j++)
                {
                    HSSFCell cell = row.CreateCell(j) as HSSFCell;
                }
            }
        }

        #endregion

        #region 二、合并单元格

        //这里说一下，合并单元格可以在创建单元格之前使用，也就是不需要单元格真正的存在，所以使用合并单元格时只需要创建合并后的第一个单元格即可
        //后面我会给使用案例

        public void AddMergedRegion(HSSFSheet sheet, int firstRow, int lastRow, int firstCol, int lastCol)
        {
            sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
        }

        #endregion

        #region 三、单元格样式

        //npoi中单个工作薄最多可以创建4000个单元格样式，当时我也是卡在单元格样式这块卡了半天
        //npoi中会默认创建一个单元格样式，也就是我们在新建excel中看到的那种样式
        //每当我们创建一个单元格时，单元格样式默认为上述的单元格样式
        //为什么要强调这个默认的单元格样式呢？因为我被他坑过（泪奔。。。）
        //如果你要设置某个单元格的单元格样式，一定要先创建新的单元格样式，切勿直接修改，因为你会发现影响的可不只是这一个单元格
        //当时我傻傻的认为每个单元格都有自己的样式，结果他们的样式都指向系统创建的默认的样式，而不是自己new的
        //具体的使用后面呈现

        #endregion

        #region 四、单元格边框问题

        //我们在excel中设置边框非常方便，鼠标拖一下，右击设置单元格样式，设置边框即可，但是在npoi可没这么简单，这个过程我们要用代码写出来
        //主观上边框分为外边框和内边框
        //但实际上投射到单元格就是16种单元格样式的组合！！

        private ICellStyle GetCellBorderStyle(int style, NPOI.SS.UserModel.BorderStyle outStyle, NPOI.SS.UserModel.BorderStyle inStyle)
        {
            ICellStyle cellStyle = _hssfWorkbook.CreateCellStyle();

            cellStyle.BorderTop = inStyle;
            cellStyle.BorderLeft = inStyle;
            cellStyle.BorderRight = inStyle;
            cellStyle.BorderBottom = inStyle;

            switch (style)
            {
                //九宫格中间的样式	
                case 0:
                    break;

                //九宫格左上角样式
                case 1:
                    cellStyle.BorderTop = outStyle;
                    cellStyle.BorderLeft = outStyle;
                    break;

                //九宫格上方样式
                case 2:
                    cellStyle.BorderTop = outStyle;
                    break;

                //九宫格右上角样式															
                case 3:
                    cellStyle.BorderTop = outStyle;
                    cellStyle.BorderRight = outStyle;
                    break;

                //九宫格右边样式
                case 4:
                    cellStyle.BorderRight = outStyle;
                    break;

                //九宫格右下角样式
                case 5:
                    cellStyle.BorderBottom = outStyle;
                    cellStyle.BorderRight = outStyle;
                    break;

                //九宫格下方样式
                case 6:
                    cellStyle.BorderBottom = outStyle;
                    break;

                //九宫格左下角样式
                case 7:
                    cellStyle.BorderBottom = outStyle;
                    cellStyle.BorderLeft = outStyle;
                    break;

                //九宫格左边样式
                case 8:
                    cellStyle.BorderLeft = outStyle;
                    break;

                //单行单列样式
                case 9:
                    cellStyle.BorderTop = outStyle;
                    cellStyle.BorderLeft = outStyle;
                    cellStyle.BorderRight = outStyle;
                    cellStyle.BorderBottom = outStyle;
                    break;

                //单列多行上方样式
                case 10:
                    cellStyle.BorderTop = outStyle;
                    cellStyle.BorderLeft = outStyle;
                    cellStyle.BorderRight = outStyle;
                    break;
                //单列多行中间样式

                case 11:
                    cellStyle.BorderLeft = outStyle;
                    cellStyle.BorderRight = outStyle;
                    break;

                //单列多行下方样式
                case 12:
                    cellStyle.BorderLeft = outStyle;
                    cellStyle.BorderRight = outStyle;
                    cellStyle.BorderBottom = outStyle;
                    break;

                //单行多列右边样式
                case 13:
                    cellStyle.BorderTop = outStyle;
                    cellStyle.BorderRight = outStyle;
                    cellStyle.BorderBottom = outStyle;
                    break;

                //单行多列中间样式
                case 14:
                    cellStyle.BorderTop = outStyle;
                    cellStyle.BorderBottom = outStyle;
                    break;

                //单行多列下方样式
                case 15:
                    cellStyle.BorderTop = outStyle;
                    cellStyle.BorderLeft = outStyle;
                    cellStyle.BorderBottom = outStyle;
                    break;
                default:
                    break;


            }

            return cellStyle;
        }


        //outStyle为外边框样式， inStyle为内边框样式，颜色如果想换的话可以自己写函数，这里例子就不再写了
        public void SetCellBorder(HSSFSheet sheet, NPOI.SS.UserModel.BorderStyle outStyle, NPOI.SS.UserModel.BorderStyle inStyle)
        {
            ICellStyle style = GetCellBorderStyle(0, outStyle, inStyle);
            ICellStyle styleTop = GetCellBorderStyle(2, outStyle, inStyle);
            ICellStyle styleRight = GetCellBorderStyle(4, outStyle, inStyle);
            ICellStyle styleBottom = GetCellBorderStyle(6, outStyle, inStyle);
            ICellStyle styleLeft = GetCellBorderStyle(8, outStyle, inStyle);

            int firstRowNum = sheet.FirstRowNum;
            int lastRowNum = sheet.LastRowNum;

            for (int i = firstRowNum; i <= lastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                int firstCellNum = row.FirstCellNum;
                int lastCellNum = row.LastCellNum;

                for (int j = firstCellNum; j < lastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);

                    if (lastCellNum == 0)
                    {

                        //单行单列
                        if (lastRowNum == 0)
                            cell.CellStyle = GetCellBorderStyle(9, outStyle, inStyle);
                        else
                        {
                            //单列多行
                            if (i == 0)
                                cell.CellStyle = GetCellBorderStyle(10, outStyle, inStyle);
                            else if (i == lastRowNum)
                                cell.CellStyle = GetCellBorderStyle(12, outStyle, inStyle);
                            else
                                cell.CellStyle = GetCellBorderStyle(15, outStyle, inStyle);
                        }
                    }
                    else if (lastRowNum == 0)
                    {
                        //单行多列

                        if (j == 0)
                            cell.CellStyle = GetCellBorderStyle(11, outStyle, inStyle);
                        else if (j == lastCellNum - 1)
                            cell.CellStyle = GetCellBorderStyle(13, outStyle, inStyle);
                        else
                            cell.CellStyle = GetCellBorderStyle(14, outStyle, inStyle);

                    }
                    //多行多列
                    else
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                                cell.CellStyle = GetCellBorderStyle(1, outStyle, inStyle);
                            else if (j == lastCellNum - 1)
                                cell.CellStyle = GetCellBorderStyle(3, outStyle, inStyle);
                            else
                                cell.CellStyle = styleTop;
                        }
                        else if (i == lastRowNum)
                        {
                            if (j == 0)
                                cell.CellStyle = GetCellBorderStyle(7, outStyle, inStyle);
                            else if (j == lastCellNum - 1)
                                cell.CellStyle = GetCellBorderStyle(5, outStyle, inStyle);
                            else
                                cell.CellStyle = styleBottom;
                        }
                        else
                        {
                            if (j == 0)
                                cell.CellStyle = styleLeft;
                            else if (j == lastCellNum - 1)
                                cell.CellStyle = styleRight;
                            else
                                cell.CellStyle = style;
                        }
                    }
                }
            }
        }

        #endregion

        #region 五、筛选

        //重点提一下 reference
        //单列筛选时 类似 SetAutoFilter(sheet, "B1")即可
        //多列筛选时 类型 SetAutoFilter(sheet, "A1:D1")  表示从A1单元格到D1单元格的4个单元格建立筛选
        //每个表中只能建立一个筛选
        //多次调用以最后一次为准
        //除了上面两种方式没有别的方式，所以不可以间隔单元格建立筛选，所以提醒大家把需要做筛选的列放到一起去，中间不要有其他单元格间隔
        public void SetAutoFilter(string sheetName, string reference)
        {
            CellRangeAddress range = CellRangeAddress.ValueOf(reference);

            _hssfWorkbook.GetSheet(sheetName).SetAutoFilter(range);
        }

        #endregion

        #region 六、批注
        public void SetComment(HSSFSheet sheet, HSSFCell cell, string reference, string commentText, string author)
        {
            HSSFPatriarch patr = sheet.CreateDrawingPatriarch() as HSSFPatriarch;
            HSSFComment comment1 = patr.CreateComment(new HSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 4));
            comment1.String = new HSSFRichTextString(commentText);
            comment1.Author = author;

            cell.CellComment = comment1;
        }
        #endregion

        #region 六、导出

        //选择保存路径
        public SaveFileDialog SelectExportPath(string fileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XLS files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出";
            saveFileDialog.FileName = fileName;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
                return saveFileDialog;
            else
                return null;
        }

        //导出
        public void ExportToExcel(SaveFileDialog saveFileDialog)
        {
            if (saveFileDialog == null)
                return;
            Stream myStream = saveFileDialog.OpenFile();
            _hssfWorkbook.Write(myStream);
            myStream.Close();
        }

        //导入
        public void ImportFile(string importFilePath)
        {
            FileStream file = new FileStream(importFilePath, FileMode.Open, FileAccess.Read);
            _hssfWorkbook = new HSSFWorkbook(file);
        }
        #endregion

        #region 七、使用

        //第一种情况，预先不知道多少行，但是表格格式统一，表格中没有特殊单元格，比如合并啊，居中啥的，这种情况边框放到最后加

        //DataGridView是winform中类型表格的控件
        public void ConvertDGVToSheet(DataGridView dv, string sheetName)
        {
            HSSFSheet sheet = CreateSheet(sheetName);

            //冻结标题行
            sheet.CreateFreezePane(0, 1, 0, 1);


            //写标题
            IRow colHeader = sheet.CreateRow(0);

            for (int i = 0; i < dv.ColumnCount; i++)
            {
                if (dv.Columns[i].Visible)
                {
                    colHeader.CreateCell(i).SetCellValue(dv.Columns[i].HeaderText);
                }
            }


            //写内容


            //int tmp = 1;

            for (int j = 0; j < dv.Rows.Count; j++)
            {
                IRow row = sheet.CreateRow(j + 1);


                for (int k = 0; k < dv.Columns.Count; k++)
                {
                    if (dv.Columns[k].Visible)
                        row.CreateCell(k).SetCellValue(dv.Rows[j].Cells[k].FormattedValue.ToString());


                }
            }


            //自动调整列间距
            for (int i = 0; i < dv.ColumnCount; i++)
                sheet.AutoSizeColumn(i);
            SetCellBorder(sheet, NPOI.SS.UserModel.BorderStyle.Dashed, NPOI.SS.UserModel.BorderStyle.Thin);
        }

        //第二种情况，有模板，知道那些行列需要合并等，固定行数列数

        public void ExportAnalysisResult(DataGridView dv)
        {
            HSSFSheet sheet = _hssfWorkbook.CreateSheet("分析结果") as HSSFSheet;


            CreateTemplate(sheet, 50, 6);
            SetCellBorder(sheet, NPOI.SS.UserModel.BorderStyle.Dashed, NPOI.SS.UserModel.BorderStyle.Thin);



            //设置列宽度
            sheet.SetColumnWidth(0, 256 * 4);
            sheet.SetColumnWidth(1, 256 * 22);
            sheet.SetColumnWidth(2, 256 * 11);
            sheet.SetColumnWidth(3, 256 * 21);
            sheet.SetColumnWidth(4, 256 * 7);
            sheet.SetColumnWidth(5, 256 * 28);


            IRow row = sheet.GetRow(0);
            ICell cell = row.GetCell(0);
            cell.SetCellValue("分析结果单");
            ICellStyle style = _hssfWorkbook.CreateCellStyle();

            //注意新建单元格样式的时候一定要克隆一下，否则单元格之前的样式就没了
            style.CloneStyleFrom(cell.CellStyle);
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            IFont font = _hssfWorkbook.CreateFont();
            font.FontHeight = 20 * 20;
            style.SetFont(font);
            cell.CellStyle = style;
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));

            IRow colHeader = sheet.GetRow(2);
            //写标题
            for (int i = 0; i < dv.ColumnCount; i++)
            {
                if (dv.Columns[i].Visible)
                {
                    if (i < 3)
                    {
                        colHeader.GetCell(i).SetCellValue(dv.Columns[i].HeaderText);
                        if (i == 2)
                            colHeader.GetCell(i + 1);
                    }
                    else
                    {
                        colHeader.GetCell(i + 1).SetCellValue(dv.Columns[i].HeaderText);
                    }
                }
            }
            sheet.AddMergedRegion(new CellRangeAddress(2, 2, 2, 3));

            //强制重新计算
            sheet.ForceFormulaRecalculation = true;
        }
        #endregion

        private string GetShowText(List<DataInfo> dataList, string showAttr, out string attrText)
        {
            string text = "";
            string attr = "";
            foreach (var data in dataList)
            {
                if (data.Type == "LABEL" || data.Type == "HEAD" || data.Type == "SUBHEAD")
                    text += data.Text;

                object value;
                object type;

                if(data.Attr.TryGetValue("type", out type))
                {
                    if (type.ToString() == "hidden")
                        continue;
                }

                if (showAttr.Length > 0 && data.Attr.TryGetValue(showAttr, out value))
                {
                    attr += "[" + data.Id + "]";
                    attr += value.ToString();
                }

                string childAttr;
                text += GetShowText(data.Children, showAttr, out childAttr);
                attr += childAttr;
            }

            attrText = attr;
            return text;
        }

        public void CreateSheetByTable(Table table)
        {
            int colCount = 0;
            int rowCount = 0;
            int colHeight = 0;
            int rowWidth = 0;

            Dictionary<int, int> rowHeightDic = new Dictionary<int, int>();
            Dictionary<int, int> colWidthDic = new Dictionary<int, int>();

            // 获取行列，行高，列宽
            foreach (var cell in table.Cells)
            {
                if (cell.Col + 1 > colCount)
                    colCount = cell.Col + 1;

                if (cell.Row + 1 > rowCount)
                    rowCount = cell.Row + 1;

                if(cell.RowSpan == 1 && !rowHeightDic.TryGetValue(cell.Row, out colHeight))
                {
                    rowHeightDic[cell.Row] = cell.Height;
                }

                if(cell.DataList[0].Type != "HEAD" && cell.DataList[0].Type != "SUBHEAD" && cell.ColSpan == 1 && !colWidthDic.TryGetValue(cell.Col, out rowWidth))
                {
                    colWidthDic[cell.Col] = cell.Width;
                }
            }

            HSSFSheet sheet = CreateSheet(table.Cells[0].DataList[0].Text);

            CreateTemplate(sheet, rowCount, colCount);


            foreach (var cell in table.Cells)
            {
                if(cell.DataList[0].Type == "HEAD" || cell.DataList[0].Type == "SUBHEAD")
                {
                    sheet.AddMergedRegion(new CellRangeAddress(cell.Row, cell.Row, cell.Col, colCount - 1));
                }
                else
                {
                    if (cell.ColSpan != 1 || cell.RowSpan != 1)
                    {
                        sheet.AddMergedRegion(new CellRangeAddress(cell.Row, cell.Row + cell.RowSpan - 1, cell.Col, cell.Col + cell.ColSpan - 1));
                    }
                }

                string attrText;
                string text = GetShowText(cell.DataList, cell.ShowAttr, out attrText);
               
                IRow irow = sheet.GetRow(cell.Row);
                //irow.HeightInPoints = cell.Height;
                ICell iCell = irow.GetCell(cell.Col);

                if (attrText.Length > 0)
                    iCell.SetCellValue(attrText);
                else
                    iCell.SetCellValue(text);
            }

            SetCellBorder(sheet, NPOI.SS.UserModel.BorderStyle.Medium, NPOI.SS.UserModel.BorderStyle.Thin);

            foreach (var item in colWidthDic)
            {
                sheet.SetColumnWidth(item.Key, item.Value * 40);
            }

            string exportFileName = sheet.SheetName + ".xls";

            SaveFileDialog dlg = SelectExportPath(exportFileName);
            ExportToExcel(dlg);
        }
    }
}
