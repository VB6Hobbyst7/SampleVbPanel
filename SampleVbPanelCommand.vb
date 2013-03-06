Imports System
Imports System.Collections.Generic
Imports Rhino
Imports Rhino.Commands
Imports Rhino.Geometry
Imports Rhino.Input
Imports Rhino.Input.Custom
Imports Rhino.UI

Namespace SampleVbPanel

  <System.Runtime.InteropServices.Guid("66401218-4a2b-4fa4-b38c-99760e0ceb24")> _
  Public Class SampleVbPanelCommand
    Inherits Command

    Shared _instance As SampleVbPanelCommand

    Public Sub New()
      _instance = Me
    End Sub

    Public Shared ReadOnly Property Instance() As SampleVbPanelCommand
      Get
        Return _instance
      End Get
    End Property

    Public Overrides ReadOnly Property EnglishName() As String
      Get
        Return "SampleVbPanelCommand"
      End Get
    End Property

    Protected Overrides Function RunCommand(doc As RhinoDoc, mode As RunMode) As Result

      Dim panelId As Guid = SampleVbPanelUserControl.PanelId
      Dim bVisible As Boolean = Panels.IsPanelVisible(panelId)

      Dim prompt As String = If((bVisible), "Object panel is visible. New value", "Object Manager panel is hidden. New value")

      Dim go As New GetOption()
      Dim hide_index As Integer = go.AddOption("Hide")
      Dim show_index As Integer = go.AddOption("Show")
      Dim toggle_index As Integer = go.AddOption("Toggle")

      go.[Get]()
      If go.CommandResult() <> Result.Success Then
        Return go.CommandResult()
      End If

      Dim [option] As CommandLineOption = go.[Option]()
      If [option] Is Nothing Then
        Return Result.Failure
      End If

      Dim index As Integer = [option].Index

      If index = hide_index Then
        If bVisible Then
          Panels.ClosePanel(panelId)
        End If
      ElseIf index = show_index Then
        If Not bVisible Then
          Panels.OpenPanel(panelId)
        End If
      ElseIf index = toggle_index Then
        If bVisible Then
          Panels.ClosePanel(panelId)
        Else
          Panels.OpenPanel(panelId)
        End If
      End If

      Return Result.Success
    End Function

  End Class

End Namespace