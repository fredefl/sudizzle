.PHONY: all clean

IODLL=./src/
OUTTEST=./bin/test.exe
OUTEXE=./bin/sudizzle.exe
OUTDLL=./bin/sudoku.dll
OUTXML=./bin/documentation.xml
CC=fsharpc
# CFLAGS=-a --warnaserror+ --nologo
SRC=./src
LIB=$(SRC)/lib
.DEFAULT_GOAL=build

FILES=$(SRC)/sudizzle.fsx $(LIB)/sudoku.fs $(LIB)/sudoku.fsi

build-dll:
	${CC} -a -o $(OUTDLL) --doc:$(OUTXML) $(LIB)/sudoku.fsi $(LIB)/sudoku.fs

build-exe:
	${CC} -o $(OUTEXE) $(SRC)/sudizzle.fsx -r $(OUTDLL)
	cp -r ./templates ./bin/templates

build:
	make build-dll
	make build-exe

test:
	make build-dll
	${CC} -o $(OUTTEST) $(SRC)/test.fsx -r $(OUTDLL)
	mono $(OUTTEST)

dev:
	make build
	make run

run:
	mono $(OUTEXE)