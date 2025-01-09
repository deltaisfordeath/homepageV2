// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function updateTheme() {
    const colorMode = window.matchMedia("(prefers-color-scheme: dark)").matches ?
        "dark" :
        "light";
    console.log(colorMode);
    const nav = document.querySelector("nav");
    nav.classList.add(`navbar-${colorMode}`);
    nav.classList.add(`bg-${colorMode}`)
}

updateTheme();