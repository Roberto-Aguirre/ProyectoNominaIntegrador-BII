function toggleSubmenu(id, arrowId) {
    var submenu = document.getElementById(id);
    var arrow = document.getElementById(arrowId);

    // Alterna la clase .show en el submenú
    if (submenu.classList.contains('show')) {
        submenu.classList.remove('show'); // Colapsar el submenú
        arrow.classList.remove('fa-chevron-down');
        arrow.classList.add('fa-chevron-right');
    } else {
        submenu.classList.add('show'); // Expandir el submenú
        arrow.classList.remove('fa-chevron-right');
        arrow.classList.add('fa-chevron-down');
    }
}
