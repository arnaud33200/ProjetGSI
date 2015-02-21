Public Class Utilisateur

    Public Event demandeAjout()
    Public Event demandeSuppression(ByVal n As Integer)

    Public Sub nouveauAjout(ByVal u As String, ByVal n As Integer)
        Dim m = u & " - produit#" & n
        ListView1.Items.Insert(0, m)
    End Sub

    Public Sub nouveauSupression(ByVal n As Integer)

    End Sub

    Public Sub setTitre(ByVal t As String)
        Me.Text = t
    End Sub

    Private Sub Utilisateur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.Items.Add("u0 - produit#1")
        ListView1.Items.Add("u0 - produit#2")
        ListView1.Items.Add("u0 - produit#3")
        ListView1.Items.Add("u0 - produit#4")
        ListView1.Items.Add("u0 - produit#5")
        ListView1.Items.Add("u0 - produit#6")
        ListView1.Items.Add("u0 - produit#7")
        ListView1.Items.Add("u0 - produit#8")
        ListView1.Items.Add("u0 - produit#9")
        ListView1.Items.Add("u0 - produit#10")
        ListView1.View = View.SmallIcon

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent demandeAjout()
    End Sub
End Class