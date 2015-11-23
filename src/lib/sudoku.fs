module Sudoku

let span = [1 .. 9]
type row = list<int>
type board = list<row>

let rec transpose = function
    | (_ :: _) :: _ as list -> List.map List.head list :: transpose (List.map List.tail list)
    | _ -> []

let region (r, s) (list : board) =
    let r, s = (r / 3 * 3, s / 3 * 3)
    List.collect (fun (x : row) -> x.[s .. s + 2]) list.[r .. r + 2]

let hints (r, s) (list : board) =
    let missin' = Set.difference (set span)
    seq [set list.[r] |> missin'                                   // Horizontal
         set (transpose list).[s] |> missin'                       // Vertical
         set (region (r, s) list) |> missin'] |> Set.intersectMany // Region

let rec insert (r, s) v list =
    if not ((hints (r, s) list).Contains v) then None else
    List.mapi (fun i x -> if i <> r then x else
                          List.mapi (fun i x -> if i <> s then x else v) x) list |> Some

let print list =
    let rec line i format = function
        | head :: tail ->
            List.iter (fun x -> printf format (if x = 0 then " " else x.ToString ())) (i :: head)
            printfn "\n   +---+---+---+---+---+---+---+---+---+"
            line (i + 1) " %s |" tail
        | _ -> ()
    line 0 " %s  " (span :: list)
