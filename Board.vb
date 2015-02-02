Public Class Board
    Const NumberOfRows As Int16 = 3
    Const NumberOfColumns As Int16 = 3

    Public BoardSquares(NumberOfRows, NumberOfColumns) As String
    Public NumberEmptySquares As Int16 = (NumberOfRows * NumberOfColumns)
    Public PlayerTurn As String = String.Empty

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub displayBoard()
        Console.WriteLine("")
        Console.WriteLine("Tic Tac Toe")
        Console.WriteLine("")

        For row As Int16 = 0 To (NumberOfRows - 1)
            For column As Int16 = 0 To (NumberOfColumns - 1)
                If (BoardSquares(row, column) = String.Empty) Then
                    BoardSquares(row, column) = " "
                End If

                Console.Write(BoardSquares(row, column))

                If (column <> (NumberOfColumns - 1)) Then
                    Console.Write(" | ")
                End If
            Next


            Console.WriteLine(" ")

            If (row <> (NumberOfRows - 1)) Then
                Console.WriteLine("---------")
            End If
        Next

    End Sub

    ''' <summary>
    ''' Clear board of all X's and O's
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clearBoard()
        For row As Int16 = 0 To NumberOfRows - 1
            For column As Int16 = 0 To NumberOfColumns - 1
                BoardSquares(row, column) = String.Empty
            Next
        Next
    End Sub

    ''' <summary>
    ''' Insert an X or O in a specified square
    ''' </summary>
    ''' <param name="piece"></param>
    ''' <param name="row"></param>
    ''' <param name="column"></param>
    ''' <remarks></remarks>
    Public Sub insertPiece(ByVal piece As String, ByVal row As Int16, ByVal column As Int16)

        If ((isRowValid(row.ToString)) AndAlso (isColumnValid(column.ToString)) AndAlso (isPieceValid(piece))) Then
            If (isSquareOpen(row, column)) Then
                BoardSquares(row, column) = piece
                NumberEmptySquares = CShort(NumberEmptySquares - 1)
            End If
        Else
            Throw New InvalidCastException("row, column, or piece not valid for Tic Tac Toe.")
        End If

    End Sub

    ''' <summary>
    ''' Determine if entered column is valid for board
    ''' </summary>
    ''' <param name="columnNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isColumnValid(ByVal columnNumber As String) As Boolean
        Dim parsedColumnNumber As Int16

        If (String.IsNullOrWhiteSpace(columnNumber.Trim)) Then
            Return False
        Else
            If (Short.TryParse(columnNumber, parsedColumnNumber)) AndAlso ((parsedColumnNumber >= 0) AndAlso (parsedColumnNumber < NumberOfColumns)) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    ''' <summary>
    ''' Determine if entered row is valid for board
    ''' </summary>
    ''' <param name="rowNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isRowValid(ByVal rowNumber As String) As Boolean
        Dim parsedRowNumber As Int16

        If (String.IsNullOrWhiteSpace(rowNumber.Trim)) Then
            Return False
        Else
            If (Short.TryParse(rowNumber, parsedRowNumber)) AndAlso ((parsedRowNumber >= 0) AndAlso (parsedRowNumber < NumberOfRows)) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    ''' <summary>
    ''' Determine if entered piece is valid for board
    ''' </summary>
    ''' <param name="piece"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isPieceValid(ByVal piece As String) As Boolean
        If (String.IsNullOrWhiteSpace(piece)) Then
            Return False
        Else
            If ((piece.ToUpper = "X") OrElse (piece.ToUpper = "O")) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    ''' <summary>
    ''' Determine if square is open for play
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="column"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isSquareOpen(ByVal row As Int16, ByVal column As Int16) As Boolean
        If (Not String.IsNullOrWhiteSpace(BoardSquares(row, column))) Then
            If ((BoardSquares(row, column).ToUpper = "X") OrElse (BoardSquares(row, column).ToUpper = "O")) Then
                Return False
            End If
        Else
            Return True
        End If

        Return True
    End Function

    ''' <summary>
    ''' Determine if a specific player won a game
    ''' </summary>
    ''' <param name="player"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isWinner(ByVal player As String) As Boolean
        If (isPieceValid(player)) Then
            'Horizontal win
            For row As Int16 = 0 To 2
                If ((BoardSquares(row, 0).ToUpper = player) AndAlso (BoardSquares(row, 1).ToUpper = player) AndAlso (BoardSquares(row, 2).ToUpper = player)) Then
                    Return True
                End If
            Next

            'Vertical win
            For column As Int16 = 0 To 2
                If ((BoardSquares(0, column).ToUpper = player) AndAlso (BoardSquares(1, column).ToUpper = player) AndAlso (BoardSquares(2, column).ToUpper = player)) Then
                    Return True
                End If
            Next

            'Diagonal win
            If (((BoardSquares(0, 0).ToUpper = player) AndAlso (BoardSquares(1, 1).ToUpper = player) AndAlso (BoardSquares(2, 2).ToUpper = player)) OrElse _
                ((BoardSquares(0, 2).ToUpper = player) AndAlso (BoardSquares(1, 1).ToUpper = player) AndAlso (BoardSquares(2, 0).ToUpper = player))) Then
                Return True
            End If

            Return False
        Else
            Throw New InvalidCastException("player is not valid")
        End If
    End Function

    ''' <summary>
    ''' Determine if a game is a draw
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isDraw() As Boolean
        If (isWinner("X")) Then
            Return False
        End If

        If (isWinner("O")) Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Determine if it is player's turn
    ''' </summary>
    ''' <param name="piece"></param>
    ''' <param name="previousPiece"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isPieceTurn(ByVal piece As String, ByVal previousPiece As String) As Boolean
        If (isPieceValid(piece)) Then
            If (piece = previousPiece) Then
                Return False
            End If

            Return True
        End If

        Return False
    End Function
End Class
