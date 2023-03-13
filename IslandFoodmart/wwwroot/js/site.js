// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const carousel = document.querySelector('.carousel');
const container = document.querySelector('.carousel-container');
const prevBtn = document.querySelector('.carousel-prev');
const nextBtn = document.querySelector('.carousel-next');
const images = document.querySelectorAll('.carousel img');

let currentIndex = 0;
const maxIndex = images.length - 1;
const imageWidth = images[0].clientWidth;

function moveTo(index) {
    currentIndex = index;
    container.style.transform = `translateX(-${currentIndex * imageWidth}px)`;
}

prevBtn.addEventListener('click', () => {
    if (currentIndex > 0) {
        moveTo(currentIndex - 1);
    } else {
        moveTo(maxIndex);
    }
});

nextBtn.addEventListener('click', () => {
    if (currentIndex < maxIndex) {
        moveTo(currentIndex + 1);
    } else {
        moveTo(0);
    }
});

moveTo(currentIndex);

setInterval(() => {
    if (currentIndex < maxIndex) {
        moveTo(currentIndex + 1);
    } else {
        moveTo(0);
    }
}, 4000);
