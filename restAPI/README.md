# REST API written in C#
```bash
GET api/Attraction
```
*expected response body*
```bash
[
 {
  "id": 1,
  "name": "The Grand Canyon",
  "city": "Arizona",
  "description": "A beautiful natural wonder of the world",
  "imageSource": "https://www.grandcanyon.com/uploads/GCNP-Hero-Banner.jpg",
  "likes": 5
  "dislikes": 6
  "comments": [
    {
      "user": "Mina Simons",
      "comment": "Amazing experience, a must-visit!"
    },
    {
      "user": "John Doe",
      "comment": "Beautiful and breathtaking, highly recommended!"
    }
  ]
},
 {
  "id": 2,
  "name": "Yellow beach",
  "city": "Lisbon",
  "description": "A beautiful beach",
  "imageSource": "https://www.beach.com/sand.jpg",
  "likes": 5
  "dislikes": 6
  "comments": [
    {
      "user": "Jerry Simons",
      "comment": "Wowzers"
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
GET api/Attraction/User/{userId}
```
*expected request body*
```bash
{
    "userId" : 1
}
```
*expected response body*
```bash
 [
 {
  "id": 1,
  "name": "The Grand Canyon",
  "city": "Arizona",
  "description": "A beautiful natural wonder of the world",
  "imageSource": "https://www.grandcanyon.com/uploads/GCNP-Hero-Banner.jpg",
  "likes": 5
  "dislikes": 6
  "comments": [
    {
      "user": "Mina Simons",
      "comment": "Amazing experience, a must-visit!"
    },
    {
      "user": "John Doe",
      "comment": "Beautiful and breathtaking, highly recommended!"
    }
  ]
},
{
  "id": 2,
  "name": "Yello Beach ",
  "city": "Lisbon",
  "description": "Sick beach",
  "imageSource": "www.beach.com",
  "likes": 5
  "dislikes": 6
  "comments": [
    {
      "user": "Mina Simons",
      "comment": "Amazing experience, a must-visit!"
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
GET api/Attraction/{id}
```
*expected request body*
```bash
{
    "id" : 1
}
```
*expected response body*
```bash
 {
  "id": 1,
  "name": "The Grand Canyon",
  "city": "Arizona",
  "description": "A beautiful natural wonder of the world",
  "imageSource": "https://www.grandcanyon.com/uploads/GCNP-Hero-Banner.jpg",
  "likes": 5
  "dislikes": 6
  "comments": [
    {
      "user": "Mina Simons",
      "comment": "Amazing experience, a must-visit!"
    },
    {
      "user": "John Doe",
      "comment": "Beautiful and breathtaking, highly recommended!"
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
POST api/Attraction
```
*expected request body*
```bash
{
  "name": "The Grand Canyon",
  "city": "Arizona",
  "description": "A beautiful natural wonder of the world",
  "imageSource": "https://www.grandcanyon.com/wp-content/uploads/GCNP-Hero-Banner.jpg",
  "userId": 1
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
PUT api/Attraction
```
*expected request body*
```bash
{
  "name": "The Grand Canyon",
  "city": "Arizona",
  "description": "A beautiful natural wonder of the world",
  "imageSource": "https://www.grandcanyon.com/wp-content/uploads/GCNP-Hero-Banner.jpg",
  "userId": 1
}
```
*expected response body*
```bash
{
"id": 1
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
DELETE api/Attraction/{id}
```
*expected request body*
```bash
{
  "id": 1
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
GET api/Users/{id}
```
*expected request body*
```bash
{
  "id": 1
}
```

*expected response body*
```bash
{
  "id": 1
  "username": "Rocco"
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
    "username": "dog_fighter32"
    "password": "secret"
}
```

*expected response body*
```bash
{
  "id": 1
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
    "username": "dog_fighter32"
    "password": "secret"
}
```

*expected response body*
```bash
{
  "id": 1
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
DELETE api/Users/{id}
```
*expected request body*
```bash
{
    "id": 1
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
POST api/Comment
```
*expected request body*
```bash
{
    "attractionId": 1
    "userId": 2,
    "comment": "So pretty!!!"
}
```

*expected response body*
```bash
{
  "id": 1
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
PUT api/Comment
```
*expected request body*
```bash
{
    "attractionId": 1
    "userId": 2,
    "comment": "So pretty!!!"
}
```

*expected response body*
```bash
{
  "id": 1
  "username": "JimmyBongo"
  "comment": "So pretty!!!"
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
DELETE api/Comment/{id}
```
*expected request body*
```bash
{
    "id": 1
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
POST api/Rating
```
*expected request body*
```bash
{
  "attractionId": 3,
  "userId": 2,
  "value": 1 // 1 for like, 2 for dislike
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
PUT api/Rating
```
*expected request body*
```bash
{
  "attractionId": 3,
  "userId": 2,
  "value": 1 // 1 for like, 2 for dislike
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
DELETE api/Rating/{id}
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
