<?php
header("Content-type: application/json");

$node = $_GET["node"];

if (!is_numeric($node)) {
    $data = array("success" => true, "children" => array(
        array("id" => 1, "parentId" => $node, "text" => "Folder# 1", "leaf" => false),
        array("id" => 2, "parentId" => $node, "text" => "Folder# 2", "leaf" => false),
        array("id" => 3, "parentId" => $node, "text" => "Folder# 3", "leaf" => false)
    ));

    if (!$data["children"][0]["leaf"]) {
        $data["children"][0]["children"] = array(
            array("id" => $data["children"][0]["id"] * 10 + 1, "parentId" => $data["children"][0]["id"], "text" => "Folder # ".strval($data["children"][0]["id"] * 10 + 1), "leaf" => false),
            array("id" => $data["children"][0]["id"] * 10 + 2, "parentId" => $data["children"][0]["id"], "text" => "Folder # ".strval($data["children"][0]["id"] * 10 + 2), "leaf" => false),
            array("id" => $data["children"][0]["id"] * 10 + 3, "parentId" => $data["children"][0]["id"], "text" => "Folder # ".strval($data["children"][0]["id"] * 10 + 3), "leaf" => false)
        );

        for ($i = 0; $i < 3; ++$i) {
            $data["children"][0]["children"][$i]["children"] = array(
                array("id" => $data["children"][0]["children"][$i]["id"] * 10 + 1, "parentId" => $data["children"][0]["children"][$i]["id"], "text" => "File # ".strval($data["children"][0]["children"][$i]["id"] * 10 + 1), "leaf" => true),
                array("id" => $data["children"][0]["children"][$i]["id"] * 10 + 2, "parentId" => $data["children"][0]["children"][$i]["id"], "text" => "File # ".strval($data["children"][0]["children"][$i]["id"] * 10 + 2), "leaf" => true),
                array("id" => $data["children"][0]["children"][$i]["id"] * 10 + 3, "parentId" => $data["children"][0]["children"][$i]["id"], "text" => "File # ".strval($data["children"][0]["children"][$i]["id"] * 10 + 3), "leaf" => true)
            );  
        }

        $data["message"] = gettype($data["children"][0]["children"]);
    }
} else {
    $node = intval($node);
    $isLeaf = $node > 10;

    $data = array("success" => true, "message" => gettype($node), "children" => array(
        array("id" => $node * 10 + 1, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 1), "leaf" => $isLeaf),
        array("id" => $node * 10 + 2, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 2), "leaf" => $isLeaf),
        array("id" => $node * 10 + 3, "parentId" => $node, "text" => ($isLeaf ? "File " : "Folder")."# ".strval($node * 10 + 3), "leaf" => $isLeaf)
    ));
}

echo json_encode($data);
?>
