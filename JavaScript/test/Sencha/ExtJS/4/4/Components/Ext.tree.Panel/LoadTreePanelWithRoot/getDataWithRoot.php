<?php
header("Content-type: application/json");

$node = $_GET["node"];

if (!is_numeric($node)) {
    $data = array("success" => true, "children" => array("text"=>"Root (loaded)", "parentId" => "", "leaf" => false, "children" => array(
        array("id" => 1, "parentId" => $node, "text" => "Folder# 1", "leaf" => false),
        array("id" => 2, "parentId" => $node, "text" => "Folder# 2", "leaf" => false),
        array("id" => 3, "parentId" => $node, "text" => "Folder# 3", "leaf" => false)
    )));
}

echo json_encode($data);
?>
