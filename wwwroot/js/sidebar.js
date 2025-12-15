window.toggleSidebar = function () {
    const container = document.querySelector('.app-container');
    if (container.classList.contains('sidebar-open')) {
        container.classList.remove('sidebar-open');
        container.classList.add('sidebar-closed');
        localStorage.setItem('sidebarState', 'closed');
    } else {
        container.classList.remove('sidebar-closed');
        container.classList.add('sidebar-open');
        localStorage.setItem('sidebarState', 'open');
    }
    updateToggleIcon();
};

window.initSidebar = function () {
    const savedState = localStorage.getItem('sidebarState');
    const container = document.querySelector('.app-container');
    if (savedState === 'closed') {
        container.classList.remove('sidebar-open');
        container.classList.add('sidebar-closed');
    } else {
        container.classList.remove('sidebar-closed');
        container.classList.add('sidebar-open');
    }
    updateToggleIcon();
};

function updateToggleIcon() {
    const container = document.querySelector('.app-container');
    const icon = document.querySelector('.toggle-icon');
    if (icon) {
        icon.textContent = container.classList.contains('sidebar-open') ? '<' : '>';
    }
}

document.addEventListener('DOMContentLoaded', function () {
    initSidebar();
});
