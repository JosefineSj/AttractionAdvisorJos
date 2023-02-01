# REST API written in C#
```bash
GET api/attractions
```
*expected response body*
```bash
[
 {
  "Id": 1,
  "Name": "The Grand Canyon",
  "City": "Arizona",
  "Description": "A beautiful natural wonder of the world",
  "ImageSource": "https://www.grandcanyon.com/uploads/GCNP-Hero-Banner.jpg",
  "Ratings": [
    {
      "User": "Mina Simons",
      "Likes": false 
    },
    {
      "User": "John Doe",
      "Likes": true
    }
  ],
  "Comments": [
    {
      "User": "Mina Simons",
      "Comment": "Amazing experience, a must-visit!"
    },
    {
      "User": "John Doe",
      "Comment": "Beautiful and breathtaking, highly recommended!"
    }
  ]
},
 {
  "Id": 2,
  "Name": "Yellow beach",
  "City": "Lisbon",
  "Description": "A beautiful beach",
  "ImageSource": "https://www.beach.com/sand.jpg",
  "Ratings": [
    {
      "User": "Mina Simons",
      "Likes": false 
    }
  ],
  "Comments": [
    {
      "User": "Jerry Simons",
      "Comment": "Wowzers"
    },
  ]
},
]
```
*expected ok*

>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
GET api/attractions:userId
```
*expected request body*
```bash
{
    "UserId" : 1
}
```
*expected response body*
```bash
 [
 {
  "Id": 1,
  "Name": "The Grand Canyon",
  "City": "Arizona",
  "Description": "A beautiful natural wonder of the world",
  "ImageSource": "https://www.grandcanyon.com/uploads/GCNP-Hero-Banner.jpg",
  "Ratings": [
    {
      "User": "Mina Simons",
      "Likes": false 
    },
    {
      "User": "John Doe",
      "Likes": true
    }
  ],
  "Comments": [
    {
      "User": "Mina Simons",
      "Comment": "Amazing experience, a must-visit!"
    },
    {
      "User": "John Doe",
      "Comment": "Beautiful and breathtaking, highly recommended!"
    }
  ]
},
{
  "Id": 2,
  "Name": "Yello Beach ",
  "City": "Lisbon",
  "Description": "Sick beach",
  "ImageSource": "www.beach.com",
  "Ratings": [
    {
      "User": "Mina Simons",
      "Likes": false 
    }
  ],
  "Comments": [
    {
      "User": "Mina Simons",
      "Comment": "Amazing experience, a must-visit!"
    }
  ]
},
}
 ]
```

*expected ok*

>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
GET api/attractions:id
```
*expected request body*
```bash
{
    "Id" : 1
}
```
*expected response body*
```bash
 {
  "Id": 1,
  "Name": "The Grand Canyon",
  "City": "Arizona",
  "Description": "A beautiful natural wonder of the world",
  "ImageSource": "https://www.grandcanyon.com/uploads/GCNP-Hero-Banner.jpg",
  "Ratings": [
    {
      "User": "Mina Simons",
      "Likes": false 
    },
    {
      "User": "John Doe",
      "Likes": true
    }
  ],
  "Comments": [
    {
      "User": "Mina Simons",
      "Comment": "Amazing experience, a must-visit!"
    },
    {
      "User": "John Doe",
      "Comment": "Beautiful and breathtaking, highly recommended!"
    }
  ]
}
```

*expected ok*

>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
GET api/attractions:city
```
*expected request body*
```bash
{
    "City" : "Arizona"
}
```
*expected response body*
```bash
[
 {
  "Id": 1,
  "Name": "The Grand Canyon",
  "City": "Arizona",
  "Description": "A beautiful natural wonder of the world",
  "ImageSource": "https://www.grandcanyon.com/uploads/GCNP-Hero-Banner.jpg",
  "Ratings": [
    {
      "User": "Mina Simons",
      "Likes": false 
    },
    {
      "User": "John Doe",
      "Likes": true
    }
  ],
  "Comments": [
    {
      "User": "Mina Simons",
      "Comment": "Amazing experience, a must-visit!"
    },
    {
      "User": "John Doe",
      "Comment": "Beautiful and breathtaking, highly recommended!"
    }
  ]
},
 {
  "Id": 2,
  "Name": "Big Shack",
  "City": "Arizona",
  "Description": "It's big",
  "ImageSource": "www.shack.com",
  "Ratings": [
    {
      "User": "John Doe",
      "Likes": true
    }
  ],
  "Comments": [
    {
      "User": "John Doe",
      "Comment": "Nice shack"
    }
  ]
},
}
]
```

*expected ok*

>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
POST api/attractions
```
*expected request body*
```bash
{
  "Name": "The Grand Canyon",
  "City": "Arizona",
  "Description": "A beautiful natural wonder of the world",
  "ImageSource": "https://www.grandcanyon.com/wp-content/uploads/GCNP-Hero-Banner.jpg",
  "UserId": 1
}
```
*expected response body*
```bash
{
"Id": 1
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---
```bash
PUT api/attractions
```
*expected request body*
```bash
{
  "Name": "The Grand Canyon",
  "City": "Arizona",
  "Description": "A beautiful natural wonder of the world",
  "ImageSource": "https://www.grandcanyon.com/wp-content/uploads/GCNP-Hero-Banner.jpg",
  "UserId": 1
}
```
*expected response body*
```bash
{
"Id": 1
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
DELETE api/attractions:id
```
*expected request body*
```bash
{
  "Id": 1
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
GET api/Users:id
```
*expected request body*
```bash
{
  "Id": 1
}
```

*expected response body*
```bash
{
  "Id": 1
  "Username": "Rocco"
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
POST api/Users
```
*expected request body*
```bash
{
    "Username": "dog_fighter32"
    "Password": "secret"
}
```

*expected response body*
```bash
{
  "Id": 1
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
PUT api/Users
```
*expected request body*
```bash
{
    "Username": "dog_fighter32"
    "Password": "secret"
}
```

*expected response body*
```bash
{
  "Id": 1
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
DELETE api/Users:id
```
*expected request body*
```bash
{
    "Id": 1
}
```

*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
POST api/Comments
```
*expected request body*
```bash
{
    "AttractionId": 1
    "UserId": 2,
    "Comment": "So pretty!!!"
}
```

*expected response body*
```bash
{
  "Id": 1
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
PUT api/Comments
```
*expected request body*
```bash
{
    "AttractionId": 1
    "UserId": 2,
    "Comment": "So pretty!!!"
}
```

*expected response body*
```bash
{
  "Id": 1
  "Username": "JimmyBongo"
  "Comment": "So pretty!!!"
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
DELETE api/Comments:id
```
*expected request body*
```bash
{
    "Id": 1
}
```

*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---
```bash
POST api/Ratings
```
*expected request body*
```bash
{
    "AttractionId": 2,
    "UserId": 3,
    "Likes": true
}
```
*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
PUT api/Ratings
```
*expected request body*
```bash
{
    "AttractionId": 2,
    "UserId": 3,
    "Likes": 4
}
```

*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---

```bash
DELETE api/Ratings:id
```
*expected request body*
```bash
{
    "Id": 1
}
```

*expected ok*
>Status : 200

*expected not found*
>Status 404

*expected bad request*
>Status 400

*expected internal server error*
>Status 500
---
## Admin endpoints WIP?
