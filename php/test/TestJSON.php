<?php
header("Content-type: application/json");

$data = array();
$data[0] = array("row" => array("id" => 1, "name" => "name# 1", "status" => "started", "cpu" => array("limit" => 10, "value" => 1), "ram" => array("limit" => 100, "value" => 10), "disk_space" => array("limit" => 1000, "value" => 100)));
$data[1] = array("row" => array("id" => 2, "name" => "name# 2", "status" => "stopped", "cpu" => array("limit" => 20, "value" => 2), "ram" => array("limit" => 200, "value" => 20), "disk_space" => array("limit" => 2000, "value" => 200)));
$data[2] = array("row" => array("id" => 3, "name" => "name# 3", "status" => "stopping", "cpu" => array("limit" => 30, "value" => 3), "ram" => array("limit" => 300, "value" => 30), "disk_space" => array("limit" => 3000, "value" => 300)));
$data[3] = array("row" => array("id" => 4, "name" => "name# 4", "status" => "starting", "cpu" => array("limit" => 40, "value" => 4), "ram" => array("limit" => 400, "value" => 40), "disk_space" => array("limit" => 4000, "value" => 400)));

echo json_encode($data);
?>

