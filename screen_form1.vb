Option Explicit On
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System.IO

PublicClassForm1

Private Strt As System.Threading.Thread

PublicShared idd AsInteger
Dim myconnection AsSqlConnection
Dim mycommand AsSqlCommand
Dim cmds AsSqlCommand
Dim dr AsSqlDataReader
Dim da AsSqlDataAdapter
Dim ds AsDataSet
Dim itime AsInteger
Dim format1 AsString = "MM d yyyy"
Dim diffh, diffm, difft, hi, ii, hw, iw, temph, tempm, lt, ll, idt, currt, totbreak AsString
Dim ltm(), sbreak(), ebreak(), lts, temp(), a AsString
Dim upd AsString = "add"
Dim tempwait, idstr, lgtm AsString
Dim i1, i2, tb, temptime AsInteger
Dim tempp AsInteger = 0
Dim ss AsString = ""
Dim sk AsString = ""

PublicSubNew()
        InitializeComponent()
        Icon = My.Resources.TrayIcon
EndSub

PrivateSub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

Try
            con()
Dim lt AsString
            da = NewSqlDataAdapter("select logofftime from userTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
            ds = NewDataSet()
            da.Fill(ds)
If ds.Tables(0).Rows.Count > 0 Then
                lt = ""
                lt = ds.Tables(0).Rows(0)(0).ToString()
If lt.Equals("") Then
Else
                    lt = lt + "|"
EndIf
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
                mycommand = NewSqlCommand("update usertable set logofftime = '"& temph &":"& tempm &"' where id like '"&Form3.uid &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                mycommand.ExecuteNonQuery()
                Timer3.Enabled = True
Form3.ststus = "loginHide"
                Form3.txtUserName.Text = ""
                Form3.txtPassword.Text = ""

EndIf
Catch ex AsException

EndTry

EndSub



Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) HandlesMyBase.Load
' Me.BackColor = Color.FromArgb(152, 0, 136)
' Me.TransparencyKey = Color.FromArgb(152, 0, 136)
If Form3.ststus.Equals("loginHide") Then
            Form3.txtPassword.Text = ""
            Form3.txtUserName.Text = ""

            Timer3.Enabled = True

Else
Try
'Shell("taskmgr.exe", AppWinStyle.Hide)

                myconnection = NewSqlConnection("Data Source=SERVER\SQLEXPRESS;Initial Catalog=IDELTIME;Persist Security Info=True;User ID=sa;Password=sp@1234;Encrypt=False;")
                myconnection.Open()
                Ref()
Me.Top = 2
Me.Left = 2
If SystemIdleTimer1.IsRunning = FalseThen
                    SystemIdleTimer1.MaxIdleTime = CUInt(300)
                    SystemIdleTimer1.Start()
Else
                    SystemIdleTimer1.Stop()
EndIf


Dim Generator As System.Random = New System.Random()
                temptime = Convert.ToInt32(Generator.Next(10, 15))
                da = NewSqlDataAdapter("select * from userTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                ds = NewDataSet()
                da.Fill(ds)
                idd = ds.Tables(0).Rows(0)(0)
If ds.Tables(0).Rows.Count <= 0 Then
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
                    mycommand = NewSqlCommand("insert into usertable([userName],[Date],[ideltimeMin],[logintime],[logofftime],[ipaddress]) values ('"&Form3.UserNm &"','"&DateTime.Now.ToString(format1) &"','"&"0"&"','"& temph &":"& tempm &"','"&""&"','15')", myconnection)
                    mycommand.ExecuteNonQuery()


                    mycommand = NewSqlCommand("insert into UniqueUsertable([userName],[Date],[ideltimeMin],[logintime],[logofftime],[ipaddress]) values ('"&Form3.UserNm &"','"&DateTime.Now.ToString(format1) &"','"&"0"&"','"& temph &":"& tempm &"','"&""&"','15')", myconnection)
                    mycommand.ExecuteNonQuery()


Else
                    ll = ""
                    ll = ds.Tables(0).Rows(0)(4).ToString()
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
'mycommand = New SqlCommand("update usertable set logintime = '" & ll & "|" & temph & ":" & tempm & "' where userName like '" & Environment.UserName.ToString() & "_" & Environment.MachineName & "' and Date like '" & DateTime.Now.ToString(format1) & "'", myconnection)
'mycommand.ExecuteNonQuery()
EndIf
                Ref()
Catch ex AsException

EndTry
EndIf

EndSub


PrivateSub SystemIdleTimer1_OnEnterIdleState(ByVal sender As System.Object, ByVal e As EdinDazdarevic.IdleEventArgs) Handles SystemIdleTimer1.OnEnterIdleState
'MessageBox.Show("Entered idle state")
        hi = TimeOfDay.Hour
        ii = TimeOfDay.Minute
EndSub

PrivateSub SystemIdleTimer1_OnExitIdleState(ByVal sender As System.Object, ByVal e As EdinDazdarevic.IdleEventArgs) Handles SystemIdleTimer1.OnExitIdleState

'MessageBox.Show("Welcome back!")
Try
Dim da1 AsSqlDataAdapter
            con()

            hw = TimeOfDay.Hour
            iw = TimeOfDay.Minute
            diffh = Val(hw) - Val(hi)
            diffm = Val(iw) - Val(ii)
            difft = (diffh * 60) + diffm


            da1 = NewSqlDataAdapter("select id,ideltimeMin from userTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
            ds = NewDataSet()
            da1.Fill(ds)

            idd = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(0)
            itime = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(1)

            mycommand = NewSqlCommand("update Usertable set ideltimeMin = '"& Val(itime + difft + 5) &"' where id like '"& idd &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
            mycommand.ExecuteNonQuery()


            da1 = NewSqlDataAdapter("select ideltimeMin from userTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
            ds = NewDataSet()
            da1.Fill(ds)

            itime = 0
For intLoopIndex = 0 To ds.Tables(0).Rows.Count - 1
                itime = itime + Val(ds.Tables(0).Rows(0)(0).ToString())
Next intLoopIndex

            mycommand = NewSqlCommand("update UniqueUsertable set ideltimeMin = '"& Val(itime) &"' where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
            mycommand.ExecuteNonQuery()
'lblIt.Text = Val(itime + difft + 5)
'itime = 
'If upd <> "" Then

'    upd = ""
'End If

'Ref()
            Strt = New System.Threading.Thread(AddressOf MyThread1)
            Strt.Start()
Catch ex AsException

EndTry

EndSub
PrivateSub CancelFormButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelFormButton.Click
Form3.ststus = "Hide"
Me.DialogResult = Windows.Forms.DialogResult.Ignore
Me.Hide()

EndSub

PrivateSub btnBreak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBreak.Click
Form2.Show()

        Form2.BreakReason.Text = ""
        da = NewSqlDataAdapter("select id from userTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
        ds = NewDataSet()
        da.Fill(ds)
        idd = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(0)
'Ref()
        Strt = New System.Threading.Thread(AddressOf MyThread1)
        Strt.Start()
EndSub

PrivateSub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
Try
            con()
            btnBreak.Visible = True
            btnContinue.Visible = False

'MessageBox.Show("break over")
            ll = ""
            da = NewSqlDataAdapter("select max(id) from breakTable group by utid having utid like '"& idd &"'", myconnection)
            ds = NewDataSet()
            da.Fill(ds)
If ds.Tables(0).Rows.Count > 0 Then
                ll = ds.Tables(0).Rows(0)(0).ToString()
'If ll.Equals("") Then

'Else
'    ' ll = ll + "|"
'End If
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

                mycommand = NewSqlCommand("update breakTable set endBreak = '"& temph &":"& tempm &"' where id like '"& ll &"'", myconnection)
                mycommand.ExecuteNonQuery()

'mycommand = New SqlCommand("update breakTable set reasonForBreak = '" & Form2.reason & "' where id like '" & idd & "'", myconnection)
'mycommand.ExecuteNonQuery()

EndIf
'Else
'Form2.Show()
''Form3.ststus = "Continue"
'Form2.BreakReason.Text = ""


'End If
            da = NewSqlDataAdapter("select id from userTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
            ds = NewDataSet()
            da.Fill(ds)
            idd = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(0)



'Ref()
            Strt = New System.Threading.Thread(AddressOf MyThread1)
            Strt.Start()

'btnBreak.Visible = True
'btnContinue.Visible = False
Catch ex AsException

EndTry

EndSub


PrivateSub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Ref()
EndSub
Sub MyThread1()
        Ref()
EndSub
PublicSub Ref()

'Me.BackColor = Color.FromArgb(152, 0, 136)
'Me.TransparencyKey = Color.FromArgb(152, 0, 136)
Try
            con()
IfMe.InvokeRequired Then
'Me.Invoke(New MethodInvoker(AddressOf Ref))
Else

                da = NewSqlDataAdapter("select * from usertable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                ds = NewDataSet()
                da.Fill(ds)
                a = "|"
                ll = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(4).ToString()
                lts = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(5).ToString()
'idt = ds.Tables(0).Rows(0)(3).ToString()

                ltm = lts.Split(a)
                temp = ll.Split(a)
                currt = TimeOfDay.Hour &":"& TimeOfDay.Minute

Dim aa(), bb() AsString
                aa = temp(0).Split(":")
                bb = currt.Split(":")
                i1 = Val(bb(0) - aa(0)) * 60
                i2 = Val(bb(1)) - Val(aa(1))
                lgtm = ds.Tables(0).Rows(0)(4).ToString()
                loginTime.Text = "Login time : "& ds.Tables(0).Rows(0)(4).ToString()

                tempwait = ""&Math.Floor((i1 + i2 - idt) / 60).ToString() &" hour "&CInt((i1 + i2 - idt) Mod 60).ToString() &" min"
'lblwtime.Text = "" & Math.Floor((i1 + i2 - idt) / 60).ToString() & " hour " & CInt((i1 + i2 - idt) Mod 60).ToString() & " min"
                mycommand = NewSqlCommand("update usertable set workingTime = '"& tempwait &"' where id like '"&Form3.uid &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                mycommand.ExecuteNonQuery()

'da = New SqlDataAdapter("select ideltimeMin from userTable where userName like '" & Form3.UserNm & "' and Date like '" & DateTime.Now.ToString(format1) & "'", myconnection)
'ds = New DataSet()
'da.Fill(ds)
'itime = 0
'For intLoopIndex = 0 To ds.Tables(0).Rows.Count - 1
'    itime = Val(itime) + Val(ds.Tables(0).Rows(intLoopIndex)(0).ToString())
'Next intLoopIndex
'lblIt.Text = itime & " min"

                da = NewSqlDataAdapter("select workingTime from userTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                ds = NewDataSet()
                da.Fill(ds)
If ds.Tables(0).Rows.Count > 0 Then
Dim intLoopIndex, toth, totm AsInteger
                    toth = 0
                    totm = 0
Dim stt AsString
Dim totalw() AsString

For intLoopIndex = 0 To ds.Tables(0).Rows.Count - 1
                        stt = ds.Tables(0).Rows(intLoopIndex)(0).ToString()
                        totalw = stt.Split(" ")
                        toth = toth + Val(totalw(0))
                        totm = totm + Val(totalw(2))
Next intLoopIndex

If totm > 60 Then
                        totm = totm - Val(lblIt.Text)
                        toth = toth + (totm / 60)
                        totm = totm Mod 60
EndIf
                    lblwtime.Text = toth &" hour "& totm &" min"
EndIf

                mycommand = NewSqlCommand("update uniqueuserTable set workingTime = '"& lblwtime.Text &"' where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                mycommand.ExecuteNonQuery()

                da = NewSqlDataAdapter("select id from UserTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                ds = NewDataSet()
                da.Fill(ds)


'write logic of idstr with all id should transfer in query: (,) logic
For intLoopIndex = 0 To ds.Tables(0).Rows.Count - 1
If (intLoopIndex = 0) Then
                        idstr = ds.Tables(0).Rows(intLoopIndex)(0)
Else
                        idstr = idstr &","& ds.Tables(0).Rows(intLoopIndex)(0)
EndIf
Next intLoopIndex


                da = NewSqlDataAdapter("select ideltimeMin from UserTable where userName like '"&Form3.UserNm &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                ds = NewDataSet()
                da.Fill(ds)
Dim tmpidel AsInteger
If ds.Tables(0).Rows.Count > 0 Then
For intLoopIndex = 0 To ds.Tables(0).Rows.Count - 1
                        tmpidel = tmpidel + Val(ds.Tables(0).Rows(intLoopIndex)(0).ToString())
Next
                    lblIt.Text = tmpidel.ToString()
EndIf


                da = NewSqlDataAdapter("select * from breakTable where utid in ("& idstr &")", myconnection)
                ds = NewDataSet()
                da.Fill(ds)
                totbreak = "0"
ForMe.tb = 0 To ds.Tables(0).Rows.Count - 1
                    sbreak = ds.Tables(0).Rows(tb)(2).ToString().Split(":")
                    ebreak = ds.Tables(0).Rows(tb)(3).ToString().Split(":")
If (ebreak(0) = "") Then
                        diffh = Val(TimeOfDay.Hour) - Val(sbreak(0))
                        diffm = Val(TimeOfDay.Minute) - Val(sbreak(1))
Else
                        diffh = Val(ebreak(0)) - Val(sbreak(0))
                        diffm = Val(ebreak(1)) - Val(sbreak(1))
EndIf

'diffh = Val(ebreak(0)) - Val(sbreak(0))
'diffm = Val(ebreak(1)) - Val(sbreak(1))

                    totbreak = Val(totbreak) + (Val(diffh) * 60) + Val(diffm)
Next
                lblBreakTime.Text = ""&Math.Floor(totbreak / 60).ToString() &" hour "&CInt(totbreak Mod 60).ToString() &" min"
'lblBreakTime.Text = "" & totbreak & " (min)"
EndIf
            da = NewSqlDataAdapter("select * from NewsTable ", myconnection)
            ds = NewDataSet()
            da.Fill(ds)
            lblNews.Text = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)(1).ToString()
Catch ex AsException

EndTry

EndSub
Sub con()
Try
If (myconnection.State = ConnectionState.Closed) Then
                myconnection.Open()
EndIf
Catch ex AsException

EndTry

EndSub

PrivateSub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
If sk.Equals("nd") Then
Else
Try
                con()
                upd = "add"
                da = NewSqlDataAdapter("select * from usertable where id like '"&Form3.uid &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                ds = NewDataSet()
                da.Fill(ds)
                a = "|"
                ll = ds.Tables(0).Rows(0)(4).ToString()
                lts = ds.Tables(0).Rows(0)(5).ToString()
                idt = ds.Tables(0).Rows(0)(3).ToString()
                ss = ds.Tables(0).Rows(0)("ipaddress").ToString()

If ss = ""Then
                    temptime = 15
'Timer2.Interval = 60000
Else
                    temptime = Val(ss)
'Timer2.Interval = Val(ss) * 6000
EndIf

                ltm = lts.Split(a)
                temp = ll.Split(a)
                currt = TimeOfDay.Hour &":"& TimeOfDay.Minute

Dim aa(), bb() AsString
                aa = temp(0).Split(":")
                bb = currt.Split(":")
                i1 = Val(bb(0) - aa(0)) * 60
                i2 = Val(bb(1)) - Val(aa(1))

                loginTime.Text = "Login time : "& lgtm
'lblIt.Text = "" & idt & " min"
'lblwtime.Text = "" & Math.Floor((i1 + i2 - idt) / 60).ToString() & " hour " & CInt((i1 + i2 - idt) Mod 60).ToString() & " min"
                tempwait = ""&Math.Floor((i1 + i2 - idt) / 60).ToString() &" hour "&CInt((i1 + i2 - idt) Mod 60).ToString() &" min"

'lblttime = "" & Math.Floor((i1 + i2) / 60).ToString() & " hour " & CInt((i1 + i2) Mod 60).ToString() & " min"
                mycommand = NewSqlCommand("update usertable set workingTime = '"& tempwait &"',logofftime = '"& currt &"'where id like '"&Form3.uid &"' and Date like '"&DateTime.Now.ToString(format1) &"'", myconnection)
                mycommand.ExecuteNonQuery()
                tempp = tempp + 1
'tempp = temptime
If tempp >= temptime Then

Try
                        tempp = 0
Dim bounds AsRectangle
Dim screenshot As System.Drawing.Bitmap
Dim graph AsGraphics
                        bounds = Screen.PrimaryScreen.Bounds
                        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                        graph = Graphics.FromImage(screenshot)
                        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
                        PictureBox1.Image = screenshot
'Timer1.Enabled = False 
Me.Opacity = 100
Dim time AsDateTime = DateTime.Now
Dim format AsString = "MMM ddd d HH mm yyyy"

Dim machinename AsString = Form3.UserNm
If System.IO.Directory.Exists("\\server\DOTNET\Images\"& machinename &"\") Then
                            PictureBox1.Image.Save("\\server\DOTNET\Images\"& machinename &"\"&Form3.UserNm &"_"& time.ToString(format) &".gif", System.Drawing.Imaging.ImageFormat.Gif)
Else
                            System.IO.Directory.CreateDirectory("\\server\DOTNET\Images\"& machinename &"\")
                            PictureBox1.Image.Save("\\server\DOTNET\Images\"& machinename &"\"&Form3.UserNm &"_"& time.ToString(format) &".gif", System.Drawing.Imaging.ImageFormat.Gif)

EndIf
                        con()
Dim cmds AsNewSqlCommand("INSERT INTO Information VALUES(@name,@photo)", myconnection)
                        cmds.Parameters.AddWithValue("@name", "" + Form3.UserNm &"_" + time.ToString(format) + ".gif")
Dim ms AsNewMemoryStream()
                        PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
Dim data AsByte() = ms.GetBuffer()
Dim p AsNewSqlParameter("@photo", SqlDbType.Image)
                        p.Value = data
                        cmds.Parameters.Add(p)
                        cmds.ExecuteNonQuery()
' MessageBox.Show("Name & Image has been saved", "Save", MessageBoxButtons.OK)
'Label1.Visible = False


'PictureBox1.Image.Save("\\server\DOTNET\" & Environment.UserName.ToString() & "_" & Environment.MachineName & "_" & time.ToString(format) & ".gif", System.Drawing.Imaging.ImageFormat.Gif)
                        Strt = New System.Threading.Thread(AddressOf MyThread1)
                        Strt.Start()
Catch ex AsException

EndTry
EndIf


Catch ex AsException

EndTry
EndIf

EndSub
'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
'    Form3.Show()
'    Timer1.Enabled = False
'End Sub

PrivateSub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
Form3.Show()
        Timer3.Enabled = False
Me.Hide()
EndSub

PrivateSub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
MessageBox.Show("chears")
        sk = "nd"
EndSub
Function cat()

Try


Dim bounds AsRectangle
Dim screenshot As System.Drawing.Bitmap
Dim graph AsGraphics
            bounds = Screen.PrimaryScreen.Bounds
            screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            graph = Graphics.FromImage(screenshot)
            graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
            PictureBox1.Image = screenshot
'Timer1.Enabled = False 
Me.Opacity = 100
Dim time AsDateTime = DateTime.Now
Dim format AsString = "MMM ddd d HH mm yyyy"

Dim machinename AsString = Form3.UserNm
If System.IO.Directory.Exists("\\server\DOTNET\Images\"& machinename &"\") Then
                PictureBox1.Image.Save("\\server\DOTNET\Images\"& machinename &"\"&Form3.UserNm &"_"& time.ToString(format) &".gif", System.Drawing.Imaging.ImageFormat.Gif)
Else
                System.IO.Directory.CreateDirectory("\\server\DOTNET\Images\"& machinename &"\")
                PictureBox1.Image.Save("\\server\DOTNET\Images\"& machinename &"\"&Form3.UserNm &"_"& time.ToString(format) &".gif", System.Drawing.Imaging.ImageFormat.Gif)

EndIf
            con()
Dim cmds AsNewSqlCommand("INSERT INTO Information VALUES(@name,@photo)", myconnection)
            cmds.Parameters.AddWithValue("@name", "" + Form3.UserNm &"_" + time.ToString(format) + ".gif")
Dim ms AsNewMemoryStream()
            PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
Dim data AsByte() = ms.GetBuffer()
Dim p AsNewSqlParameter("@photo", SqlDbType.Image)
            p.Value = data
            cmds.Parameters.Add(p)
            cmds.ExecuteNonQuery()
MessageBox.Show("WelCome to SearchCommunication Pvt. Ltd. ")
' MessageBox.Show("Name & Image has been saved", "Save", MessageBoxButtons.OK)
'Label1.Visible = False


'PictureBox1.Image.Save("\\server\DOTNET\" & Environment.UserName.ToString() & "_" & Environment.MachineName & "_" & time.ToString(format) & ".gif", System.Drawing.Imaging.ImageFormat.Gif)
            Strt = New System.Threading.Thread(AddressOf MyThread1)
            Strt.Start()
Catch ex AsException

EndTry


Return 0
EndFunction

PrivateSub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        sk = ""
MessageBox.Show("Testing")
EndSub

PrivateSub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        cat()
EndSub
EndClass
