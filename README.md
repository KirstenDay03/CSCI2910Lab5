# CSCI2910Lab5
One issue was getting my code to recognize the GetFromJsonAsync<JsonElement>.
Was able to fix it by changing my "using System.Net.Http" to "using System.Net.Http.Json"

Issue two was I could not get any data to display and my query wasn't working.
I had to await my method call in my main method to fix it.
