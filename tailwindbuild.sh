#!/usr/bin/env bash

appStylesPathIn="./Styles/styles.css"
appStylesPathOut="./wwwroot/css/razor-ui.css"

if [ -z "${TAILWINDCSS_PATH}" ]; then
  # Not set, so use default
  TAILWINDCSS_PATH="tailwindcss"
fi

$TAILWINDCSS_PATH -i $appStylesPathIn -o $appStylesPathOut $@