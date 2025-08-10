# API

- [Api](#api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Rain",
  "lastName": "Hu",
  "email": "rain.hu@advantech.com",
  "password": "1q2w3E*"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Rain",
  "lastName": "Hu",
  "email": "rain.hu@advantech.com",
  "token": "eyJhb..z9dgcnXoY"
}
```

### Login

```js
PSOT {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "rain.hu@advantech.com",
  "password": "1q2w3E*"
}
```

#### Login Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Rain",
  "lastName": "Hu",
  "email": "rain.hu@advantech.com",
  "token": "eyJhb..z9dgcnXoY"
}
```
