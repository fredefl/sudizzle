.PHONY: all clean

IODLL=./src/
OUTEXE=./bin/sudizzle.exe
OUTDLL=./bin/sudoku.dll
CC=fsharpc
# CFLAGS=-a --warnaserror+ --nologo
SRC=./src
LIB=$(SRC)/lib

FILES=$(SRC)/sudizzle.fsx $(LIB)/sudoku.fs $(LIB)/sudoku.fsi

build:
	${CC} -a -o $(OUTDLL) $(LIB)/sudoku.fs $(LIB)/sudoku.fsi
	${CC} -o $(OUTEXE) $(SRC)/sudizzle.fsx -r $(OUTDLL)