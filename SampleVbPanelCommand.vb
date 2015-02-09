Imports System
Imports System.Collections.Generic
Imports Rhino
Imports Rhino.Commands
Imports Rhino.Geometry
Imports Rhino.Input
Imports Rhino.Input.Custom
Imports Rhino.UI

Namespace SampleVbPanel

  ''' <summary>
  ''' SampleVbPanelCommand command
  ''' </summary>
  <System.Runtime.InteropServices.Guid("66401218-4a2b-4fa4-b38c-99760e0ceb24")> _
  Public Class SampleVbPanelCommand
    Inherits Command

    Shared _instance As SampleVbPanelCommand

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
      _instance = Me
    End Sub

    ''' <summary>
    ''' Gets the one and only instance of this command
    ''' </summary>
    Public Shared ReadOnly Property Instance() As SampleVbPanelCommand
      Get
        Return _instance
      End Get
    End Property

    ''' <summary>
    ''' Gets the command's English name
    ''' </summary>
    Public Overrides ReadOnly Property EnglishName() As String
      Get
        Return "SampleVbPanelCommand"
      End Get
    End Property

    ''' <summary>
    ''' Called by Rhino to run this command
    ''' </summary>
    Protected Overrides Function RunCommand(doc As RhinoDoc, mode As RunMode) As Result

      Dim panelId As Guid = SampleVbPanelUserControl.PanelId
      Dim bVisible As Boolean = Panels.IsPanelVisible(panelId)

      Dim prompt As String
      If (bVisible) Then
        prompt = "Object panel is visible. New value"
      Else
        prompt = "Object Manager panel is hidden. New value"
      End If

      Dim go As New GetOption()
      go.SetCommandPrompt(prompt)
      Dim hideIndex As Integer = go.AddOption("Hide")
      Dim showIndex As Integer = go.AddOption("Show")
      Dim toggleIndex As Integer = go.AddOption("Toggle")

      go.Get()
      If (go.CommandResult() <> Result.Success) Then
        Return go.CommandResult()
      End If

      Dim commandLineOption As CommandLineOption = go.Option()
      If (commandLineOption Is Nothing) Then
        Return Result.Failure
      End If

      Dim index As Integer = commandLineOption.Index

      If (index = hideIndex) Then
        If bVisible Then
          Panels.ClosePanel(panelId)
        End If
      ElseIf (index = showIndex) Then
        If Not bVisible Then
          Panels.OpenPanel(panelId)
        End If
      ElseIf (index = toggleIndex) Then
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