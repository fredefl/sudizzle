module Sudoku

type row = list<int>
type board = list<row>

/// <summary><c>hints</c>-funktionen finder de værdier som kan indsættes i et givent felt.</summary>
/// <param name = "felt"></param>
/// <param name = "bræt"></param>
/// <returns><c>set</c> af værdier.</returns>
val hints : (int * int) -> board -> Set<int>

/// <summary><c>isFinished</c> tjekker om alle rækker indeholder tal fra 1 - 9.</summary>
/// <param name = "bræt"></param>
/// <returns>Hvorvidt om spillet er ovre.</returns>
val isFinished : board -> bool

/// <summary>Indsætter en værdi.</summary>
/// <param name = "felt"></param>
/// <param name = "værdi"></param>
/// <param name = "bræt"></param>
/// <returns>Shizz'</returns>
val insert : (int * int) -> int -> board -> board option

/// <summary>Printer Soduko plade.</summary>
/// <param name = "bræt"></param>
val print : board -> unit

/// <summary>Loader et bræt fra fil.</summmary>
/// <param name = "filnavn"></param>
/// <returns>Et bræt</returns>
val load : string -> board

/// <summary>Gemmer et bræt til fil.</summmary>
/// <param name = "filnavn"></param>
/// <param name = "bræt"></param>
val save : string -> board -> unit
