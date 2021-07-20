
Imports System.Security
Imports System.Security.Cryptography

Public Structure EncryptDecrypt

    Private Shared salt As String = "accubp2016_edel"

    Public Shared Function EncryptData(ByVal value As String) As String

        Dim Results() As Byte = Nothing
        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding()

        Dim HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(salt))

        Dim TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        TDESAlgorithm.Key = TDESKey
        TDESAlgorithm.Mode = CipherMode.ECB
        TDESAlgorithm.Padding = PaddingMode.PKCS7

        Dim DataToEncrypt() As Byte = UTF8.GetBytes(value)

        Try
            Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        Finally
            TDESAlgorithm.Clear()
            HashProvider.Clear()
        End Try

        Return Convert.ToBase64String(Results)

    End Function

    Public Shared Function DecryptData(ByVal value As String) As String

        Dim Results() As Byte = Nothing
        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding()

        Dim HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(salt))

        Dim TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        TDESAlgorithm.Key = TDESKey
        TDESAlgorithm.Mode = CipherMode.ECB
        TDESAlgorithm.Padding = PaddingMode.PKCS7

        Dim DataToDecrypt() As Byte = Convert.FromBase64String(value)

        Try
            Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        Finally
            TDESAlgorithm.Clear()
            HashProvider.Clear()
        End Try

        Return UTF8.GetString(Results)

    End Function

End Structure
