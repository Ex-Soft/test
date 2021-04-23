## https://docs.confluent.io/platform/current/schema-registry/develop/api.html
##
## -k/--insecure (SSL) This option explicitly allows curl to perform "insecure" SSL connections and transfers. All SSL connections are attempted to be made secure by using the CA certificate bundle installed by default. This makes all connections considered "insecure" fail unless -k/--insecure is used.
## -L/--location (HTTP/HTTPS) If the server reports that the requested page has moved to a different location (indicated with a Location: header and a 3XX response code), this option will make curl redo the request on the new place. If used together with -i/--include or -I/--head, headers from all requested pages will be shown. When authentication is used, curl only sends its credentials to the initial host. If a redirect takes curl to a different host, it won't be able to intercept the user+password. See also --location-trusted on how to change this. You can limit the amount of redirects to follow by using the --max-redirs option.
## -X/--request <command> (HTTP) Specifies a custom request method to use when communicating with the HTTP server. The specified request will be used instead of the method otherwise used (which defaults to GET). Read the HTTP 1.1 specification for details and explanations. Common additional HTTP requests include PUT and DELETE, but related technologies like WebDAV offers PROPFIND, COPY, MOVE and more.
## -s/--silent Silent or quiet mode. Don't show progress meter or error messages. Makes Curl mute.
## -m/--max-time <seconds> Maximum time in seconds that you allow the whole operation to take. This is useful for preventing your batch jobs from hanging for hours due to slow networks or links going down. See also the --connect-timeout option.
## -v/--verbose Makes the fetching more verbose/talkative. Mostly useful for debugging. A line starting with '>' means "header data" sent by curl, '<' means "header data" received by curl that is hidden in normal cases, and a line starting with '*' means additional info provided by curl.
##
curl -k -s -X GET http://localhost:8081/subjects

curl --insecure --silent --request GET http://localhost:8081/schemas/ids/4
curl --insecure --silent --request GET http://localhost:8081/schemas/ids/4/versions

curl --insecure --silent --request GET http://localhost:8081/subjects
curl --insecure --silent --request GET http://localhost:8081/subjects/TestTypes-value/versions
curl --insecure --silent --request GET http://localhost:8081/subjects/TestTypes-value/versions/2
curl --insecure --silent --request GET http://localhost:8081/subjects/TestTypes-value/versions/2/schema

curl --insecure --silent --request DELETE http://localhost:8081/subjects/TestTypes-value

curl --insecure --silent --request GET http://localhost:8081/config/TestTypes-value
curl --insecure --silent --request PUT http://localhost:8081/config/TestTypes-value --header "Content-Type: application/json" --data-raw "{\"compatibility\":\"FULL_TRANSITIVE\"}"