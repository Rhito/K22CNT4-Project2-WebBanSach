
// slider
const slider = function () {
    const slides = document.querySelectorAll('.slide');

    let curSlide = 0;
    const maxSlide = slides.length;

    const goToSlide = function (slide) {
        slides.forEach(
            (s, i) => (s.style.transform = `translateX(${100 * (i - slide)}%)`)
        );
    };

// Next slide
    const nextSlide = function () {
        if (curSlide === maxSlide - 1) {
            curSlide = 0;
        } else {
            curSlide++;
        }

        goToSlide(curSlide);
    };

    const intervalSlide = setInterval(nextSlide, 3000)
}

slider();

let swiper = new Swiper(".swiper", {
    slidesPerView: 5, // Hiển thị 5 phần tử
    grabCursor: true, // Hiển thị con trỏ dạng kéo
    loop: true, // Cho phép lặp lại slide
    keyboard: {
        enabled: true, // Cho phép điều khiển bằng bàn phím
    },
    navigation: {
        nextEl: ".swiper-button-next", // Nút "Tiếp theo"
        prevEl: ".swiper-button-prev", // Nút "Quay lại"
    },
});


