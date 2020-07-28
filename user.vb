Admin Panel
User.vb
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

PublicClassUser
Dim myconnection AsSqlConnection
Dim mycommand AsSqlCommand
Dim ds AsDataSet
Dim da AsSqlDataAdapter

PrivateSub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click

        da = NewSqlDataAdapter("select * from users where userName like '"& txtuserName.Text &"'", myconnection)
        ds = NewDataSet()
        da.Fill(ds)
If ds.Tables(0).Rows.Count > 0 Then
MessageBox.Show("User already exist try another name", "Duplication Violation", MessageBoxButtons.OK)
Else
If (txtPassword.Text.Equals(txtRetypePass.Text)) Then


                mycommand = NewSqlCommand("insert into users ([UserName],[Password],[active]) values ('"& txtuserName.Text &"','"& GetSHA1HashData(txtPassword.Text) &"','"&"active"&"')", myconnection)
                mycommand.ExecuteNonQuery ()
                txtPassword.Text = ""
                txtRetypePass.Text = ""
                txtuserName.Text = ""
MessageBox.Show ("New User Created Successfully", "User Created", MessageBoxButtons.OK)
Me.Hide()
Else
MessageBox.Show ("password and Re-type password are not same", "Password Violation", MessageBoxButtons.OK)
EndIf
EndIf

EndSub

PrivateSub User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) HandlesMyBase.Load
        Myconnection = NewSqlConnection ("Data Source=ACER-PC;AttachDbFilename=C:\eoy\ideltime.mdf;Integrated Security=True; User ID=administrator; Password=1234; Encrypt=False ;")
        myconnection.Open()
EndSub
PrivateFunction GetSHA1HashData(ByVal data AsString) AsString
'create new instance of md5
Dim sha1 AsSHA1 = sha1.Create()

'Convert the input text to array of bytes
Dim hash Data () As Byte = sha1.ComputeHash(Encoding.Default.GetBytes(data))

'create new instance of StringBuilder to save hashed data
Dim ReturnValue AsStringBuilder = NewStringBuilder()

'Loop for each byte and add it to StringBuilder
Dim i AsInteger
For i = 0 To hashData.Length - 1 Step i + 1
            ReturnValue. Append (hashData(i).ToString ())
Next
' MessageBox.Show(ReturnValue.ToString(), "status")
' return hexadecimal string
Return ReturnValue.ToString()
EndFunction
EndClass


