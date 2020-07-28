PublicClassAppContext
InheritsApplicationContext

#Region" Storage "

PrivateWithEvents Tray AsNotifyIcon
PrivateWithEvents MainMenu AsContextMenuStrip
PrivateWithEvents mnuDisplayForm AsToolStripMenuItem
PrivateWithEvents mnuSep1 AsToolStripSeparator
PrivateWithEvents mnuExit AsToolStripMenuItem

#EndRegion

#Region" Constructor "

PublicSubNew()
'Initialize the menus

        mnuDisplayForm = NewToolStripMenuItem("Display form")
        mnuSep1 = NewToolStripSeparator()
'mnuExit = New ToolStripMenuItem("Exit")
        MainMenu = NewContextMenuStrip
        MainMenu.Items.AddRange(NewToolStripItem() {mnuDisplayForm})
'Initialize the tray
        Tray = NewNotifyIcon
        Tray.Icon = My.Resources.TrayIcon
        Tray.ContextMenuStrip = MainMenu
        Tray.Text = "Eye On You"

'Display
        Tray.Visible = True
EndSub

#EndRegion

#Region" Event handlers "

PrivateSub AppContext_ThreadExit(ByVal sender AsObject, ByVal e As System.EventArgs) _
HandlesMe.ThreadExit
'Guarantees that the icon will not linger.
        Tray.Visible = False
EndSub

PrivateSub mnuDisplayForm_Click(ByVal sender AsObject, ByVal e As System.EventArgs) _
Handles mnuDisplayForm.Click
        ShowDialog()

EndSub

PrivateSub mnuExit_Click(ByVal sender AsObject, ByVal e As System.EventArgs) _
Handles mnuExit.Click
        ExitApplication()
EndSub

PrivateSub Tray_DoubleClick(ByVal sender AsObject, ByVal e As System.EventArgs) _
Handles Tray.DoubleClick
        ShowDialog()
EndSub

#EndRegion

EndClass
