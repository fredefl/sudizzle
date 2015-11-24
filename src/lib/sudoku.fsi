module Sudoku

type board = list<row>

val hints : (int * int) -> board -> Set<int>

val isFinished : board -> bool

val insert : (int * int) -> int -> board -> board

val print : board -> unit