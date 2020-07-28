Imports System.Data.SqlClient

PublicClassForm1
Dim myconnection As SqlConnection
Dim mycommand As SqlCommand
Dim da As SqlDataAdapter
Dim ds, dsb As DataSet
Dim tim () AsString
Dim tempid AsString
Dim user, dateSel AsString
Dim format1 AsString = "MM d yyyy"
PrivateSub Form1_Load (ByVal sender As System.Object, ByVal e As System.EventArgs) HandlesMyBase.Load
'TODO: This line of code loads data into the 'IDELTIMEDataSet1.breakTable' table. You can move, or remove it, as needed.
'Me.BreakTableTableAdapter.Fill(Me.IDELTIMEDataSet1.breakTable)
'TODO: This line of code loads data into the 'IdeltimeDataSet.usertable' table. You can move, or remove it, as needed.


'Smyconnection = New SqlConnection ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Downloads\SystemIdleTimerTest_src2 (1)\SystemIdleTimerTest_src\SystemIdleTimerTest\SystemIdleTimer\ideltime.mdf;Integrated Security=True; User Instance=True")
        Myconnection = New SqlConnection ("Data Source=ACER-PC;AttachDbFilename=C:\eoy\ideltime.mdf;Integrated Security=True")
        myconnection.Open ()

        da = New SqlDataAdapter("select distinct userName from user Table", myconnection)
        ds = New DataSet()
        da.Fill(ds, "Pdetail")
        dgUser.DataSource = ds
        dgUser.DataMember = "Pdetail"

EndSub


PrivateSub dgUser_CellContentClick (ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUser.CellContentClick

        lblsDate.Text = ""
        lblLoginTime.Text = ""
        lblIdelTime.Text = ""
        lblWorkingTime.Text = ""

'MessageBox.Show(e.RowIndex)

        user = ""
        MessageBox.Show(dgUser.Item(0, e.RowIndex).Value.ToString())
        User = dgUser.Item(0, e.RowIndex).Value.ToString()
        lblUser.Text = user

'da = New SqlDataAdapter("select Date from userTable where userName like '" & user & "'", myconnection)
'ds = New DataSet()
'da.Fill(ds)
'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
'cbDate.Items.Add(ds.Tables(0).Rows(i)(0).ToString())
'Next






EndSub

'Private Sub cbDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cccbDate.SelectedIndexChanged
'    DateSel = cccbDate.SelectedItem.ToString ()
'    lblsDate.Text = cccbDate.SelectedItem.ToString () & “(mm dd yyyy) format"

'    da = New SqlDataAdapter("select * from userTable where userName like '" & user & "' and Date like '" & dateSel & "'", myconnection)
'    ds = New DataSet()
'    da.Fill(ds)	
'    lblLoginTime.Text = ds.Tables(0).Rows(0)(4).ToString() & " (24 hour format)"
'    lblIdelTime.Text = ds.Tables(0).Rows(0)(3).ToString() & " (min)"
'    lblWorkingTime.Text = ds.Tables(0).Rows(0)(6).ToString()



'End Sub

PrivateSub cbDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDate.ValueChanged
        dateSel = cbDate.Text
        lblsDate.Text = cbDate.Text.ToString() &"  (mm dd yyyy) format"

        da = New SqlDataAdapter("select * from userTable where userName like '"& user &"' and Date like '"& dateSel &"'", myconnection)
        ds = New DataSet()
        da.Fill(ds)




If ds.Tables(0).Rows.Count > 0 Then
            tim = ds.Tables(0).Rows(0)(4).ToString().Split("|")
            lblLoginTime.Text = tim(0) &" (24 hour format)"
            lblIdelTime.Text = ds.Tables(0).Rows(0)(3).ToString() &" (min)"
            lblWorkingTime.Text = ds.Tables(0).Rows(0)(6).ToString()
            tempid = ds.Tables(0).Rows(0)(0).ToString()

            da = New SqlDataAdapter ("select startBreak,endBreak,reasonForBreak from breakTable where utid like '"& tempid &"'", myconnection)
            dsb = New DataSet()
            da.Fill(dsb, "Breakdetail")
            dgBreak.DataSource = dsb
            dgBreak.DataMember = "Breakdetail"


Else
            lblLoginTime.Text = "Not Availabel"
            lblIdelTime.Text = "Not Availabel"
            lblWorkingTime.Text = "Not Availabel"
            dgBreak.DataSource = Nothing
            dgBreak.Refresh()
EndIf
EndSub

PrivateSub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        cbDate_ValueChanged(sender, e)
EndSub

PrivateSub CancelFormButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelFormButton.Click
End
EndSub
EndClass

