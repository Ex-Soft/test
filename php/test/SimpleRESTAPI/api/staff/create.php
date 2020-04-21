<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

// get database connection
include_once '../config/database.php';

// instantiate staff object
include_once '../objects/staff.php';

$database = new Database();
$db = $database->getConnection();

$staff = new Staff($db);

// get posted data
$data = json_decode(file_get_contents("php://input"));

// make sure data is not empty
if(!empty($data->name)){
    // set staff property values
    $staff->name = $data->name;

    if(!empty($data->salary))
        $staff->salary = $data->salary;

    if(!empty($data->dep))
        $staff->dep = $data->dep;

    if(!empty($data->birth_date))
        $staff->birth_date = date_create($data->birth_date)->format("Y-m-d");

    // create the staff
    if($staff->create()){

        // set response code - 201 created
        http_response_code(201);

        // tell the user
        echo json_encode(array("message" => "staff was created."));
    }

    // if unable to create the staff, tell the user
    else{

        // set response code - 503 service unavailable
        http_response_code(503);

        // tell the user
        echo json_encode(array("message" => "Unable to create staff."));
    }
}
else{

    // set response code - 400 bad request
    http_response_code(400);

    // tell the user
    echo json_encode(array("message" => "Unable to create staff. Data is incomplete."));
}
