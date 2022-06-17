Option Explicit On
Option Strict On

Public Class Form1
    Private Sub btnGetURL_Click(sender As Object, e As EventArgs) Handles btnGetURL.Click
        GetImageURL("test", 1234)
    End Sub

    Private Shared Function GetImageURL(name As String, ImgID As Long) As String
        Try
            If ImgID = 0 Then Return ""
            Dim MyOnlineImg As System.Drawing.Image
            MyOnlineImg = Drawing.Image.FromFile("Cherry.png") ' New System.Drawing.Image() ' = GetImagefromDB(ImgID, Now)
            Dim ms As New IO.MemoryStream()
            Dim myImageCodecInfo As Imaging.ImageCodecInfo
            Dim myEncoder As System.Drawing.Imaging.Encoder
            Dim myEncoderParameter As Imaging.EncoderParameter
            Dim myEncoderParameters As Imaging.EncoderParameters
            myImageCodecInfo = GetEncoderInfo(Imaging.ImageFormat.Png)
            myEncoderParameters = New Imaging.EncoderParameters(1)
            myEncoder = System.Drawing.Imaging.Encoder.Quality
            myEncoderParameter = New Imaging.EncoderParameter(myEncoder, CType(50L, Int32))
            myEncoderParameters.Param(0) = myEncoderParameter
            MyOnlineImg.Save(ms, myImageCodecInfo, myEncoderParameters)
            Dim imgdata() As Byte = ms.GetBuffer
            'Dim blog As New WordPressWrapper(Settings.Store.oauth_Website & "/xmlrpc.php", Settings.Store.oauth_AdminUserName, Settings.Store.oauth_AdminPassword)
            'Dim mObj = blog.NewMediaObject(New MediaObject With {.Bits = imgdata, .name = name & ".png", .Type = "image/png"})
            ''db.runNonQuery("Insert into onlineimgurls (Name,Url) values (" & ToSQLsafe(fpName, True) & "," & ToSQLsafe(mObj.URL.ToString, True) & ")")
            Return "1234" 'mObj.URL.ToString
        Catch ex As Exception
            Dim i = 0
        End Try
        Return ""
    End Function

    Public Shared Function GetEncoderInfo(ByVal format As Imaging.ImageFormat) As Imaging.ImageCodecInfo
        Dim j As Integer
        Dim encoders() As Imaging.ImageCodecInfo
        encoders = Imaging.ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).FormatDescription.ToLower.Contains(format.ToString.ToLower) Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return encoders(j)

    End Function
End Class
