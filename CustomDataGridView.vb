Public Class CustomDataGridView
    Inherits DataGridView

    Dim columnIndex As Integer
    Dim CellContextMenu As New ContextMenuStrip()

    Dim menuItem1 As New ToolStripMenuItem("Добавить столбец слева", Nothing, AddressOf AddColumnLeft)
    Dim menuItem2 As New ToolStripMenuItem("Добавить столбец справа", Nothing, AddressOf AddColumnRight)
    Dim menuItem3 As New ToolStripMenuItem("Удалить столбец", Nothing, AddressOf DeleteColumn)

    Public Sub New()
        CellContextMenu.Items.Add(menuItem1)
        CellContextMenu.Items.Add(menuItem2)
        CellContextMenu.Items.Add(menuItem3)
    End Sub

    Private Sub Cell_RightClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Me.CellMouseClick
        columnIndex = e.ColumnIndex

        If e.Button = MouseButtons.Right Then
            CellContextMenu.Show()
            CellContextMenu.Location = Cursor.Position
        End If
    End Sub

    Private Sub AddColumnLeft(sender As Object, e As EventArgs)
        Dim newColumn As New DataGridViewTextBoxColumn
        columnIndex = Math.Min(Math.Max(columnIndex, 0), ColumnCount)
        Columns.Insert(columnIndex, newColumn)
    End Sub

    Private Sub AddColumnRight(sender As Object, e As EventArgs)
        Dim newColumn As New DataGridViewTextBoxColumn
        columnIndex = Math.Min(Math.Max(columnIndex, 0), ColumnCount)
        Columns.Insert(columnIndex + 1, newColumn)
    End Sub

    Private Sub DeleteColumn(sender As Object, e As EventArgs)
        Columns.RemoveAt(columnIndex)
    End Sub

    Private Sub ColumnHeaderMouse_DoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Me.ColumnHeaderMouseDoubleClick
        Dim value As String = InputBox("Введите новое название для столбца:")
        If value IsNot "" Then
            Columns(e.ColumnIndex).HeaderText = value
        End If
    End Sub
End Class