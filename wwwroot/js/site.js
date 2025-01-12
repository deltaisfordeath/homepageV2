// Navbar
const menuButton = document.querySelector('[aria-controls="mobile-menu"]');
const mobileMenu = document.querySelector('#mobile-menu');
const menuIcons = menuButton.querySelectorAll('[data-slot="icon"]');
menuButton.addEventListener('click', () => {
    mobileMenu.classList.toggle('hidden');
    
    const isExpanded = menuButton.getAttribute('aria-expanded') === 'true';
    menuButton.setAttribute('aria-expanded', !isExpanded);
    
    if (isExpanded) {
        mobileMenu.style.height = '0px';
    } else {
        mobileMenu.style.height = mobileMenu.scrollHeight + 'px';
    }
    
    menuIcons.forEach((icon) => {
        icon.classList.toggle('hidden');
        icon.classList.toggle('block');
    });
});