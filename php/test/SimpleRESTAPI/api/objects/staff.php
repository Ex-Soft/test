<?php

/* https://www.codeofaninja.com/2017/02/create-simple-rest-api-in-php.html */

class Staff{

    // database connection and table name
    private $conn;
    private $table_name = "staff";

    // object properties
    public $id;
    public $name;
    public $salary;
    public $dep;
    public $birth_date;

    // constructor with $db as database connection
    public function __construct($db){
        $this->conn = $db;
    }

    // read staffs
    function read(){

        // select all query
        $query = "SELECT
                id, name, salary, dep, birth_date
            FROM
                " . $this->table_name . "
            ORDER BY
                id";

        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // execute query
        $stmt->execute();

        return $stmt;
    }

    // create staff
    function create(){

        // query to insert record
        $query = "INSERT INTO
                " . $this->table_name . "
            SET
                name=:name, salary=:salary, dep=:dep, birth_date=:birth_date";

        // prepare query
        $stmt = $this->conn->prepare($query);

        // sanitize
        $this->name=htmlspecialchars(strip_tags($this->name));
        $this->salary=htmlspecialchars(strip_tags($this->salary));
        $this->dep=htmlspecialchars(strip_tags($this->dep));
        $this->birth_date=htmlspecialchars(strip_tags($this->birth_date));

        // bind values
        $stmt->bindParam(":name", $this->name);
        $stmt->bindParam(":salary", $this->salary);
        $stmt->bindParam(":dep", $this->dep);
        $stmt->bindParam(":birth_date", $this->birth_date);

        // execute query
        if($stmt->execute()){
            return true;
        }

        return false;

    }

    // update the staff
    function update(){

        // update query
        $query = "UPDATE
                " . $this->table_name . "
            SET
                name = :name,
                salary = :salary,
                dep = :dep,
                birth_date = :birth_date
            WHERE
                id = :id";

        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // sanitize
        $this->name=htmlspecialchars(strip_tags($this->name));
        $this->salary=htmlspecialchars(strip_tags($this->salary));
        $this->dep=htmlspecialchars(strip_tags($this->dep));
        $this->birth_date=htmlspecialchars(strip_tags($this->birth_date));
        $this->id=htmlspecialchars(strip_tags($this->id));

        // bind new values
        $stmt->bindParam(':name', $this->name);
        $stmt->bindParam(':salary', $this->salary);
        $stmt->bindParam(':dep', $this->dep);
        $stmt->bindParam(':birth_date', $this->birth_date);
        $stmt->bindParam(':id', $this->id);

        // execute the query
        if($stmt->execute()){
            return true;
        }

        return false;
    }

    // delete the staff
    function delete(){

        // delete query
        $query = "DELETE FROM " . $this->table_name . " WHERE id = ?";

        // prepare query
        $stmt = $this->conn->prepare($query);

        // sanitize
        $this->id=htmlspecialchars(strip_tags($this->id));

        // bind id of record to delete
        $stmt->bindParam(1, $this->id);

        // execute query
        if($stmt->execute()){
            return true;
        }

        return false;
    }
}
