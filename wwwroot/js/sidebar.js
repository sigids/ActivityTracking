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

// Download file from base64 content
window.downloadFile = function (base64Content, fileName, mimeType) {
    const byteCharacters = atob(base64Content);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: mimeType });
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    window.URL.revokeObjectURL(url);
};

document.addEventListener('DOMContentLoaded', function () {
    initSidebar();
});

