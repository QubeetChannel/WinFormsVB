Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Text.RegularExpressions
Imports System.IO


Public Class Form1

    Dim filePath As String
    Dim connectionString As String
    Dim spreadsheet As SpreadsheetDocument

    Private Sub OpenExcelFileStrip_Click(sender As Object, e As EventArgs) Handles OpenExcelFileStrip.Click
        Try
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                filePath = OpenFileDialog.FileName
                OpenFile(filePath)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveFileStrip_Click(sender As Object, e As EventArgs) Handles SaveFileStrip.Click
        Try
            Dim package As New OfficeOpenXml.ExcelPackage(New FileInfo(filePath))
            For Each tabPage In TabControl.Controls
                Dim customDataGridView As CustomDataGridView = tabPage.Controls(0)
                Dim worksheet = package.Workbook.Worksheets(TabControl.TabPages.IndexOf(tabPage))
                For Each r As DataGridViewRow In customDataGridView.Rows
                    For Each c As DataGridViewCell In r.Cells
                        worksheet.Cells(c.RowIndex + 1, c.ColumnIndex + 1).Value = c.Value
                    Next
                Next
            Next

            package.Save()
            MessageBox.Show("Файл успешно сохранен!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OpenFile(filePath As String)
        Using spreadsheet As SpreadsheetDocument = SpreadsheetDocument.Open(filePath, True)
            Dim workbookPart = spreadsheet.WorkbookPart
            Dim workbook = workbookPart.Workbook
            Dim sheets = workbook.Sheets

            TabControl.TabPages.Clear()
            Dim worksheetPartIndex = 0
            For Each sheet In sheets
                Dim worksheetPart = workbookPart.WorksheetParts(worksheetPartIndex)
                Dim sheetData = worksheetPart.Worksheet.Elements(Of SheetData)().First()

                If sheetData.Elements(Of Row)().Count() <> 0 Then
                    Dim TabPage As New TabPage
                    Dim customDataGridView As New CustomDataGridView
                    Dim sheetName As String = sheet.GetAttributes(0).Value
                    customDataGridView.Dock = DockStyle.Fill
                    TabPage.Text = sheetName
                    TabPage.Controls.Add(customDataGridView)
                    TabControl.TabPages.Add(TabPage)

                    Dim reference = worksheetPart.Worksheet.SheetDimension.Reference
                    Dim cellRefs() As String = reference.Value.Split(":"c)
                    Dim endCellRef() As Char = cellRefs(1).Where(Function(c) Char.IsLetter(c)).ToArray()
                    Dim ColumnSize As Integer = GetColumnIndex(endCellRef)
                    Dim RowSize As Integer = Integer.Parse(cellRefs(1).Substring(endCellRef.Length))

                    For col = 1 To ColumnSize
                        Dim newColumn As New DataGridViewTextBoxColumn()
                        customDataGridView.Columns.Add(newColumn)
                    Next
                    For row = 1 To RowSize - 1
                        customDataGridView.Rows.Add()
                    Next

                    For Each r As Row In sheetData
                        For Each c As Cell In r
                            Dim rowIndex As Integer = r.RowIndex.InnerText - 1
                            Dim cellIndex As Integer = GetColumnIndex(Regex.Replace(c.CellReference, "\d", "")) - 1

                            customDataGridView.Rows(rowIndex).Cells(cellIndex).Value = GetCellValue(c, workbookPart)
                        Next
                    Next

                    worksheetPartIndex += 1
                End If
            Next
        End Using
    End Sub

    Private Function GetCellValue(ByVal cell As Cell, ByVal workbookPart As WorkbookPart) As String
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
            Dim sharedStringTable As SharedStringTable = workbookPart.SharedStringTablePart.SharedStringTable
            Return sharedStringTable.ElementAt(Integer.Parse(cell.CellValue.Text)).InnerText
        End If

        Return cell.CellValue.Text
    End Function

    Function GetColumnIndex(columnRef() As Char) As Integer
        Dim index As Integer = 0
        For Each c As Char In columnRef
            index = index * 26 + (Asc(Char.ToUpper(c)) - Asc("A")) + 1
        Next
        Return index
    End Function
End Class
