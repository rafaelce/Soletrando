Public Class SeparaSilabas

    ''' <summary>
    ''' letra
    ''' </summary>
    ''' <param name="c">caracter da string que será separada</param>
    ''' <returns>retora um inteiro caso a letra corresponda a uma vogal acentuada ou não</returns>

    Private Shared Function letra(ByVal c As Char) As Integer
        Dim i As Integer = -1
        Dim ascii As Integer
        ascii = Convert.ToInt32(c)

        If (ascii <> -1) Then
            Select Case (ascii)
                Case 97
                    'a
                    i = 1
                Case 101
                    'e
                    i = 2
                Case 105
                    'i
                    i = 4
                Case 111
                    'o
                    i = 3
                Case 117
                    'u
                    i = 5
                Case 225
                    'á
                    i = 1
                Case 233
                    'é
                    i = 2
                Case 237
                    'í
                    i = 4
                Case 243
                    'ó
                    i = 3
                Case 250
                    'ú
                    i = 5
                Case 252
                    'ü
                    i = 5
                Case Else
                    i = 19
            End Select
        End If

        Return i
    End Function

    ''' <summary>
    ''' silaba
    ''' </summary>
    ''' <param name="str">palavra que será separada</param>
    ''' <returns>a função verifica se a palavra é monossílabo, se possui hiato, se possui um encontro vocálico etc </returns>
    Private Shared Function silaba(ByVal str As String) As String
        Dim temp As String = ""
        Dim s As String = ""
        Dim z As Char
        Dim x As Char
        Dim y As Char
        If str.Length < 3 Then
            If str.Length = 2 Then
                'monossílabos
                x = str.Substring(0, 1)
                y = str.Substring(1, 1)

                If letra(x) < 6 And letra(y) < 6 Then
                    If hiato(x, y) Then
                        s = str.Substring(0, 1)
                    Else
                        s = str
                    End If

                Else
                    s = str
                End If

            Else
                s = str
            End If

        Else
            x = str.Substring(0, 1)
            y = str.Substring(1, 1)
            z = str.Substring(2, 1)
            If letra(x) < 6 Then
                'V ? ?
                If letra(y) < 6 Then
                    'V V ?
                    If letra(z) < 6 Then
                        'V V V
                        If hiato(x, y) Then
                            s = str.Substring(0, 1)
                        ElseIf hiato(y, z) Then
                            s = str.Substring(0, 2)
                        Else
                            s = str.Substring(0, 3)
                        End If

                    Else
                        ' V V C
                        If hiato(x, y) Then
                            s = str.Substring(0, 1)
                        Else
                            s = str.Substring(0, 2)
                        End If

                    End If

                Else
                    ' V C ?
                    If letra(z) < 6 Then
                        'V C V
                        If letra(y) = 6 Then
                            ' V H C
                            If hiato(x, z) Then
                                s = str.Substring(0, 1)
                            Else
                                s = str.Substring(0, 3)
                            End If

                        Else
                            s = str.Substring(0, 1)
                        End If

                    Else
                        ' V C C
                        If consonantes1(y, z) Then
                            s = str.Substring(0, 1)
                        Else
                            s = str.Substring(0, 2)
                        End If

                    End If

                End If

            Else
                ' C ??
                If letra(y) < 6 Then
                    'C V ?
                    If letra(z) < 6 Then
                        ' C V V
                        temp = str.Substring(0, 3)
                        If temp.Equals("que") Or temp.Equals("qui") Or temp.Equals("gue") Or temp.Equals("gui") Then
                            s = str.Substring(0, 3)
                        ElseIf hiato(y, z) Then
                            s = str.Substring(0, 2)
                        Else
                            s = str.Substring(0, 3)
                        End If

                    Else
                        ' C V C
                        s = str.Substring(0, 2)
                    End If

                Else
                    ' C C ?
                    If letra(z) < 6 Then
                        ' C C V
                        If consonantes1(x, y) Then
                            s = str.Substring(0, 3)
                        Else
                            s = str.Substring(0, 1)
                        End If

                    Else
                        ' C C C
                        If consonantes1(y, z) Then
                            s = str.Substring(0, 1)
                        Else
                            s = str.Substring(0, 1)
                        End If

                    End If

                End If

            End If

        End If

        Return s
    End Function

    ''' <summary>
    ''' hiato
    ''' </summary>
    ''' <param name="v">letra 1</param>
    ''' <param name="v2">letra 2</param>
    ''' <returns>retorna True caso a a palabra possua um hiato</returns>
    Private Shared Function hiato(ByVal v As Char, ByVal v2 As Char) As Boolean
        Dim cer As Boolean = False
        If letra(v) < 4 Then
            ' VA + ?
            If letra(v2) < 4 Then
                cer = True
            Else
                'VA+ VC
                If v2 = "í" Or v2 = "ú" Then
                    cer = True
                Else
                    cer = False
                End If

            End If

        Else
            ' VC + ?
            If letra(v2) < 4 Then
                ' VC + VA
                If v = "í" Or v = "ú" Then
                    cer = True
                Else
                    cer = False
                End If
            Else
                'VC + VC
                If v = v2 Then
                    cer = True
                Else
                    cer = False
                End If

            End If

        End If

        Return cer
    End Function

    ''' <summary>
    ''' consonantes1
    ''' </summary>
    ''' <param name="a">consoante 1</param>
    ''' <param name="b">consoante 2</param>
    ''' <returns>retorna true caso os caracteres passados nos parâmetros representem um encontro consonantal</returns>
    Private Shared Function consonantes1(ByVal a As Char, ByVal b As Char) As Boolean
        Dim cer As Boolean
        cer = False

        If a = "b" Or a = "c" Or a = "d" Or a = "f" Or a = "g" Or a = "p" Or a = "t" Or a = "v" Then
            If b = "r" Then
                cer = True
            End If
        End If

        If a = "b" Or a = "c" Or a = "f" Or a = "g" Or a = "p" Or a = "t" Or a = "l" Then
            If b = "l" Then
                cer = True
            End If
        End If

        If b = "h" Then
            If (a = "c") Then
                cer = True
            End If
        End If

        If b = "h" Then
            If a = "l" Then
                cer = True
            End If
        End If

        Return cer
    End Function

    ''' <summary>
    ''' strConsonantes
    ''' </summary>
    ''' <param name="str">Palavra que será separada</param>
    ''' <returns>Retorna True caso a palavra possua uma consoante</returns>
    Private Shared Function strConsonantes(ByVal str As String) As Boolean
        Dim cer As Boolean
        Dim k As Integer
        Dim i As Integer
        Dim c() As Char

        cer = False
        k = 0
        c = str.ToCharArray
        i = 0
        Do While i < str.Length
            If letra(c(i)) > 5 Then
                k = (k + 1)
            End If

            i = (i + 1)
        Loop

        If k = str.Length Then
            cer = True
        End If

        Return cer
    End Function

    Private Shared Function strVVstr(ByVal s1 As String, ByVal s2 As String) As Boolean
        Dim cer As Boolean
        Dim c2 As Char
        Dim c1 As Char

        c1 = s1.Substring(s1.Length - 1, 1)
        c2 = s2.Substring(0, 1)
        cer = False

        If letra(c1) < 6 And letra(c2) < 6 Then
            If hiato(c1, c2) Then
                cer = False
            Else
                cer = True
            End If

        End If

        Return cer
    End Function

    ''' <summary>
    ''' silabear
    ''' </summary>
    ''' <param name="corda">String que será  separada</param>
    ''' <returns>Retorna a string separada por '-'</returns>
    Public Function silabear(ByVal corda As String) As String
        Dim temp As String
        Dim s As String = ""
        Dim k As Integer
        Dim i As Integer
        k = corda.Length
        temp = corda
        i = 0
        Do While i < k
            temp = silaba(corda)
            If i = 0 Then
                s = (s + temp)
            ElseIf strConsonantes(temp) Then
                s = (s + temp)
            ElseIf strVVstr(s, temp) Then
                s = (s + temp)
            ElseIf strConsonantes(s) Then
                s = (s + temp)
            Else
                s = (s + ("-" + temp))
            End If

            i = (i + (temp.Length - 1))
            corda = silabaRest(corda)
            i = (i + 1)
        Loop

        Return s
    End Function

    ''' <summary>
    ''' silabaRest
    ''' </summary>
    ''' <param name="str">restante dos caracteres que estão faltando serem verificados na string que será separada</param>
    ''' <returns>verifica os caracteres restantes da string que será separada</returns>
    Private Shared Function silabaRest(ByVal str As String) As String
        Dim s2 As String
        s2 = silaba(str)
        Return str.Substring(s2.Length)
    End Function

End Class
