CALL C:\Install\dotnet\vars.cmd
CALL C:\Install\dotnet\dotnet-desktop.cmd

start appwiz.cpl
start services.msc

start "" "C:\dojo\BeltTest\BeltTestPackage\bin\x64\Debug\en-US"
start "" "C:\Program Files"