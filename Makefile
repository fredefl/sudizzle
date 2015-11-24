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
	${CC} -a -o $(OUTDLL) $(LIB)/sudoku.fsi $(LIB)/sudoku.fs
	${CC} -o $(OUTEXE) $(SRC)/sudizzle.fsx -r $(OUTDLL)

run:
	make build
	mono $(OUTEXE)