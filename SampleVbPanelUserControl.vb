Imports SampleVbPanel.SampleVbPanel

<System.Runtime.InteropServices.Guid("870FB655-A15F-46CF-A7FE-FEA5B7B51D93")>
Public Class SampleVbPanelUserControl

  ''' <summary>
  ''' Constructor
  ''' </summary>
  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add reference to 'me' to the plug-in object so we can reach
    ' this usercontrol from somewhere else, like a command.
    SampleVbPanelPlugIn.Instance.UserControl = Me

  End Sub

  ''' <summary>
  ''' Gets the Id of our panel
  ''' </summary>
  Public Shared ReadOnly Property PanelId() As System.Guid
    Get
      Return GetType(SampleVbPanelUserControl).GUID
    End Get
  End Property

End Class
