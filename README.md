# E-Shop-Microservices
Microservices Online E-Commerce Web Application Using .Net Core 6 

## Catalog Microservice:

  ### RESTFul API Endpoints:
----------------------------
- **`api/v1/Catalog`**
  1) Method : **`GET Request`** 
  2) Use Case : **`Listing all the products and categories`**
  
- **`api/v1/Catalog/{id}`**
  1) Method : **`GET Request`** 
  2) Use Case : **`Retrieve a product with product id`**
  
- **`api/v1/Catalog?categoryName=NAME`**
  1) Method : **`GET Request`** 
  2) Use Case : **`List all the products under specific category`**

- **`api/v1/Catalog`**
  1) Method : **`POST Request`** 
  2) Use Case : **`Create a new product`**

- **`api/v1/Catalog/{id}`**
  1) Method : **`PUT Request`** 
  2) Use Case : **`Update an existing product`**
  
 - **`api/v1/Catalog/{id}`**
    1) Method : **`DELETE Request`** 
    2) Use Case : **`Delete a product given the product id`**
