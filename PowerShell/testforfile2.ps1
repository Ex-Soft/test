param(
#source directory
[string]$srcDir = '',
#number of days
[int]$numberOfDays = 3
)

echo $srcDir
echo $srcDir.length

if ($srcDir.length -eq 0)
{
	return
}

echo $numberOfDays

$suffix = "_stamp"
echo $suffix

$dateTo = Get-Date
$dateTo = $dateTo.AddDays(-$numberOfDays)
echo $dateTo
echo $dateTo.Date

foreach ($item in get-childitem -path $srcDir -recurse -file | where-object {$_.LastWriteTime -le $dateTo})
{
	echo $item.Name				# TestImageI.jpg
	echo $item.FullName			# D:\temp\img\TestImageI.jpg
	echo $item.BaseName			# TestImageI
	echo $item.Extension		# .jpg
	echo $item.LastWriteTime	# Monday, 26 March, 2018 1:20:49 pm
	echo $item.BaseName.Substring($item.BaseName.Length - $suffix.Length)

	if ($item.BaseName.Substring($item.BaseName.Length - $suffix.Length) -eq $suffix)
	{
		echo "oB!"
	}

	if ($item.BaseName.Contains($suffix) -eq $true)
	{
		echo "oB!"
		continue
	}

	$folderPath = split-path $item.fullname -parent
	echo $folderPath

	$fileNameWithStamp = $folderPath + "\" + $item.BaseName + $suffix + $item.Extension
	echo $fileNameWithStamp

	if (-not ($fileNameWithStamp | Test-Path))
	{
		echo "!oB!"
		continue
	}
}
