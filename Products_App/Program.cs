using CRUDLayers.ProductServices;
using CRUDLayers.Repositories;

var repository = new ProductRepository();
var service = new ProductService(repository);
var controller = new ProductController(service);
var menu = new Menu(controller);
menu.ShowMenu();
