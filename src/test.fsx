let test (id, b) = printfn "%s: %b" id b

let izzle =
    [[5; 3; 0; 0; 7; 0; 0; 0; 0];
     [6; 0; 0; 1; 9; 5; 0; 0; 0];
     [0; 9; 8; 0; 0; 0; 0; 6; 0];
     [8; 0; 0; 0; 6; 0; 0; 0; 3];
     [4; 0; 0; 8; 0; 3; 0; 0; 1];
     [7; 0; 0; 0; 2; 0; 0; 0; 6];
     [0; 6; 0; 0; 0; 0; 2; 8; 0];
     [0; 0; 0; 4; 1; 9; 0; 0; 5];
     [0; 0; 0; 0; 8; 0; 0; 7; 9]];

let finished =
    [[1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9];
     [1; 2; 3; 4; 5; 6; 7; 8; 9]];

test ("[save] t01", Sudoku.save "test.txt" izzle = ())
test ("[save] t02", Sudoku.save "test2.txt" finished = ())

test ("[load] t01", Sudoku.load "text.txt" = izzle)
test ("[load] t02", Sudoku.load "text2.txt" = finished)

test ("[isFinished] t01", Sudoku.isFinished izzle = false)
test ("[isFinished] t02", Sudoku.isFinished finished = true)

test ("[hints] t01", Sudoku.hints (0, 2) izzle = set [1; 2; 4])
test ("[hints] t02", Sudoku.hints (0, 3) izzle = set [2; 6])
test ("[hints] t03", Sudoku.hints (0, 0) finished = set [])

test ("[insert] t01", Sudoku.insert (0, 2) 3 izzle = None)
test ("[insert] t02", Sudoku.insert (0, 2) 2 izzle <> Some izzle)
test ("[insert] t03", Sudoku.insert (0, 0) 1 finished = None)