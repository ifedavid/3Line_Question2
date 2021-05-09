# 3Line_Question2
Question 2 of the 3 line card management limited backend developer Test

# Created an API service for Question 2

Question 2
We want to give our customers the best experience possible so we should inform them about the details
of their cards like:
Valid/not valid
The scheme (i.e., VISA, MASTERCARD or AMEX)
The bank when it is available.
Create a simple REST API service that will understand the following call and response structure:
a. Authenticate the request using these values passed in the header.
appKey = “test_20191123132233”
timeStamp = “1617953042”
hashed =
“4n+F7tDHDaFCoPkDDCtHMX6fvNIolyzMLFONT5c4XSYBg7VYFg1uMDYW7b3wDOs+rKL4QjaY2A100Jufsg
1XFA==”
{
authorization: 3line + “ ” + hashed*,
timeStamp: timestamp*,
appKey: appKey*

}
Note that:
• In the JSON header payload, all values with asterisks are variables and should be
• replaced accordingly.
• The hashed value is generated using a SHA-512 hash of the appKey + timestamp
• Verify that these values are present in the headers, else return an invalid message request.
• If authorization value does not match after comparing, return an invalid authorization key
message.
b. Verify Card: GET /card-scheme/verify/234564562....
{ "success": true,
"payload": {
"scheme": "visa",
"type": "debit",
"bank": "UBS"
}
}
c. Number of hits (Hit Count): GET /card-scheme/stats?start=1&limit=3
{
"success": true,
"start": 1,
"limit": 3,
"size": 133,
"payload": {
"545423": 5,
"679234": 4,
"329802": 1
}
}
d. Consider ways of optimizing the card verification endpoint, and implement if any
e. Write unit tests for your implementations.



# Deployed this API service to heroku using docker

Test the two endpoints using this links

1. Verify Card - [https://threel-ine-question-two.herokuapp.com/cardinformation/card-scheme/verify/2234]

2. Check Hit Counts - [https://threel-ine-question-two.herokuapp.com/cardinformation/card-scheme/stats?start=1&limit=3]

