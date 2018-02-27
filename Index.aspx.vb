Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub CMD_Buscar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Buscar.ServerClick
        Try
            Dim spell As New SeparaSilabas()
            Dim palavraSeparada As String = ""

            palavraSeparada = spell.silabear(palavra.Text)

            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "<script language=""javascript"">window.onload = function(){ ff_soletrar('" & palavraSeparada & "'); }</script>", False)
        Catch ex As Threading.ThreadAbortException
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "alert('Ocorreu uma exceção')", False)
        End Try
    End Sub
End Class