Public NotInheritable Class MoteurCoop

    Private WithEvents u1 As Utilisateur
    Private WithEvents u2 As Utilisateur

    Private Sub MoteurCoop_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        u1 = New Utilisateur
        u1.setTitre("Utilisateur 1")
        u1.Visible = False
        u2 = New Utilisateur
        u2.setTitre("Utilisateur 2")
        u2.Visible = False

        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'Si le titre de l'application est absent, utilisez le nom de l'application, sans l'extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Copyright.Text = My.Application.Info.Copyright
    End Sub


    Public Sub demandeAjoutU1() Handles u1.demandeAjout
        u1.nouveauAjout("u1", 666)
        u2.nouveauAjout("u1", 666)
    End Sub

    Public Sub demandeAjoutU2() Handles u2.demandeAjout
        u1.nouveauAjout("u2", 667)
        u2.nouveauAjout("u2", 667)
    End Sub

    Public Sub demandeSuppressionU1(ByVal n As Integer) Handles u1.demandeSuppression

    End Sub

    Public Sub demandeSuppressionU2(ByVal n As Integer) Handles u2.demandeSuppression

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Hide()
        u1.Visible = True
        u2.Visible = True
    End Sub
End Class
