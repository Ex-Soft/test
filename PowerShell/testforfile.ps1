param(
#source directory
[string]$srcDir = '',
#destination directory
[string]$destDir = ''
)

#echo $srcDir
#echo $srcDir.length

foreach ($item in get-childitem -path $srcDir -recurse | where-object {$_.Attributes -ne "Directory"})
{
#	if ($item.Attributes -ne "Directory")
#	{
#		echo $item.name
		$folderPath = split-path $item.fullname -parent
#		echo $folderPath
#		echo $folderPath.length
		$path = $folderPath.substring($srcDir.length)
#		echo `"$path`"
		$destPath = join-path -path $destDir -child $path
		if (test-path $destPath)
		{
#			echo $destPath
			$destFileName = $destPath + "\" + $item.name
			echo $destFileName
			$tf = "c:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\tf.exe"
			$prm = "checkout"
			& "$tf" $prm $destFileName
		}
#		$folder = split-path $folderPath -leaf
#		echo $folder
#		echo $item.fullname
#		echo $item.basename
#	}
}