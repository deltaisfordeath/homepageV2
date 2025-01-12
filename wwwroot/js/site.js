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
        mobileMenu.style.visibility = 'visible';
    }
    
    menuIcons.forEach((icon) => {
        icon.classList.toggle('hidden');
        icon.classList.toggle('block');
    });
});

function closeMenu(e) {
    if(e.matches && menuIcons[0].classList.contains('block')) {
        menuIcons[0].classList.add('hidden');
        menuIcons[0].classList.remove('block');
        menuIcons[1].classList.add('block');
        menuIcons[1].classList.remove('hidden');
    } else {
        menuIcons[0].classList.add('block');
        menuIcons[0].classList.remove('hidden');
        menuIcons[1].classList.add('hidden');
        menuIcons[1].classList.remove('block');
    }
    mobileMenu.style.height = '0px';
    mobileMenu.style.visibility = 'hidden';
    menuButton.setAttribute('aria-expanded', 'false');
}

window.matchMedia("(min-width: 640px)").addEventListener('change', closeMenu)