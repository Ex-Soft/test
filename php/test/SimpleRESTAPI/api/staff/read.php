<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// include database and object files
include_once '../config/database.php';
include_once '../objects/staff.php';

// instantiate database and staff object
$database = new Database();
$db = $database->getConnection();

// initialize object
$staff = new Staff($db);

// query staffs
$stmt = $staff->read();
$num = $stmt->rowCount();

// check if more than 0 record found
if($num>0){

    // staffs array
    $staffs_arr=array();
    $staffs_arr["records"]=array();

    // retrieve our table contents
    // fetch() is faster than fetchAll()
    // http://stackoverflow.com/questions/2770630/pdofetchall-vs-pdofetch-in-a-loop
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)){
        // extract row
        // this will make $row['name'] to
        // just $name only
        extract($row);

        $staff_item=array(
            "id" => $id,
            "name" => $name,
            "salary" => $salary,
            "dep" => $dep,
            "birth_date" => $birth_date
        );

        array_push($staffs_arr["records"], $staff_item);
    }

    // set response code - 200 OK
    http_response_code(200);

    // show staffs data in json format
    echo json_encode($staffs_arr);
}
else{

    // set response code - 404 Not found
    http_response_code(404);

    // tell the user no staffs found
    echo json_encode(
        array("message" => "No staffs found.")
    );
}