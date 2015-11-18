#!/bin/bash

filename="sudizzle"
fsharpc ./src/$filename.fsx -o ./bin/$filename.exe && mono ./bin/$filename.exe