#!/bin/bash


appStylesPathIn="./Styles/styles.css"
appStylesPathOut="./wwwroot/css/styles.css"

if [[ $1 == "--watch" ]]; then
  echo "Building Tailwind CSS in watch mode..."
  $TAILWINDCSS -i $appStylesPathIn -o $appStylesPathOut --watch
else
  echo "Building Tailwind CSS..."
  $TAILWINDCSS -i $appStylesPathIn -o $appStylesPathOut
fi