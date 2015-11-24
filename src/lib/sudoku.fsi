module Sudoku

type row = list<int>
type board = list<row>

/// Finder de tal som kan indsættes på en given plads.
val hints : (int * int) -> board -> Set<int>

/// Tjekker om alle rækker indeholder alle tal fra 1 - 9.
val isFinished : board -> bool

/// Indsætter et element. 
val insert : (int * int) -> int -> board -> board

/// Printer Soduko plade.
val print : board -> unit