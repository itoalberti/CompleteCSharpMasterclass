using CRUDLayers.Repositories;

var repository = new ProductRepository();

var controller = new ProductController(repository);
var menu = new Menu(controller);
menu.ShowMenu();
