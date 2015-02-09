Namespace SampleVbPanel

  ''' <summary>
  ''' SampleVbPanelPlugIn
  ''' </summary>
  Public Class SampleVbPanelPlugIn
    Inherits Rhino.PlugIns.PlugIn

    Shared _instance As SampleVbPanelPlugIn
    Shared _userControl As SampleVbPanelUserControl

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
      _instance = Me
    End Sub

    ''' <summary>
    ''' Gets the one and only instance of this plug-in
    ''' </summary>
    Public Shared ReadOnly Property Instance() As SampleVbPanelPlugIn
      Get
        Return _instance
      End Get
    End Property

    ''' <summary>
    ''' Gets or sets the dockbar user control
    ''' </summary>
    Public Property UserControl() As SampleVbPanelUserControl
      Get
        Return _userControl
      End Get
      Set(value As SampleVbPanelUserControl)
        _userControl = value
      End Set
    End Property

    ''' <summary>
    ''' Call by Rhino when loading this plug-in
    ''' </summary>
    Protected Overrides Function OnLoad(ByRef errorMessage As String) As Rhino.PlugIns.LoadReturnCode

      ' Get SampleVbPanelUserControl class type
      Dim panelType As System.Type = GetType(SampleVbPanelUserControl)

      ' Register SampleVbPanelUserControl class type with Rhino
      Rhino.UI.Panels.RegisterPanel(Me, panelType, "Objects", My.Resources.SampleVbPanel)

      Return Rhino.PlugIns.LoadReturnCode.Success

    End Function

  End Class

End Namespace