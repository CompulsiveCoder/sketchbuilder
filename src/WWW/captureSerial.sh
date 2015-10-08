#!/bin/bash

echo "Port:"
echo $1

ino serial -p $1 > serialOutput.txt
