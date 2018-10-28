<!doctype html>
<html>
	<head>
		<meta charset="utf-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
		<title>Tables</title>
        <style>
table {
    border-collapse: collapse;
}

tr {
    height: 30px;
}

table, td {
    border: 1px solid black;
    border-collapse: collapse;
}
        </style>
	</head>
	<body>
<?php
$rowSpan = 3;
$maxCol = 9;
$maxRow = 9;
$data = array();
$data[0] = (object)["offset" => 0, "counter" => 0];

echo "<table>";
for ($row = 0; $row < $maxRow; ++$row)
{
    echo "<tr>";
    
    for ($col = 0; $col < $maxCol; ++$col)
    {
        if (!isset($data[$col]))
        {
            $data[$col] = (object)["offset" => $rowSpan - ($maxRow - $data[$col - 1]->offset) % $rowSpan, "counter" => 0];
            if ($data[$col]->offset == $rowSpan)
                $data[$col]->offset = 0;
        }

        if ($data[$col]->counter++ == 0)
        {
            if ($row == 0)
            {
                if ($data[$col]->offset != 0)
                {
                    $realRowSpan = $data[$col]->offset;
                    $data[$col]->counter = $rowSpan - $data[$col]->offset + 1;
                }
                else
                {
                    $realRowSpan = $rowSpan;
                }
            }
            else
            {
                $realRowSpan = $maxRow - $row >= $rowSpan ? $rowSpan : $maxRow - $row;
            }

            echo "<td rowspan=\"{$realRowSpan}\">[{$row}][{$col}] offset={$data[$col]->offset}</td>";
        }

        if ($data[$col]->counter == $rowSpan)
            $data[$col]->counter = 0;
    }

    echo "</tr>";
}
echo "</table>";

echo "<hr/>";
for ($col = 0; $col < $maxCol; ++$col)
{
    $data[$col] = (object)["offset" => $col % 3, "counter" => 0];
}

echo "<table>";
for ($row = 0; $row < $maxRow; ++$row)
{
    echo "<tr>";
    
    for ($col = 0; $col < $maxCol; ++$col)
    {
        if (!isset($data[$col]))
        {
            $data[$col] = (object)["offset" => $rowSpan - ($maxRow - $data[$col - 1]->offset) % $rowSpan, "counter" => 0];
            if ($data[$col]->offset == $rowSpan)
                $data[$col]->offset = 0;
        }

        if ($data[$col]->counter++ == 0)
        {
            if ($row == 0)
            {
                if ($data[$col]->offset != 0)
                {
                    $realRowSpan = $data[$col]->offset;
                    $data[$col]->counter = $rowSpan - $data[$col]->offset + 1;
                }
                else
                {
                    $realRowSpan = $rowSpan;
                }
            }
            else
            {
                $realRowSpan = $maxRow - $row >= $rowSpan ? $rowSpan : $maxRow - $row;
            }

            echo "<td rowspan=\"{$realRowSpan}\">[{$row}][{$col}] offset={$data[$col]->offset}</td>";
        }

        if ($data[$col]->counter == $rowSpan)
            $data[$col]->counter = 0;
    }

    echo "</tr>";
}
echo "</table>";
?>
        </table>
	</body>
</html>
