import axios from "axios";

try {
  axios
    .post(
      "https://tmzwebapitest.azurewebsites.net/United/GetCoopAllowanceList",
      { dealerEmails: ["pvmarketing@perfect-vision.com"] },
      { headers: { "Content-Type": "application/json" } }
    )
    .then((response) => {
      console.log(response);
    })
    .catch((error) => {
      console.log(error);
    });
} catch (error) {
  console.log(error);
}
