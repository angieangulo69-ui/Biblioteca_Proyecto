Namespace SwalUtils
    Public Module SwalUtils
        Public Sub ShowSwalMessage(page As System.Web.UI.Page, title As String, message As String, icon As String)
            ' Sanitizar contenido
            title = title.Replace("'", "\'")
            message = message.Replace("'", "\'")

            Dim script = $"Swal.fire({{title: '{title}', text: '{message}', icon: '{icon}'}});"
            ScriptManager.RegisterStartupScript(page, page.GetType(), Guid.NewGuid().ToString(), script, True)
        End Sub

        Public Function ShowSwalScript(title As String, message As String, icon As String) As String
            Return $"Swal.fire({{title: '{title}', text: '{message}', icon: '{icon}'}});"
        End Function

        Public Sub ShowSwalError(page As System.Web.UI.Page, title As String, message As String)
            ShowSwalMessage(page, title, message, "error")
        End Sub
        Public Sub ShowSwalSimpleError(page As System.Web.UI.Page, message As String)
            ShowSwalMessage(page, "Error", message, "error")
        End Sub
        Public Sub ShowSwal(page As System.Web.UI.Page, title As String, Optional message As String = "", Optional icon As String = "success")
            ShowSwalMessage(page, title, message, icon)
        End Sub
    End Module

End Namespace