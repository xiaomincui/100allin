Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

'/ <summary>
'/ SymmetricMethod ��ժҪ˵��
'/ </summary>
Public Class SymmetricMethod


    Private mobjCryptoService As SymmetricAlgorithm
    Private Key As String

    '/ <summary>   
    '/ �ԳƼ�����Ĺ��캯��   
    '/ </summary>   
    Public Sub New()
        mobjCryptoService = New RijndaelManaged()
        Key = "2XkLVKNBl2JrZQE2yvknvUysq9ukHqZcVlSwl4sFQjbDTBehBbHsxIoqM5LfJLi8"
    End Sub 'New

    '/ <summary>   
    '/ �����Կ   
    '/ </summary>   
    '/ <returns>��Կ</returns>   
    Private Function GetLegalKey() As Byte()
        Dim sTemp As String = Key
        mobjCryptoService.GenerateKey()
        Dim bytTemp As Byte() = mobjCryptoService.Key
        Dim KeyLength As Integer = bytTemp.Length
        If sTemp.Length > KeyLength Then
            sTemp = sTemp.Substring(0, KeyLength)
        Else
            If sTemp.Length < KeyLength Then
                sTemp = sTemp.PadRight(KeyLength, " "c)
            End If
        End If
        Return ASCIIEncoding.ASCII.GetBytes(sTemp)
    End Function 'GetLegalKey

    '/ <summary>   
    '/ ��ó�ʼ����IV   
    '/ </summary>   
    '/ <returns>��������IV</returns>   
    Private Function GetLegalIV() As Byte()
        Dim sTemp As String = "bdUCCcJZvLwki86tcCCW6Qj8XS2Qfu6tmG55KFhrf76ijAOugxCyxX0GzUY334Io"
        mobjCryptoService.GenerateIV()
        Dim bytTemp As Byte() = mobjCryptoService.IV
        Dim IVLength As Integer = bytTemp.Length
        If sTemp.Length > IVLength Then
            sTemp = sTemp.Substring(0, IVLength)
        Else
            If sTemp.Length < IVLength Then
                sTemp = sTemp.PadRight(IVLength, " "c)
            End If
        End If
        Return ASCIIEncoding.ASCII.GetBytes(sTemp)
    End Function 'GetLegalIV

    '/ <summary>   
    '/ ���ܷ���   
    '/ </summary>   
    '/ <param name="Source">�����ܵĴ�</param>   
    '/ <returns>�������ܵĴ�</returns>   
    Public Function Encrypto(ByVal [Source] As String) As String
        Dim bytIn As Byte() = UTF8Encoding.UTF8.GetBytes([Source])
        Dim ms As New MemoryStream()
        mobjCryptoService.Key = GetLegalKey()
        mobjCryptoService.IV = GetLegalIV()
        Dim encrypto1 As ICryptoTransform = mobjCryptoService.CreateEncryptor()
        Dim cs As New CryptoStream(ms, encrypto1, CryptoStreamMode.Write)
        cs.Write(bytIn, 0, bytIn.Length)
        cs.FlushFinalBlock()
        ms.Close()
        Dim bytOut As Byte() = ms.ToArray()


        Return EncodeBase64(Convert.ToBase64String(bytOut))
    End Function 'Encrypto

    '/ <summary>   
    '/ ���ܷ���   
    '/ </summary>   
    '/ <param name="Source">�����ܵĴ�</param>   
    '/ <returns>�������ܵĴ�</returns>   
    Public Function Decrypto(ByVal [Source] As String) As String
        [Source] = DecodeBase64([Source])
        Dim bytIn As Byte() = Convert.FromBase64String([Source])
        Dim ms As New MemoryStream(bytIn, 0, bytIn.Length)
        mobjCryptoService.Key = GetLegalKey()
        mobjCryptoService.IV = GetLegalIV()
        Dim encrypto As ICryptoTransform = mobjCryptoService.CreateDecryptor()
        Dim cs As New CryptoStream(ms, encrypto, CryptoStreamMode.Read)
        Dim sr As New StreamReader(cs)

        Return sr.ReadToEnd()
    End Function 'Decrypto


    '����
    Private Function EncodeBase64(ByVal code As String) As String
        Dim encode As String = ""
        Dim bytes As Byte() = Encoding.GetEncoding("utf-8").GetBytes(code)
        Try
            encode = Convert.ToBase64String(bytes)
        Catch
        End Try
        Return encode
    End Function 'EncodeBase64

    '����
    Private Function DecodeBase64(ByVal code As String) As String
        Dim decode As String = ""
        Dim bytes As Byte() = Convert.FromBase64String(code)
        Try
            decode = Encoding.GetEncoding("utf-8").GetString(bytes)
        Catch
        End Try
        Return decode
    End Function 'DecodeBase64
End Class 'SymmetricMethod 