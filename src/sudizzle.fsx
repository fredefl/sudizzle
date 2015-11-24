let help() =
  printfn "%s" """
  Spillet understøtter følgende kommandoer:

  help  - bringer denne hjælp frem
  save  - gemmer spillet

  Desuden spilles der ved fx. at skrive:

  (3,2)=2
  322
  3,2,2

  Hvor de tre tal repræsenterer, i denne rækkefølge:

  - række
  - søjle
  - værdi

  God spillelyst!
  """

let stripNonNumbers input =
  String.map (fun c -> if System.Char.IsNumber(c) then c else char(0)) input

let rec loop sudoku =
  // Print the sudoku to screen
  Sudoku.print sudoku

  // Keep asking the user for input with recursion
  let rec interrogate() =
    printf "> "
    let input = System.Console.ReadLine()
    match input with
    //| "save" -> saveGame()
    | "help" -> help()
    | _ ->
      let numbers = stripNonNumbers input
      if String.length numbers = 3 then
        let r = 48 - int(numbers.[0])
        let s = 48 - int(numbers.[1])
        let v = 48 - int(numbers.[2])

        match Sudoku.insert (r,s) v sudoku with
        | Some x -> loop (x)
        | None -> 
          printfn "Forkert indtastning"
          interrogate()
        ()
      else
        interrogate ()
  interrogate() 

let newGame() =
  loop(Sudoku.load "./templates/01.txt")

(*
let loadGame() =
  printfn "%s" """
  Indtast venligst navnet på det gemte spil
  """

  let rec interrogate() = 
    printf "%s" "> "
    let input = System.Console.ReadLine()
    match input with
    | "save" -> 

  
  loop(sudoku)
*)

(*
let mutable savedAs = ""

let saveGame() =
  printfn "Dong" 

*)
(* Main entry point for application *)
[<EntryPoint>]
let main args =
  printfn "%s" """
  Velkommen til SuDizzle, du har nu følgende valgmuligheder:

  - 'start'   for at starte et nyt spil
  - 'indlæs'  for at indlæse et tidligere spil
  """

  // Keeps asking the user for input with recursion
  let rec interrogate() = 
    printf "> " 
    let input = System.Console.ReadLine()
    match input with
      | "start"   -> help(); newGame()
      //| "indlæs"  -> help(); loadGame()
      | _ -> 
        printf "%s" "Forkert input, prøv igen!\n";
        interrogate()

  interrogate()

  // Return 0 to indicate success
  0