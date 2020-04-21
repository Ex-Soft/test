<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

// include database and object files
include_once '../config/database.php';
include_once '../objects/staff.php';

// get database connection
$database = new Database();
$db = $database->getConnection();

// prepare staff object
$staff = new Staff($db);

// get id of staff to be edited
$data = json_decode(file_get_contents("php://input"));

// set ID property of staff to be edited
$staff->id = $data->id;

// set staff property values
if(!empty($data->name))
    $staff->name = $data->name;

if(!empty($data->salary))
    $staff->salary = $data->salary;

if(!empty($data->dep))
    $staff->dep = $data->dep;

if(!empty($data->birth_date))
    $staff->birth_date = date_create($data->birth_date)->format("Y-m-d");

// update the staff
if($staff->update()){

    // set response code - 200 ok
    http_response_code(200);

    // tell the user
    echo json_encode(array("message" => "staff was updated."));
}

// if unable to update the staff, tell the user
else{

    // set response code - 503 service unavailable
    http_response_code(503);

    // tell the user
    echo json_encode(array("message" => "Unable to update staff."));
}
