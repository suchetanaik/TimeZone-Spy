Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

PublicClassForm3
PublicShared ststus, idelt AsString
PublicShared UserNm, uid AsString
Dim myconnection AsSqlConnection
Dim mycommand AsSqlCommand
Dim dr AsSqlDataReader
Dim da AsSqlDataAdapter
Dim ds AsDataSet
Dim itime AsInteger
Dim format1 AsString = "MM d yyyy"
Dim passenc, tUser AsString
Dim hi, ii, hw, iw, diffh, diffm, difft, lt, ll, temph, tempm AsString
PrivateSub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) HandlesMyBase.Load
Me.BackColor = Color.FromArgb(152, 0, 136)
Me.TransparencyKey = Color.FromArgb(152, 0, 136)
'btnClose.BackColor = Color.FromArgb(152, 0, 136)
'        btnClose.TransparencyKey = Color.FromArgb(152, 0, 136)




'Me.BackColor = Color.Transparent
        Form1.btnBreak.Visible = True
        Form1.btnContinue.Visible = False
'myconnection = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Downloads\SystemIdleTimerTest_src2(1)\SystemIdleTimerTest_src\SystemIdleTimerTest\SystemIdleTimer\ideltime.mdf;Integrated Security=True;User Instance=True")
'myconnection = New SqlConnection("Data Source=SPSERVER\SQLEXPRESS;Initial Catalog=IDELTIME;User ID=ashish;Password=aa@1234;Encrypt=False;")
        myconnection = NewSqlConnection("Data Source=ACER-PC;AttachDbFilename=C:\eoy\ideltime.mdf;Integrated Security=True;User ID=administrator;Password=1234;Encrypt=False;")
        myconnection.Open()
Try
Application.Run(NewAppContext)
Catch ex AsException

EndTry
        txtUserName.Text = ""
        txtPassword.Text = ""
EndSub

PrivateSub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False
Me.Hide()
If (myconnection.State = ConnectionState.Closed) Then
            myconnection.Open()
EndIf
If UserNm.Equals("") Then
            tUser = ""
Else
            tUser = UserNm
EndIf

'da = New SqlDataAdapter("select * from userTable where userName like '" & tUser & "' and Date like '" & DateTime.Now.ToString(format1) & "'", myconnection)
'ds = New DataSet()
'da.Fill(ds)
'If ds.Tables(0).Rows.Count <= 0 Then
If (TimeOfDay.Hour < 10) Then
            temph = "0"& TimeOfDay.Hour
Else
            temph = TimeOfDay.Hour
EndIf
If (TimeOfDay.Minute < 10) Then
            tempm = "0"& TimeOfDay.Minute
Else
            tempm = TimeOfDay.Minute
EndIf

        mycommand = NewSqlCommand("insert into usertable([userName],[Date],[ideltimeMin],[logintime],[logofftime],[ipaddress]) values ('"& tUser &"','"&DateTime.Now.ToString(format1) &"','"&"0"&"','"& temph &":"& tempm &"','"& temph &":"& tempm &"','15')", myconnection)
        mycommand.ExecuteNonQuery()

        da = NewSqlDataAdapter("select * from UniqueuserTable where userName like '"& tUser &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
        ds = NewDataSet()
        da.Fill(ds)
If ds.Tables(0).Rows.Count <= 0 Then

            mycommand = NewSqlCommand("insert into UniqueUsertable([userName],[Date],[ideltimeMin],[logintime],[logofftime],[ipaddress]) values ('"& tUser &"','"&DateTime.Now.ToString(format1) &"','"&"0"&"','"& temph &":"& tempm &"','"&""&"','15')", myconnection)
            mycommand.ExecuteNonQuery()


'da = New SqlDataAdapter("select ideltimeMin from userTable where userName like '" & UserNm & "' and Date like '" & DateTime.Now.ToString(format1) & "'", myconnection)
'ds = New DataSet()
'da.Fill(ds)

'itime = 0
'For intLoopIndex = 0 To ds.Tables(0).Rows.Count - 1
'    itime = Val(itime) + Val(ds.Tables(0).Rows(intLoopIndex)(0).ToString())
'Next intLoopIndex

'idelt = itime
'Form1.lblIt.Text = idelt & " min"
EndIf




        da = NewSqlDataAdapter("select * from userTable where userName like '"& tUser &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
        ds = NewDataSet()
        da.Fill(ds)
If ds.Tables(0).Rows.Count > 0 Then
            uid = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(0).ToString()
EndIf
'    ll = ds.Tables(0).Rows(0)(0).ToString()


'Else
'll = ""
'da = New SqlDataAdapter("select logintime from userTable where userName like '" & tUser & "' and Date like '" & DateTime.Now.ToString(format1) & "'", myconnection)
'ds = New DataSet()
'da.Fill(ds)
'If ds.Tables(0).Rows.Count > 0 Then
'    ll = ds.Tables(0).Rows(0)(0).ToString()
'    If (TimeOfDay.Hour < 10) Then
'        temph = "0" & TimeOfDay.Hour
'    Else
'        temph = TimeOfDay.Hour
'    End If
'    If (TimeOfDay.Minute < 10) Then
'        tempm = "0" & TimeOfDay.Minute
'    Else
'        tempm = TimeOfDay.Minute
'    End If
'    mycommand = New SqlCommand("update usertable set logintime = '" & ll & "|" & temph & ":" & tempm & "' where userName like '" & tUser & "' and Date like '" & DateTime.Now.ToString(format1) & "'", myconnection)
'    mycommand.ExecuteNonQuery()
'End If
'End If

Form1.Show()
Form1.Ref()
EndSub

PrivateSub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        passenc = GetSHA1HashData(txtPassword.Text)

        da = NewSqlDataAdapter("select username,password,active from users where userName like '"& txtUserName.Text &"' and Password like '"& passenc &"'", myconnection)
        ds = NewDataSet()
        da.Fill(ds)
If ds.Tables(0).Rows.Count > 0 Then
If ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(2).ToString().Equals("active") Then
                UserNm = txtUserName.Text
                Timer1.Enabled = True
Form3.ststus = "Hide"
Else
MessageBox.Show("user is Deactivated :-: Contact administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
EndIf

Else
MessageBox.Show("user name and password is incorect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
EndIf
EndSub
PrivateSub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'Me.Dispose()
        btnHide.PerformClick()
EndSub

PrivateSub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        ststus = "loginHide"
Me.DialogResult = Windows.Forms.DialogResult.Ignore
Me.Hide()
EndSub
PrivateFunction GetSHA1HashData(ByVal data AsString) AsString
'create new instance of md5
Dim sha1 AsSHA1 = sha1.Create()

'convert the input text to array of bytes
Dim hashData() AsByte = sha1.ComputeHash(Encoding.Default.GetBytes(data))

'create new instance of StringBuilder to save hashed data
Dim ReturnValue AsStringBuilder = NewStringBuilder()

'loop for each byte and add it to StringBuilder
Dim i AsInteger
For i = 0 To hashData.Length - 1 Step i + 1
            ReturnValue.Append(hashData(i).ToString())
Next
' MessageBox.Show(ReturnValue.ToString(), "status")
' return hexadecimal string
Return ReturnValue.ToString()
EndFunction


EndClass
