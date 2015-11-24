module Sudoku

type row = list<int>
type board = list<row>

/// <summary><c>hints</c>-funktionen finder de v�rdier som kan inds�ttes i et givent felt.</summary>
/// <param name = "felt"></param>
/// <param name = "br�t"></param>
/// <returns><c>set</c> af v�rdier.</returns>
val hints : (int * int) -> board -> Set<int>

/// <summary><c>isFinished</c> tjekker om alle r�kker indeholder tal fra 1 - 9.</summary>
/// <param name = "br�t"></param>
/// <returns>Hvorvidt om spillet er ovre.</returns>
val isFinished : board -> bool

/// <summary>Inds�tter en v�rdi.</summary>
/// <param name = "felt"></param>
/// <param name = "v�rdi"></param>
/// <param name = "br�t"></param>
/// <returns>Shizz'</returns>
val insert : (int * int) -> int -> board -> board option

/// <summary>Printer Soduko plade.</summary>
/// <param name = "br�t"></param>
val print : board -> unit

/// <summary>Loader et br�t fra fil.</summmary>
/// <param name = "filnavn"></param>
/// <returns>Et br�t</returns>
val load : string -> board

/// <summary>Gemmer et br�t til fil.</summmary>
/// <param name = "filnavn"></param>
/// <param name = "br�t"></param>
val save : string -> board -> unit
