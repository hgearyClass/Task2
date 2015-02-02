Module Module1

    Sub Main()
        Dim myBoard As New Board
        Dim userInput As String = String.Empty

        Dim row As Int16 = 0
        Dim column As Int16 = 0
        Dim piece As String = String.Empty
        Dim previousPiece As String = String.Empty

        myBoard.clearBoard()

        myBoard.displayBoard()

        Console.WriteLine("")

        While myBoard.NumberEmptySquares <> 0
            Console.Write("Enter the row: ")
            userInput = Console.ReadLine()
            While Not myBoard.isRowValid(userInput)
                Console.Write("Enter the row: ")
                userInput = Console.ReadLine()
            End While

            row = CShort(userInput)

            Console.Write("Enter the column: ")
            userInput = Console.ReadLine()
            While Not myBoard.isColumnValid(userInput)
                Console.Write("Enter the column: ")
                userInput = Console.ReadLine()
            End While

            column = CShort(userInput)

            Console.Write("Enter X or O: ")
            userInput = Console.ReadLine()
            While Not (myBoard.isPieceValid(userInput) And myBoard.isPieceTurn(userInput, previousPiece))
                Console.Write("Enter X or O: ")
                userInput = Console.ReadLine()
            End While

            piece = userInput

            myBoard.insertPiece(piece, row, column)

            previousPiece = piece

            myBoard.displayBoard()

            If ((myBoard.isWinner("X")) OrElse (myBoard.isWinner("O"))) Then
                myBoard.NumberEmptySquares = 0
            End If
        End While

        Console.WriteLine("")

        If (myBoard.isWinner("O")) Then
            Console.WriteLine("O WINS")
        End If

        If (myBoard.isWinner("X")) Then
            Console.WriteLine("X WINS")
        End If

        If (myBoard.isDraw()) Then
            Console.WriteLine("Game is a DRAW")
        End If
    End Sub
End Module
