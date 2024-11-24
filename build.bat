@echo off
setlocal

echo.
echo.
echo ::: Restore
dotnet restore ^
    -bl:restore.binlog ^
    -v detailed

echo.
echo.
echo ::: Build Debug
dotnet build ^
    -c Debug ^
    --no-incremental ^
    -bl:build-debug.binlog ^
    -v detailed

echo.
echo.
echo ::: Test
dotnet test ^
    bin/tests/**/*.Tests.dll ^
    -v detailed ^
    -- NUnit.ConsoleOut=0 NUnit.UseTestNameInConsoleOutput=true NUnit.DisplayName=FullName

echo.
echo.
echo ::: Build Release
dotnet build ^
    -c Release ^
    --no-incremental ^
    -bl:build-release.binlog ^
    -v detailed


echo.
echo.
echo ::: Publish Release win-x64
dotnet publish ^
    -c Release ^
    -r win-x64 ^
    -bl:publish-win-x64.binlog ^
    -v detailed
