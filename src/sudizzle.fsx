let help() =
  printfn "%s" """
  Spillet understøtter følgende kommandoer:

  help  - bringer denne hjælp frem
  save  - gemmer spillet
  hint  - giver et hint til et felt

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


let mutable savedAs = ""

let saveGame sudoku =
  printfn "%s" """
  Indtast det filnavn du vil gemme som.
  """
  
  printf "[%s]> " savedAs
  
  let input = System.Console.ReadLine() 

  if savedAs <> "" && input = "" then
    Sudoku.save savedAs sudoku
  else
    Sudoku.save input sudoku
    savedAs <- input

  printfn "Spillet blev gemt!"

let displayHint sudoku =
  printfn "%s" """
  Indtast feltet du vil have et hint for: r,s
  """
  
  printf "hint > "

  let input = System.Console.ReadLine() 

  let numbers = stripNonNumbers input
  if String.length numbers = 2 then
    let r = int(numbers.[0]) - 49
    let s = int(numbers.[1]) - 49

    printfn "%A" (Sudoku.hints (r, s) sudoku)
  else
    printfn "Forkert indtasting af hint!"

let rec loop sudoku =
  // Print the sudoku to screen
  Sudoku.print sudoku

  // Keep asking the user for input with recursion
  let rec interrogate() =
    printf "> "
    let input = System.Console.ReadLine()
    match input with
    | "save" -> saveGame sudoku; interrogate ();
    | "help" -> help(); interrogate ();
    | "hint" -> displayHint sudoku; interrogate ();
    | _ ->
      let numbers = stripNonNumbers input
      if String.length numbers = 3 then
        let r = int(numbers.[0]) - 49
        let s = int(numbers.[1]) - 49
        let v = int(numbers.[2]) - 48

        printfn "Indtasting r:%d s:%d v:%d" r s v

        match Sudoku.insert (r,s) v sudoku with
        | Some x -> loop (x)
        | None -> 
          printfn "Forkert indtastning"
          interrogate()
        ()
      else
        printfn "Forkert indtastning"
        interrogate ()
  interrogate() 

let newGame() =
  loop(Sudoku.load "./templates/01.txt")


let loadGame() =
  printfn "%s" """
  Indtast venligst navnet på det gemte spil
  """

  printf "> "
  let input = System.Console.ReadLine() 

  help()

  input |> Sudoku.load |> loop
  ()


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
      | "indlæs"  -> loadGame()
      | _ -> 
        printf "%s" "Forkert input, prøv igen!\n";
        interrogate()

  interrogate()

  // Return 0 to indicate success
  0