// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const carousel = document.querySelector('.carousel');
const container = document.querySelector('.carousel-container');
const slides = carousel.querySelector('.slides');
const dots = carousel.querySelector('.dots');
const dotIndicators = dots.querySelectorAll('.dot');
const prevBtn = document.querySelector('.carousel-prev');
const nextBtn = document.querySelector('.carousel-next');
const images = document.querySelectorAll('.carousel img');
let MySearch = "";
let currentIndex = 0;
const maxIndex = images.length - 1;
let imageWidth = images[0].clientWidth;

function moveTo(index) {
    currentIndex = index;
    container.style.transform = `translateX(-${currentIndex * imageWidth}px)`;

    // change the active dot indicator
    dotIndicators.forEach((dot, i) => {
        if (i === currentIndex) {
            dot.classList.add('active');
        } else {
            dot.classList.remove('active');
        }
    });
}

dotIndicators.forEach((dot, i) => {
    dot.addEventListener('click', () => {
        moveTo(i);
    });
});

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
}, 3000);

//Handles imageWidth when resizing the window
onresize = (event) => {
    if (imageWidth != images[0].clientWidth) {
        imageWidth = images[0].clientWidth;
        moveTo(currentIndex);
    }
};
