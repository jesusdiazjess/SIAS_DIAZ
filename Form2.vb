Imports System.Drawing.Printing

Public Class Form2
    Private printDocument As New PrintDocument()

    Private Sub StudentinfoBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles StudentinfoBindingNavigatorSaveItem.Click
        SaveData()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO: This line of code loads data into the 'SIAS_DIAZDataSet.studentinfo' table. You can move, or remove it, as needed.
        Me.StudentinfoTableAdapter.Fill(Me.SIAS_DIAZDataSet.studentinfo)
        LoadImage()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtstudentid.TextChanged
        Me.StudentinfoTableAdapter.FillBy(Me.SIAS_DIAZDataSet.studentinfo, txtstudentid.Text, txtfirstname.Text, txtlastname.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'PREVIOUS
        If StudentinfoBindingSource.Position = 0 Then
            MessageBox.Show("You reached the first record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            PictureBox1.Refresh()
            StudentinfoBindingSource.MovePrevious()
            LoadImage()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'NEXT
        If StudentinfoBindingSource.Position = StudentinfoBindingSource.Count - 1 Then
            MessageBox.Show("You reached the last record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            PictureBox1.Refresh()
            StudentinfoBindingSource.MoveNext()
            LoadImage()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'ADD
        StudentinfoBindingSource.AddNew()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click 'SAVE
        SaveData()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Disable the groupbox1 that contains the textboxes and labels
        groupbox1.Enabled = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click 'DELETE
        Dim Confirm As String = MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.OkCancel, "Message")
        If Confirm = MsgBoxResult.Ok Then
            StudentinfoBindingSource.RemoveCurrent()
            SaveData()
            MessageBox.Show("Data deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click 'PRINT
        PrintData()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ' Implement the functionality for the RECORD button
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            picturesource.Text = OpenFileDialog1.FileName()
        End If
    End Sub

    Private Sub picturesource_TextChanged(sender As Object, e As EventArgs) Handles picturesource.TextChanged
        LoadImage()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click 'REFRESH BUTTON
        Me.StudentinfoTableAdapter.Fill(Me.SIAS_DIAZDataSet.studentinfo)
        LoadImage()
    End Sub

    Private Sub StudentinfoDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles StudentinfoDataGridView.CellContentClick
        ' Handle the DataGridView cell content click event if needed
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        ' Handle the Label4 click event if needed
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click 'UNDO
        StudentinfoBindingSource.CancelEdit()
        MessageBox.Show("Changes undone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SaveData()
        Me.Validate()
        Me.StudentinfoBindingSource.EndEdit()
        Me.StudentinfoTableAdapter.Update(Me.SIAS_DIAZDataSet.studentinfo)
        MessageBox.Show("Data saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadImage()
        If Not String.IsNullOrEmpty(picturesource.Text) AndAlso System.IO.File.Exists(picturesource.Text) Then
            Try
                PictureBox1.Image = Image.FromFile(picturesource.Text)
            Catch ex As Exception
                'HANDLE EXCEPTIONS RELATED TO IMAGE LOADING, SUCH AS CORRUPTED FILES
                MessageBox.Show("Error loading the image file: " & ex.Message, "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'PROVIDE A DEFAULT IMAGE OR CLEAR THE PICTUREBOX IF NO VALID IMAGE FILE IS SPECIFIED
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub PrintData()
        ' Set the PrintPage event handler for the printDocument
        AddHandler printDocument.PrintPage, AddressOf PrintPageHandler

        ' Print the document
        Dim printDialog As New PrintDialog()
        printDialog.Document = printDocument
        If printDialog.ShowDialog() = DialogResult.OK Then
            printDocument.Print()
        End If
    End Sub

    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        ' Implement the logic to draw the contents of the page on the e.Graphics object
        ' You can use methods like e.Graphics.DrawString to draw text, e.Graphics.DrawImage to draw images, etc.
        ' Retrieve the data from your form's controls and use it to create the printout
        ' Adjust the positioning and formatting as needed

        ' Example: Printing the student information
        Dim studentID As String = txtstudentid.Text
        Dim firstName As String = txtfirstname.Text
        Dim lastName As String = txtlastname.Text

        ' Draw the student information on the page
        e.Graphics.DrawString("Student ID: " & studentID, Me.Font, Brushes.Black, 50, 50)
        e.Graphics.DrawString("First Name: " & firstName, Me.Font, Brushes.Black, 50, 80)
        e.Graphics.DrawString("Last Name: " & lastName, Me.Font, Brushes.Black, 50, 110)
    End Sub

    Private Sub StudentIDLabel_Click(sender As Object, e As EventArgs)

    End Sub
End Class
