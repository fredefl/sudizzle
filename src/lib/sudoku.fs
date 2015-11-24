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

let missin' = Set.difference (set span)

let hints (r, s) (list : board) =
    seq [set list.[r] |> missin'                                   // Horizontal
         set (transpose list).[s] |> missin'                       // Vertical
         set (region (r, s) list) |> missin'] |> Set.intersectMany // Region

let isFinished = List.forall (fun (x : row) -> (missin' (set x)).Count = 0)

let insert (r, s) v list =
    if not ((hints (r, s) list).Contains v) then None else
    List.mapi (fun i x -> if i <> r then x else
                          List.mapi (fun i x -> if i <> s then x else v) x) list |> Some

let print list =
    let case0 x value = if x = 0 then " " else value
    List.iteri (fun i x -> List.iter (fun x -> printf " %s %s" (case0 x (x.ToString ())) (case0 i "|")) (i :: x)
                           printfn "\n   +---+---+---+---+---+---+---+---+---+") (span :: list)

let parse input =
    List.map (fun x -> Seq.fold (fun y -> if y = '*' then 0 else System.Convert.ToInt32 y) "" x) input

let stringify list =
    List.map (fun x -> List.fold (fun y -> if y = 0 then "*" else y.ToString ()) "" x) list

let load file =
    parse (System.IO.ReadAllLines file)

let save file list = 
    System.IO.WriteAllLines (file, stringify list)