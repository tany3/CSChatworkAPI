#
# script of generating nupkg.
#
Param($SolutionDir, $ProjectPath, $TargetDir)

if (!$SolutionDir -Or !(Test-Path $SolutionDir))
{
	Write-Host "not exists: [0]SolutionDir" -foregroundcolor red -backgroundcolor yellow
	Write-Host "args: [0]SolutionDir [1]ProjectPath [2]TargetDir"
	exit -1
}
if (!$ProjectPath -Or !(Test-Path $ProjectPath))
{
	Write-Host "not exists: [1]ProjectPath" -foregroundcolor red -backgroundcolor yellow
	Write-Host "args: [0]SolutionDir [1]ProjectPath [2]TargetDir"
	exit -1
}
if (!$TargetDir -Or !(Test-Path $TargetDir))
{
	Write-Host "not exists: [2]TargetDir" -foregroundcolor red -backgroundcolor yellow
	Write-Host "args: [0]SolutionDir [1]ProjectPath [2]TargetDir"
	exit -1
}


#
# main
#

# location of nupkg
$nupkgTargetPath = (Join-Path $TargetDir "\nupkg")
# location of NuGet.exe
$nugetExecutable = (Join-Path $SolutionDir "\.nuget\NuGet.exe")


# cleanup before generating nupkg.
mkdir $nupkgTargetPath
Remove-Item (Join-Path $nupkgTargetPath "\*")

# generate!
& $nugetExecutable pack $ProjectPath -Prop Configuration=Release -Symbol -OutputDirectory $nupkgTargetPath
