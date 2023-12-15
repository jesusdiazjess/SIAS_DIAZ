Public Class Form1


    Private Sub UserpasswordBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles UserpasswordBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.UserpasswordBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SIAS_DIAZDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SIAS_DIAZDataSet.userpassword' table. You can move, or remove it, as needed.
        Me.UserpasswordTableAdapter.Fill(Me.SIAS_DIAZDataSet.userpassword)

    End Sub

    Private Sub txtusername_TextChanged(sender As Object, e As EventArgs) Handles txtusername.TextChanged 'THIS IS FOR USERNAME
        Me.UserpasswordTableAdapter.FillBy(Me.SIAS_DIAZDataSet.userpassword, txtusername.Text, txtpassword.Text)
    End Sub

    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged 'THIS IS FOR PASSWORD
        Me.UserpasswordTableAdapter.FillBy(Me.SIAS_DIAZDataSet.userpassword, txtusername.Text, txtpassword.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'THIS IS FOR LOGIN BUTTON
        If UsernameTextBox.Text = "" And PasswordTextBox.Text = "" Then
            MsgBox("Invalid USERNAME and PASSWORD, try again", MsgBoxStyle.OkCancel, "Message")
        ElseIf UsernameTextBox.Text = txtusername.Text And PasswordTextBox.Text = txtpassword.Text Then
            MsgBox("Successfully LOGGED IN!", MsgBoxStyle.OkCancel, "Welcome " + FirstNameTextBox.Text)
            Form2.Show()
            Me.Hide()

        Else
            MsgBox("Invalid USERNAME and PASSWORD, try again", MsgBoxStyle.OkCancel, "Message")

        End If
    End Sub


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
