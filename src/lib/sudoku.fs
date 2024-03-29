module Sudoku

type row = list<int>
type board = list<row>

let span = [1 .. 9]
let missin' = Set.difference (set span)

let rec transpose = function
    | (_ :: _) :: _ as list -> List.map List.head list :: transpose (List.map List.tail list)
    | _ -> []

let region (r, s) (list : board) =
    let r, s = (r / 3 * 3, s / 3 * 3)
    List.collect (fun (x : row) -> x.[s .. s + 2]) list.[r .. r + 2]

let hints (r, s) (list : board) =
    seq [set list.[r] |> missin'
         set (transpose list).[s] |> missin'
         set (region (r, s) list) |> missin'] |> Set.intersectMany

let isFinished (list : board) = 
    List.forall (fun x -> (missin' (set x)).Count = 0) list

let insert (r, s) v list =
    if not ((hints (r, s) list).Contains v) then None else
    List.mapi (fun i x -> if i <> r then x else
                          List.mapi (fun i x -> if i <> s then x else v) x) list |> Some

let print list =
    let case0 x value = if x = 0 then " " else value
    List.iteri (fun i x -> List.iter (fun x -> printf " %s %s" (case0 x (x.ToString ())) (case0 i "|")) (i :: x)
                           printfn "\n   +---+---+---+---+---+---+---+---+---+") (span :: list)

let parse input =
    List.map (fun x -> Seq.foldBack (fun y acc -> (if y = '*' then 0 else (System.Convert.ToInt32 y) - 48) :: acc) x []) input

let stringify list =
    List.map (fun x -> List.fold (fun acc y -> acc + if y = 0 then "*" else y.ToString ()) "" x) list

let load file =
    System.IO.File.ReadAllLines file |> List.ofArray |> parse

let save file list =
    System.IO.File.WriteAllLines (file, stringify list)    