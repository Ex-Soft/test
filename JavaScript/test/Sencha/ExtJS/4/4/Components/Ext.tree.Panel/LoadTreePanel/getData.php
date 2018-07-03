<?php
header("Content-type: application/json");

$node = $_GET["node"];

if (!is_numeric($node)) {
    $data = array("success" => true, "children" => array(
        array("id" => 1, "parentId" => $node, "text" => "Folder# 1"),
        array("id" => 2, "parentId" => $node, "text" => "Folder# 2"),
        array("id" => 3, "parentId" => $node, "text" => "Folder# 3"),
        array("id" => 4, "parentId" => $node, "text" => "Folder# 4"),
        array("id" => 5, "parentId" => $node, "text" => "Folder# 5")
    ));
} else {
    $node = intval($node);
    $isLeaf = $node > 10;

    $data = array("success" => true, "message" => gettype($node), "children" => array(
        array("id" => $node * 10 + 1, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 1), "leaf" => $isLeaf),
        array("id" => $node * 10 + 2, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 2), "leaf" => $isLeaf),
        array("id" => $node * 10 + 3, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 3), "leaf" => $isLeaf),
        array("id" => $node * 10 + 4, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 4), "leaf" => $isLeaf),
        array("id" => $node * 10 + 5, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 5), "leaf" => $isLeaf)
    ));
}

echo json_encode($data);
?>
