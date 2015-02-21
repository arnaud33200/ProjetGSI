Public Class Utilisateur

    Public Event demandeAjout(ByVal i As Integer)
    Public Event demandeSuppression(ByVal n As Integer)
    Public Event ferme()

    Enum USRSTATE
        IDLE
        SELECTED
    End Enum

    Private state As USRSTATE

    Private Sub Utilisateur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        state = USRSTATE.IDLE

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

    Public Sub desactiverButtons()
        Button2.Enabled = False
        If (RadioButton3.Checked) Then
            RadioButton3.Checked = False
            RadioButton1.Checked = True
        End If
        RadioButton3.Enabled = False
    End Sub

    Public Sub activerButtons()
        Button2.Enabled = True
        RadioButton3.Enabled = True
    End Sub

    Public Sub ajouterPanier(ByVal p As String, ByVal i As Integer)
        If (i < 0) Then
            ListBox1.Items.Add(p)
        Else
            ListBox1.Items.Insert(i, p)
        End If
    End Sub

    Public Sub supprimerPanier(ByVal u As String, ByVal n As Integer)
        Dim m As String = u & " - produit#" & n
        Dim i As Integer = ListBox1.Items.IndexOf(m)
        ListBox1.Items.RemoveAt(i)
    End Sub

    Public Sub nouveauAjout(ByVal u As String, ByVal n As Integer, ByVal i As Integer)
        Dim m = u & " - produit#" & n
        Select Case state
            Case USRSTATE.IDLE
                state = USRSTATE.IDLE
                ajouterPanier(m, i)
            Case USRSTATE.SELECTED
                state = USRSTATE.IDLE
                ajouterPanier(m, i)
        End Select
    End Sub

    Public Sub nouvelleSupression(ByVal u As String, ByVal n As Integer)
        Select Case state
            Case USRSTATE.IDLE
                state = USRSTATE.IDLE
                supprimerPanier(u, n)
            Case USRSTATE.SELECTED
                state = USRSTATE.SELECTED
                supprimerPanier(u, n)
                If (ListBox1.SelectedIndex = -1) Then
                    desactiverButtons()
                    state = USRSTATE.IDLE
                End If
        End Select
    End Sub

    Public Sub refusSupression(ByVal u As String, ByVal n As Integer)
        Timer1.Enabled = True
        Timer1.Stop()
        Label1.Text = "suppression interdit : " & u & " - produit#" & n
        Timer1.Start()
    End Sub

    Public Sub setTitre(ByVal t As String)
        Me.Text = t
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer = -1
        If (RadioButton3.Checked) Then
            i = ListBox1.SelectedIndex
        ElseIf (RadioButton1.Checked) Then
            i = 0
        End If

        Select Case state
            Case USRSTATE.IDLE
                state = USRSTATE.IDLE
                RaiseEvent demandeAjout(i)
            Case USRSTATE.SELECTED
                state = USRSTATE.SELECTED
                RaiseEvent demandeAjout(i)
        End Select
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Select Case state
            Case USRSTATE.IDLE
                'INTERDIT
            Case USRSTATE.SELECTED
                state = USRSTATE.SELECTED
                Dim n As Integer = Convert.ToInt32(ListBox1.SelectedItem.ToString().Split("#")(1))
                RaiseEvent demandeSuppression(n)
        End Select
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Select Case state
            Case USRSTATE.IDLE
                state = USRSTATE.SELECTED
                activerButtons()
            Case USRSTATE.SELECTED
                state = USRSTATE.SELECTED
        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = ""
        Timer1.Stop()
    End Sub


    Private Sub Utilisateur_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        RaiseEvent ferme()
    End Sub
End Class