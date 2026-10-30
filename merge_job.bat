@echo off
cd /d c:\2026_ProgramacionIIA\SRC\SistemaPublicidad

echo === PASO 1: Commit cambios pendientes en Jsalva ===
git add .
git commit -m "sync sln Jsalva"

echo === PASO 2: Cambiar a master ===
git checkout master

echo === PASO 3: Hacer merge de Jsalva en master ===
git merge Jsalva -m "merge Jsalva en master"

echo === LISTO ===
git log --oneline -5
git branch
