async function ApiFetch(url, method = null, body = null) {
    console.log("ApiFetch");
    const urlBase = "https://localhost:7216/api" + url;
 
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'text/plain');
 
   
     try {
        let res = await fetch(urlBase, {
        method: method ?? 'GET',
        headers: headers,
        mode: 'cors',
        body: body ? JSON.stringify(body) : null
        }); 
    if (res.ok) {console.log("Request successful from");
     var data = await res.json();
     console.log(data);
     return data;
    
     }
     else {
    console.log(`Failed to receive data from server: ${res.status}`);
    //alert(`Failed to receive data from server: ${res.status}`);
     }
     }
     catch (err) {
    console.log(`Failed to receive data from server: ${err.message}`);
    alert(`Failed to receive data from server: ${err.message}`);
     }
    }
 
    export default ApiFetch;