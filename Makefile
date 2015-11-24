.PHONY: all clean

IODLL=./src/
OUT=./bin/sudizzle.exe
CC=fsharpc
# CFLAGS=-a --warnaserror+ --nologo
SRC=./src
LIB=$(SRC)/lib

FILES=$(SRC)/sudizzle.fsx $(LIB)/Sudoku.fs $(LIB)/sudoku.fs $(LIB)/sudoku.fsi $(LIB)/io.fs $(LIB)/io.fsi

build:
	${CC} -o $(OUT) ${FILES}