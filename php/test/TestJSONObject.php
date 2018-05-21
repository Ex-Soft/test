<?php
header("Content-type: application/json");

/*
$data->pString = "pString";
$data->pInteger = 1;
$data->pNumber = 1.1;
$data->pArray = array("1st", "2nd", "3rd");

$obj->p1 = "p1";
$obj->p2 = 1;
$obj->p3 = 1.1; 

$data->pObj = $obj;

*/

/*
$data = array("result" => 0, "status" => array(
            "1@1.com" => array("assigned" => 25, "running" => 50, "stopped" => 75, "other" => 100),
            "2@2.com" => array("assigned" => 50, "running" => 75, "stopped" => 100, "other" => 125),
            "3@3.com" => array("assigned" => 75, "running" => 100, "stopped" => 125, "other" => 150),
            "4@4.com" => array("assigned" => 100, "running" => 125, "stopped" => 150, "other" => 175)
        ));
*/

$data = array("result" => 0, "users" => array(
            array("email" => "1@1.com", "displayName" => "1 1", "isAssigned" => 0),
            array("email" => "2@2.com", "displayName" => "2 2", "isAssigned" => 1),
            array("email" => "3@3.com", "displayName" => "3 3", "isAssigned" => 1),
            array("email" => "4@4.com", "displayName" => "4 4", "isAssigned" => 0)
        ));

echo json_encode($data);
?>

