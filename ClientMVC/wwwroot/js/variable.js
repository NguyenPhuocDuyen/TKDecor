//token when login success
var token = 'Bearer ' + document.cookie.replace(/(?:(?:^|.*;\s*)access_token\s*\=\s*([^;]*).*$)|^.*$/, "$1");

//url local of mvc
var urlLocal = 'https://localhost:44310/';
//url api gateway 
var urlAPIGateway = 'https://localhost:44364/api/apigateway/';

//url get products
var urlGetProducts = urlAPIGateway + "Products/GetProducts";
//url update product by id
var urlUpdateProduct = urlAPIGateway + 'Products/UpdateProduct/';

//url user
var urlUser = urlAPIGateway + "Users";
//url get users
var urlGetUsers = urlUser + "/GetUsers";
//url update user info
var urlUpdateInfoUser = urlUser + "/UpdateInfoUser";

//url get order
var urlOrder = urlAPIGateway + "Orders";
//get orders List for user or admin
var urlGetOrdersOfUser = urlOrder + "/GetOrdersOfUser";
//order products in cart
var urlOrderProducts = urlOrder + "/OrderProducts";
//confirm order products status ordered, cancel,...
var urlConfirmOrder = urlOrder + "/ConfirmOrder";

//
var urlGetOrderDetailReceived = urlAPIGateway + "OrderDetails/GetOrderDetailReceived";

//url add review product
var urlAddReview = urlAPIGateway + "Reviews/AddReview";
//url get reviews of product + id
var urlGetReviewsOfProduct = urlAPIGateway + "Reviews/GetReviewsOfProduct/";

//url cart
var urlCart = urlAPIGateway + "Carts";
//url add product to cart
var urlAddProductToCart = urlCart + '/AddProductToCart';
//url delete cart/id
var urlDeleteCart = urlCart + "/";
//url update cart/id
var urlPutCart = urlCart + "/PutCart";
//url check quantity in cart
var urlCheckQuantityCart = urlCart + "/CheckQuantity";

//toast message 
var messSuccess = 'Thành công!';
var messError = 'Thất bại thử lại sau!';