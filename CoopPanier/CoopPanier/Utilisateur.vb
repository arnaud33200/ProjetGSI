Public Class Utilisateur

    Public Event demandeAjout()
    Public Event demandeSuppression(ByVal n As Integer)

    Public Sub nouveauAjout(ByVal u As String, ByVal n As Integer)
        Dim m = u & " - produit#" & n
        ListBox1.Items.Insert(0, m)

    End Sub

    Public Sub nouveauSupression(ByVal n As Integer)

    End Sub

    Public Sub refusSupression(ByVal u As String, ByVal n As Integer)

    End Sub

    Public Sub setTitre(ByVal t As String)
        Me.Text = t
    End Sub

    Private Sub Utilisateur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("u0 - produit#1")
        ListBox1.Items.Add("u0 - produit#2")
        ListBox1.Items.Add("u0 - produit#3")
        ListBox1.Items.Add("u0 - produit#4")
        ListBox1.Items.Add("u0 - produit#5")
        ListBox1.Items.Add("u0 - produit#6")
        ListBox1.Items.Add("u0 - produit#7")
        ListBox1.Items.Add("u0 - produit#8")
        ListBox1.Items.Add("u0 - produit#9")
        ListBox1.Items.Add("u0 - produit#10")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent demandeAjout()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
End Class