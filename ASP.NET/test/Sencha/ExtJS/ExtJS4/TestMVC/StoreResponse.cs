namespace TestMVC
{
    public class StoreResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public User[] users { get; set; }
    }
}

/*
	,
	metaData: {
		type: "json",
		root: "users",
		idProperty: "id",
		totalProperty: "total",
		successProperty: "success",
		messageProperty: "message",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name", type: "string" },
			{ name: "email", type: "string" }
		]
	}
*/