module Sudoku

(*
	Print
	Check (row, col) altså, koordinater
		hjælpedreng til kvadrant
	


 *)

type row = list<int>
type board = list<row>

let rec transpose = function
    | (_ :: _) :: _ as list -> List.map List.head list :: transpose (List.map List.tail list)
    | _ -> []

let region (r, s) (list : board) =
    let r, s = (r / 3 * 3, s / 3 * 3)
    List.collect (fun (x : row) -> x.[s .. s + 2]) list.[r .. r + 2]

let hints (r, s) (list : board) =
    let missin' = Set.difference (set [1 .. 9])
    seq [set list.[r] |> missin'                                   // Horizontal
         set (transpose list).[s] |> missin'                       // Vertikal
         set (region (r, s) list) |> missin'] |> Set.intersectMany // Region
         
exception SHIZZ'

let rec insert (r, s) v list =
    List.mapi (fun i x -> if i <> r then x else
                          List.mapi (fun i x -> if i <> s then x else
                                                if (hints (r, s) list).Contains v then v
                                                else raise SHIZZ') x) list
