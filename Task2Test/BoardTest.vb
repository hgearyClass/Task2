Imports System.Text

<TestClass()>
Public Class BoardTest

    <TestMethod()>
    Public Sub insertPieceTest()
        Dim playingBoard As Task2.Board = New Task2.Board
        Dim testRow As String = "0"
        Dim testColumn As String = "0"
        Dim testPiece As String = "x"

        playingBoard.BoardSquares(0, 1) = "X"

        If ((playingBoard.isRowValid(testRow)) AndAlso (playingBoard.isColumnValid(testColumn)) AndAlso (playingBoard.isPieceValid(testPiece))) Then
            If (playingBoard.isSquareOpen(CShort(testRow), CShort(testColumn))) Then
                playingBoard.insertPiece(testPiece, CShort(testRow), CShort(testColumn))
            End If
        Else
            Throw New ArgumentException("row, column, or piece not valid")
        End If
    End Sub

    <TestMethod()>
    Public Sub clearBoardTest()
        Dim playingBoard As New Task2.Board

        For row As Int16 = 0 To 2
            For column As Int16 = 0 To 2
                Assert.IsTrue(playingBoard.BoardSquares(row, column) = String.Empty)
            Next
        Next
    End Sub

    <TestMethod()>
    Public Sub isWinnerTest()
        Dim playingBoard As New Task2.Board
        Dim testPlayer As String = "x"

        playingBoard.insertPiece("o", 0, 0)
        playingBoard.insertPiece("x", 0, 1)
        playingBoard.insertPiece("o", 0, 2)
        playingBoard.insertPiece("x", 1, 0)
        playingBoard.insertPiece("x", 1, 1)
        playingBoard.insertPiece("o", 1, 2)
        playingBoard.insertPiece("o", 2, 0)
        playingBoard.insertPiece("o", 2, 1)
        playingBoard.insertPiece("X", 2, 2)

        If (playingBoard.isPieceValid(testPlayer)) Then
            If (playingBoard.isWinner(testPlayer)) Then
                Assert.IsTrue(playingBoard.isWinner(testPlayer))
            Else
                Assert.IsFalse(playingBoard.isWinner(testPlayer))
            End If
        Else
            Throw New ArgumentException("testPlayer invalid")
        End If
    End Sub

    <TestMethod()>
    Public Sub isDrawTest()
        Dim playingBoard As New Task2.Board
        Dim testPlayer As String = "x"

        playingBoard.insertPiece("o", 0, 0)
        playingBoard.insertPiece("x", 0, 1)
        playingBoard.insertPiece("o", 0, 2)
        playingBoard.insertPiece("x", 1, 0)
        playingBoard.insertPiece("X", 1, 1)
        playingBoard.insertPiece("o", 1, 2)
        playingBoard.insertPiece("o", 2, 0)
        playingBoard.insertPiece("o", 2, 1)
        playingBoard.insertPiece("X", 2, 2)

        Assert.IsTrue(playingBoard.isDraw())

        If (playingBoard.isPieceValid(testPlayer)) Then
            If (playingBoard.isDraw()) Then
                Assert.IsTrue(playingBoard.isDraw())
            Else
                Assert.IsFalse(playingBoard.isDraw())
            End If
        Else
            Throw New ArgumentException("testPlayer invalid")
        End If
    End Sub

    <TestMethod()>
    Public Sub isSquareOpenTest()
        Dim playingBoard As New Task2.Board
        Dim testRow As String = "0"
        Dim testColumn As String = "0"
        Dim squareOpen As Boolean = False

        If ((playingBoard.isRowValid(testRow)) AndAlso (playingBoard.isColumnValid(testColumn))) Then
            squareOpen = playingBoard.isSquareOpen(CShort(testRow), CShort(testColumn))
        Else
            Throw New ArgumentException("row or column not valid")
        End If

    End Sub

End Class
