Public NotInheritable Class MoteurCoop

    Private WithEvents u1 As Utilisateur
    Private WithEvents u2 As Utilisateur
    Private produitNum As Integer
    Private panierU1 As ArrayList
    Private panierU2 As ArrayList

    Private Sub MoteurCoop_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        produitNum = 10

        u1 = New Utilisateur
        u1.setTitre("Utilisateur 1")
        u1.Visible = False
        u2 = New Utilisateur
        u2.setTitre("Utilisateur 2")
        u2.Visible = False

        panierU1 = New ArrayList()
        panierU2 = New ArrayList()

        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'Si le titre de l'application est absent, utilisez le nom de l'application, sans l'extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Copyright.Text = My.Application.Info.Copyright
    End Sub


    Public Sub demandeAjoutU1(ByVal i As Integer) Handles u1.demandeAjout
        produitNum = produitNum + 1
        panierU1.Add(produitNum)
        u1.nouveauAjout("u1", produitNum, i)
        u2.nouveauAjout("u1", produitNum, i)
    End Sub

    Public Sub demandeAjoutU2(ByVal i As Integer) Handles u2.demandeAjout
        produitNum = produitNum + 1
        panierU2.Add(produitNum)
        u1.nouveauAjout("u2", produitNum, i)
        u2.nouveauAjout("u2", produitNum, i)
    End Sub

    Private Function isU1Product(ByVal n As Integer) As Boolean
        For Each p As Integer In panierU1
            If (p = n) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function isU2Product(ByVal n As Integer) As Boolean
        For Each p As Integer In panierU2
            If (p = n) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub demandeSuppressionU1(ByVal n As Integer) Handles u1.demandeSuppression
        If (n < 11) Then
            u1.refusSupression("u0", n)
        ElseIf (isU2Product(n)) Then
            u1.refusSupression("u2", n)
        Else
            u1.nouvelleSupression("u1", n)
            u2.nouvelleSupression("u1", n)
            panierU1.RemoveAt(panierU1.IndexOf(n))
        End If
    End Sub

    Public Sub demandeSuppressionU2(ByVal n As Integer) Handles u2.demandeSuppression
        If (n < 11) Then
            u2.refusSupression("u0", n)
        ElseIf (isU1Product(n)) Then
            u2.refusSupression("u1", n)
        Else
            u1.nouvelleSupression("u2", n)
            u2.nouvelleSupression("u2", n)
            panierU2.RemoveAt(panierU2.IndexOf(n))
        End If
    End Sub

    Public Sub fermeU1() Handles u1.ferme
        Me.Close()
    End Sub

    Public Sub fermeU2() Handles u2.ferme
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Hide()
        u1.Visible = True
        u2.Visible = True
        u1.SetDesktopLocation(200, 200)
        u2.SetDesktopLocation(500, 200)
    End Sub
End Class
