#!/usr/bin/env sh
echo moment of doubt!
read
git fetch --all
git reset --hard origin/main

echo ""
read -p "Press enter to continue."