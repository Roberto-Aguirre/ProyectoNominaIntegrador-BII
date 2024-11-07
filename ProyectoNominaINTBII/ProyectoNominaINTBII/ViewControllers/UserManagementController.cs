using Microsoft.AspNetCore.Mvc;

public class UserManagementController : Controller
{
    // Acción para cargar la vista de gestión de usuarios
    public IActionResult Index()
    {
        return View(); // Esto cargará la vista /Views/UserManagement/Index.cshtml
    }
}
