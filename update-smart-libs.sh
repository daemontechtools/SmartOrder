#!/usr/bin/env bash

file1="/home/josh/Downloads/SMART.Common.dll"
file2="/home/josh/Downloads/SMART.Common.Functions.dll"

soApp="/home/josh/Projects/SmartOrder/lib/"
daApp="/home/josh/Projects/daemon-dotnet/DataAccess/lib/"
oaApp="/home/josh/Projects/SMARTWebOrderApi/lib/"

cp -f "$file1" "$soApp"
cp -f "$file1" "$daApp"
cp -f "$file1" "$oaApp"

cp -f "$file2" "$soApp"
cp -f "$file2" "$daApp"
cp -f "$file2" "$oaApp"