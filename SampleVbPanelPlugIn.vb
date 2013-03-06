Namespace SampleVbPanel
 
  Public Class SampleVbPanelPlugIn
    Inherits Rhino.PlugIns.PlugIn

    Shared _instance As SampleVbPanelPlugIn

    Public Sub New()
      _instance = Me
    End Sub

    Public Shared ReadOnly Property Instance() As SampleVbPanelPlugIn
      Get
        Return _instance
      End Get
    End Property

    Protected Overrides Function OnLoad(ByRef errorMessage As String) As Rhino.PlugIns.LoadReturnCode

      ' Get SampleVbPanelUserControl class type
      Dim panelType As System.Type = GetType(SampleVbPanelUserControl)

      ' Register SampleVbPanelUserControl class type with Rhino
      Rhino.UI.Panels.RegisterPanel(Me, panelType, "Objects", My.Resources.SampleVbPanel)

      Return Rhino.PlugIns.LoadReturnCode.Success

    End Function

  End Class

End Namespace